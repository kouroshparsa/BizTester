using System;
using System.Linq;
using System.Collections.Generic;
using DiffPlex;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;
using DiffPlex.Chunkers;
using BizTester.Models;

namespace BizTester.reg_report
{
    class ReportGenerator
    {

        private const double TopMargin = 40;
        private const double BottomMargin = 40;
        private const double LeftMargin = 40;
        private const double LineHeight = 12;

        private static XFont Font = new XFont("Arial", 9);
        private static XFont FontBold = new XFont("Arial", 9, XFontStyle.Bold);

        private static readonly XBrush InsertBrush = new XSolidBrush(XColor.FromArgb(212, 237, 218));
        private static readonly XBrush DeleteBrush = new XSolidBrush(XColor.FromArgb(248, 215, 218));
        private static readonly XBrush ModifyBrush = new XSolidBrush(XColor.FromArgb(255, 243, 205));


        private static List<string> WrapText(
            XGraphics gfx,
            string text,
            XFont font,
            double maxWidth)
        {
            var lines = new List<string>();

            if (string.IsNullOrEmpty(text))
            {
                lines.Add(string.Empty);
                return lines;
            }

            var words = text.Split(' ');
            var currentLine = "";

            foreach (var word in words)
            {
                var test = string.IsNullOrEmpty(currentLine)
                    ? word
                    : currentLine + " " + word;

                if (gfx.MeasureString(test, font).Width <= maxWidth)
                {
                    currentLine = test;
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentLine))
                        lines.Add(currentLine);

                    currentLine = word;
                }
            }

            if (!string.IsNullOrEmpty(currentLine))
                lines.Add(currentLine);

