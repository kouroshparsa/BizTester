using BizTester.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace BizTester.Helpers
{
    class ReportController
    {

        public static Report CreateReport(DataGridView dataGridViewMT)
        {
            return new Report(dataGridViewMT);
        }


        public static void ExportReport(Report report, string path)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Data");

                // Add DataGridView column headers
                worksheet.Cell(1, 1).Value = "Message ID";
                worksheet.Cell(1, 2).Value = "Acked";
                worksheet.Cell(1, 3).Value = "Received";
                worksheet.Cell(1, 4).Value = "Acked on";
                worksheet.Cell(1, 5).Value = "Received on";

                // Format headers
                var headerRange = worksheet.Range(
                    1,
                    1,
                    1,
                    5);// num of columns

                headerRange.Style.Font.Bold = true;

                // Add rows
                int rowInd = 2;
                foreach(KeyValuePair<string, ReportMsg> kv in report.messages)
                {
                    string msgID = kv.Key;
                    ReportMsg msg = kv.Value;
                    worksheet.Cell(rowInd, 1).Value = msgID;
                    worksheet.Cell(rowInd, 2).Value = msg.ackedOn==null? "No":"Yes";
                    worksheet.Cell(rowInd, 3).Value = msg.receivedOn == null ? "No" : "Yes"; ;
                    worksheet.Cell(rowInd, 4).Value = msg.ackedOn.ToString();
                    worksheet.Cell(rowInd, 5).Value = msg.receivedOn.ToString();
                    rowInd += 1;
                }
                // Automatically adjust column widths
                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(path);
            }


        }


        public static void ExportLogs(DataGridView dataGridViewMT)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 1,
                RestoreDirectory = true,
                DefaultExt = "xlsx",
                AddExtension = true
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;


            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Data");

                // Add DataGridView column headers
                for (int i = 0; i < dataGridViewMT.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value =
                        dataGridViewMT.Columns[i].HeaderText;
                }

                // Format headers
                var headerRange = worksheet.Range(
                    1,
                    1,
                    1,
                    dataGridViewMT.Columns.Count);

                headerRange.Style.Font.Bold = true;

                // Add DataGridView rows
                for (int i = 0; i < dataGridViewMT.Rows.Count; i++)
                {
                    // Skip the empty "new row" at the bottom of the DataGridView
                    if (dataGridViewMT.Rows[i].IsNewRow)
                        continue;

                    for (int j = 0; j < dataGridViewMT.Columns.Count; j++)
                    {
                        var value = dataGridViewMT.Rows[i].Cells[j].Value;

                        if (value != null)
                        {
                            worksheet.Cell(i + 2, j + 1).Value =
                                value.ToString();
                        }
                    }
                }

                // Automatically adjust column widths
                worksheet.Columns().AdjustToContents();

                // Save the Excel file
                workbook.SaveAs(saveFileDialog.FileName);
            }


        }

    }
}