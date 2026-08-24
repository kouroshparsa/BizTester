namespace BizTester.UIHelpers
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class RoundedButton : Button
    {
        public int BorderRadius { get; set; } = 10;
        private Color hoverColor;
        private Color pressedColor;
        public static Color Accent = Color.FromArgb(0, 122, 204);
        private Color baseColor = Theme.Accent;

        public RoundedButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            this.BackColor = baseColor;
            this.ForeColor = Color.White;

            this.Font = Theme.DefaultFont;

            this.Cursor = Cursors.Hand;

            // Subtle color variations
            hoverColor = ControlPaint.Light(baseColor, 0.1f);
            pressedColor = ControlPaint.Dark(baseColor, 0.1f);

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.None;

            Rectangle rect = this.ClientRectangle;

            // Fill background
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                g.FillRectangle(brush, rect);
            }

            // Optional subtle border (VS Code sometimes uses this)
            using (Pen pen = new Pen(Color.FromArgb(60, 60, 60)))
            {
                g.DrawRectangle(pen, 0, 0, rect.Width - 1, rect.Height - 1);
            }

            // Text (clean rendering)
            TextRenderer.DrawText(
                g,
                this.Text,
                this.Font,
                rect,
                this.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            float r = radius;
            float d = r * 2;

            path.StartFigure();

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);

            path.CloseFigure();

            return path;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = hoverColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = baseColor;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            this.BackColor = pressedColor;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            this.BackColor = hoverColor;
        }
    }
}
