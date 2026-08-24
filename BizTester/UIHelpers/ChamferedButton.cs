using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BizTester.UIHelpers
{
    public class ChamferedButton : Button
    {
        public int ChamferSize { get; set; } = 8;

        public ChamferedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Theme.Accent;
            this.ForeColor = Color.White;
            this.Padding = new Padding(10, 0, 10, 0);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            this.Resize += (s, e) => this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle rect = this.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            using (GraphicsPath path = GetChamferedPath(rect, ChamferSize))
            {
                // Fill
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Optional border (recommended for sharp look)
                using (Pen pen = new Pen(Theme.Border))
                {
                    e.Graphics.DrawPath(pen, path);
                }

                // Clickable region
                this.Region = new Region(path);
            }

            // Text rendering (cleaner)
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using (Brush textBrush = new SolidBrush(this.ForeColor))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                e.Graphics.DrawString(this.Text, this.Font, textBrush, rect, sf);
            }
        }

        private GraphicsPath GetChamferedPath(Rectangle rect, int c)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            path.AddLine(rect.Left + c, rect.Top, rect.Right - c, rect.Top);
            path.AddLine(rect.Right - c, rect.Top, rect.Right, rect.Top + c);
            path.AddLine(rect.Right, rect.Top + c, rect.Right, rect.Bottom - c);
            path.AddLine(rect.Right, rect.Bottom - c, rect.Right - c, rect.Bottom);
            path.AddLine(rect.Right - c, rect.Bottom, rect.Left + c, rect.Bottom);
            path.AddLine(rect.Left + c, rect.Bottom, rect.Left, rect.Bottom - c);
            path.AddLine(rect.Left, rect.Bottom - c, rect.Left, rect.Top + c);
            path.AddLine(rect.Left, rect.Top + c, rect.Left + c, rect.Top);

            path.CloseFigure();

            return path;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = ControlPaint.Light(Theme.Accent);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = Theme.Accent;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            this.BackColor = ControlPaint.Dark(Theme.Accent);
        }

    }
}