            return lines;
        }

        private static int DrawWrappedWholeLine(
            PdfDocument doc,
            ref PdfPage page,
            ref XGraphics gfx,
            ref double y,
            string text,
            XBrush background,
            double x,
            double width)
        {
            var wrapped = WrapText(gfx, text, Font, width);
            int rows = 0;

            foreach (var row in wrapped)
            {
                EnsurePage(doc, ref page, ref gfx, ref y, LineHeight);

                gfx.Save();
                gfx.IntersectClip(new XRect(x, y - LineHeight + 2, width, LineHeight));

                if (background != null)
                {
                    gfx.DrawRectangle(
                        background,
                        x,
                        y - LineHeight + 2,
                        width,
                        LineHeight);
                }

                gfx.DrawString(row, Font, XBrushes.Black, x, y);

                gfx.Restore();

                y += LineHeight;
                rows++;
            }

            return rows;
        }

        private static int MeasureWrappedRows(
            XGraphics gfx,
            DiffPiece line,
            double width)
        {
            if (line == null || string.IsNullOrEmpty(line.Text))
                return 1;

            // Inserted / Deleted / Unchanged
            if (line.Type != ChangeType.Modified || line.SubPieces == null)
            {
                return WrapText(gfx, line.Text, Font, width).Count;
            }

            // Modified (inline)
            int rows = 1;
            double cursorX = 0;

            foreach (var piece in line.SubPieces)
            {
                var words = (piece.Text ?? "").Split(' ');

                foreach (var word in words)
                {
                    var size = gfx.MeasureString(word + " ", Font);

                    if (cursorX + size.Width > width)
                    {
                        rows++;
                        cursorX = 0;
                    }

                    cursorX += size.Width;
                }
            }

            return rows;
        }

        private static void DrawWrappedRow(
            XGraphics gfx,
            DiffPiece line,
            int rowIndex,
            double x,
            double y,
            double width)
        {
            if (line == null || string.IsNullOrEmpty(line.Text))
                return;

            gfx.Save();
            gfx.IntersectClip(new XRect(x, y - LineHeight + 2, width, LineHeight));

            // Whole-line insert/delete
            if ((line.Type == ChangeType.Inserted || line.Type == ChangeType.Deleted) &&
                (line.SubPieces == null || !line.SubPieces.Any()))
            {
                XBrush bg = line.Type == ChangeType.Inserted ? InsertBrush : DeleteBrush;

                var wrapped = WrapText(gfx, line.Text, Font, width);
                if (rowIndex < wrapped.Count)
                {
                    gfx.DrawRectangle(bg, x, y - LineHeight + 2, width, LineHeight);
                    gfx.DrawString(wrapped[rowIndex], Font, XBrushes.Black, x, y);
                }

                gfx.Restore();
                return;
            }

            // Modified / SubPieces highlighting
            if (line.Type == ChangeType.Modified && line.SubPieces != null)
            {
                double cursorX = x;
                int currentRow = 0;

                foreach (var piece in line.SubPieces)
                {
                    var words = (piece.Text ?? "").Split(' ');

                    foreach (var word in words)
                    {
                        var text = word + " ";
                        var size = gfx.MeasureString(text, Font);

                        if (cursorX + size.Width > x + width)
                        {
                            currentRow++;
                            cursorX = x;
                        }

                        if (currentRow == rowIndex)
                        {
                            XBrush bg = null;
                            if (piece.Type == ChangeType.Inserted) bg = InsertBrush;
                            else if (piece.Type == ChangeType.Deleted) bg = DeleteBrush;
                            else if (piece.Type == ChangeType.Modified) bg = ModifyBrush;

                            if (bg != null)
                                gfx.DrawRectangle(bg, cursorX, y - LineHeight + 2, size.Width, LineHeight);

                            gfx.DrawString(text, Font, XBrushes.Black, cursorX, y);
                        }

                        cursorX += size.Width;
                    }
                }

                gfx.Restore();
                return;
            }

            // Unchanged
            var wrappedLines = WrapText(gfx, line.Text, Font, width);
            if (rowIndex < wrappedLines.Count)
                gfx.DrawString(wrappedLines[rowIndex], Font, XBrushes.Black, x, y);

            gfx.Restore();
        }


        private static int DrawWrappedModifiedLine(
            PdfDocument doc,
            ref PdfPage page,
            ref XGraphics gfx,
            ref double y,
            DiffPiece line,
            double x,
            double width)
        {
            int rows = 0;
            double cursorX = x;

            EnsurePage(doc, ref page, ref gfx, ref y, LineHeight);

            gfx.Save();
            gfx.IntersectClip(new XRect(x, y - LineHeight + 2, width, LineHeight));

            foreach (var piece in line.SubPieces)
            {
                var text = piece.Text ?? "";
                var words = text.Split(' ');

                foreach (var word in words)
                {
                    var size = gfx.MeasureString(word + " ", Font);

                    if (cursorX + size.Width > x + width)
                    {
                        gfx.Restore();
                        y += LineHeight;
                        rows++;

                        EnsurePage(doc, ref page, ref gfx, ref y, LineHeight);

                        gfx.Save();
                        gfx.IntersectClip(new XRect(x, y - LineHeight + 2, width, LineHeight));
                        cursorX = x;
                    }

                    XBrush background = null;
                    switch (piece.Type)
                    {
                        case ChangeType.Inserted: background = InsertBrush; break;
                        case ChangeType.Deleted: background = DeleteBrush; break;
                        case ChangeType.Modified: background = ModifyBrush; break;
                    }

                    if (background != null)
                    {
                        gfx.DrawRectangle(
                            background,
                            cursorX,
                            y - LineHeight + 2,
                            size.Width,
                            LineHeight);
                    }

                    gfx.DrawString(word + " ", Font, XBrushes.Black, cursorX, y);
                    cursorX += size.Width;
                }
            }

            gfx.Restore();
            y += LineHeight;
            rows++;

            return rows;
        }

        private static int DrawDiffLineWrapped(
            PdfDocument doc,
            ref PdfPage page,
            ref XGraphics gfx,
            ref double y,
            DiffPiece line,
            double x,
            double width)
        {
            if (line == null || string.IsNullOrEmpty(line.Text))
                return 0;

            if (line.Type == ChangeType.Inserted)
            {
                return DrawWrappedWholeLine(doc, ref page, ref gfx, ref y,
                    line.Text, InsertBrush, x, width);
            }

            if (line.Type == ChangeType.Deleted)
            {
                return DrawWrappedWholeLine(doc, ref page, ref gfx, ref y,
                    line.Text, DeleteBrush, x, width);
            }

            if (line.Type == ChangeType.Modified && line.SubPieces != null)
            {
                return DrawWrappedModifiedLine(doc, ref page, ref gfx, ref y, line, x, width);
            }

            // Unchanged
            return DrawWrappedWholeLine(doc, ref page, ref gfx, ref y,
                line.Text, null, x, width);
        }

        private static void EnsurePage(
    PdfDocument doc,
    ref PdfPage page,
    ref XGraphics gfx,
    ref double y,
    double requiredHeight)
        {
            if (y + requiredHeight > page.Height - BottomMargin)
            {
                page = doc.AddPage();
                gfx = XGraphics.FromPdfPage(page);
                y = TopMargin;
            }
        }

        private static void DrawMissingFromOld(
    PdfDocument doc,
    ref PdfPage page,
    ref XGraphics gfx,
    ref double y,
    XFont font,
    Dictionary<string, HL7Data> oldData,
    Dictionary<string, HL7Data> newData)
        {
            var missing = oldData.Keys.Except(newData.Keys).ToList();
            if (!missing.Any()) return;

            EnsurePage(doc, ref page, ref gfx, ref y, 40);

            gfx.DrawString(
                $"There are {missing.Count} items in the old data folder that are not in the new data folder.",
                font, XBrushes.Black, LeftMargin, y);

            y += 20;

            foreach (var key in missing)
            {
                EnsurePage(doc, ref page, ref gfx, ref y, LineHeight);
                gfx.DrawString($"{key} | {oldData[key].fileName}", font, XBrushes.Black, LeftMargin, y);
                y += LineHeight;
            }

            y += 20;
        }


        private static void DrawMissingFromNew(
            PdfDocument doc,
            ref PdfPage page,
            ref XGraphics gfx,
            ref double y,
            XFont font,
            Dictionary<string, HL7Data> oldData,
            Dictionary<string, HL7Data> newData)
        {
            var missing = newData.Keys.Except(oldData.Keys).ToList();
            if (!missing.Any()) return;

            gfx.DrawString(
                $"There are {missing.Count} items in the new data folder that are not in the old data folder.",
                font,
                XBrushes.Black,
                40, y);

            y += 20;

            foreach (var key in missing)
            {
                gfx.DrawString($"{key}  |  {newData[key].fileName}", font, XBrushes.Black, 40, y);
                y += 15;
            }

            y += 20;
        }

        private static void DrawDiffLine(
            XGraphics gfx,
            DiffPiece line,
            double x,
            double y,
            double width)
        {
            if (line == null || string.IsNullOrEmpty(line.Text))
                return;

            var clipRect = new XRect(x, y - LineHeight + 2, width, LineHeight);

            gfx.Save();
            gfx.IntersectClip(clipRect);

            // Whole-line Insert / Delete
            if (line.Type == ChangeType.Inserted || line.Type == ChangeType.Deleted)
            {
                var background = line.Type == ChangeType.Inserted
                    ? InsertBrush
                    : DeleteBrush;

                gfx.DrawRectangle(background, clipRect);
                gfx.DrawString(line.Text, Font, XBrushes.Black, x, y);
                gfx.Restore();
                return;
            }

            // Modified → inline sub-pieces
            if (line.Type == ChangeType.Modified && line.SubPieces != null && line.SubPieces.Any())
            {
                double cursorX = x;

                foreach (var piece in line.SubPieces)
                {
                    var text = piece.Text ?? "";
                    var size = gfx.MeasureString(text, Font);

                    XBrush background = null;
                    switch (piece.Type)
                    {
                        case ChangeType.Inserted: background = InsertBrush; break;
                        case ChangeType.Deleted: background = DeleteBrush; break;
                        case ChangeType.Modified: background = ModifyBrush; break;
                    }

                    if (background != null)
                    {
                        gfx.DrawRectangle(background, cursorX, y - LineHeight + 2, size.Width, LineHeight);
                    }

                    gfx.DrawString(text, Font, XBrushes.Black, cursorX, y);
                    cursorX += size.Width;
                }

                gfx.Restore();
                return;
            }

            // Unchanged
            gfx.DrawString(line.Text, Font, XBrushes.Black, x, y);
            gfx.Restore();
        }


        private static void DrawSideBySideWrappedLine(
            PdfDocument doc,
            ref PdfPage page,
            ref XGraphics gfx,
            ref double y,
            DiffPiece oldLine,
            DiffPiece newLine,
            double xLeft,
            double xRight,
            double width,
            double columnGap)
        {
            // Measure how many wrapped rows are needed
            int leftRows = MeasureWrappedRows(gfx, oldLine, width);
            int rightRows = MeasureWrappedRows(gfx, newLine, width);
            int maxRows = Math.Max(leftRows, rightRows);

            for (int rowIndex = 0; rowIndex < maxRows; rowIndex++)
            {
                EnsurePage(doc, ref page, ref gfx, ref y, LineHeight);

                DrawWrappedRow(gfx, oldLine, rowIndex, xLeft, y, width);
                DrawWrappedRow(gfx, newLine, rowIndex, xRight, y, width);

                y += LineHeight;
            }
        }

        private static void DrawSideBySideDiff(
            PdfDocument doc,
            ref PdfPage page,
            ref XGraphics gfx,
            ref double y,
            SideBySideDiffModel diff)
        {
            double columnGap = 10;
            double columnWidth = (page.Width - LeftMargin * 2 - columnGap) / 2;

            EnsurePage(doc, ref page, ref gfx, ref y, 30);

            gfx.DrawString("Original", FontBold, XBrushes.Black, LeftMargin, y);
            gfx.DrawString("Modified", FontBold, XBrushes.Black,
                LeftMargin + columnWidth + columnGap, y);

            y += 15;

            int maxLines = Math.Max(diff.OldText.Lines.Count, diff.NewText.Lines.Count);

            for (int i = 0; i < maxLines; i++)
            {
                EnsurePage(doc, ref page, ref gfx, ref y, LineHeight);

                var oldLine = i < diff.OldText.Lines.Count ? diff.OldText.Lines[i] : null;
                var newLine = i < diff.NewText.Lines.Count ? diff.NewText.Lines[i] : null;

                DrawSideBySideWrappedLine(
                    doc,
                    ref page,
                    ref gfx,
                    ref y,
                    oldLine,
                    newLine,
                    LeftMargin,
                    LeftMargin + columnWidth + columnGap,
                    columnWidth,
                    columnGap);
            }

            y += 10;
        }



        private static void DrawCommonDiffs(
            PdfDocument doc,
            ref PdfPage page,
            ref XGraphics gfx,
            ref double y,
            Dictionary<string, HL7Data> oldData,
            Dictionary<string, HL7Data> newData,
            HashSet<string>ignoreList)
        {
            foreach (var msgId in oldData.Keys.Intersect(newData.Keys))
            {
                EnsurePage(doc, ref page, ref gfx, ref y, 80);

                gfx.DrawString($"Message ID: {msgId}", FontBold, XBrushes.Black, LeftMargin, y);
                y += 15;

                gfx.DrawString($"Old File: {oldData[msgId].fileName}", Font, XBrushes.Black, LeftMargin, y);
                y += 15;

                gfx.DrawString($"New File: {newData[msgId].fileName}", Font, XBrushes.Black, LeftMargin, y);
                y += 20;

                var differ = new Differ();

                var diffBuilder = new SideBySideDiffBuilder(
                    differ,
                    lineChunker: new LineChunker(),        // normal line splitting
                    wordChunker: new HL7FieldChunker()     // HL7 field-level diff
                );

                var diff = diffBuilder.BuildDiffModel(
                    oldData[msgId].content,
                    newData[msgId].content
                );

                DrawSideBySideDiff(doc, ref page, ref gfx, ref y, diff);
            }
        }

        public static void CreatePdfReport(
           string pdfPath,
           string oldFolder,
           string newFolder,
           HashSet<string>ignoreList,
           HashSet<string>errors)
        {
            var oldData = HL7Data.GetFolderData(oldFolder, ignoreList, errors);
            var newData = HL7Data.GetFolderData(newFolder, ignoreList, errors);

            var document = new PdfDocument();
            document.Info.Title = "HL7 Comparison Report";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            double y = TopMargin;

            DrawMissingFromOld(document, ref page, ref gfx, ref y, Font, oldData, newData);
            DrawMissingFromNew(document, ref page, ref gfx, ref y, Font, oldData, newData);
            DrawCommonDiffs(document, ref page, ref gfx, ref y, oldData, newData, ignoreList);

            document.Save(pdfPath);
        }
    }
}
