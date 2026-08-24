

using System.Drawing;
using System.Windows.Forms;

namespace BizTester.UIHelpers
{
    public class DarkTabControl : TabControl
    {
        public DarkTabControl()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.SizeMode = TabSizeMode.Fixed;

            this.BackColor = Theme.Back;
            this.ForeColor = Theme.Text;

            this.DrawItem -= Tab_DrawItem; // prevent duplicate handler
            this.DrawItem += Tab_DrawItem;

            this.Appearance = TabAppearance.Normal;
            this.SizeMode = TabSizeMode.Fixed;
            this.ItemSize = new Size(120, 30);

            foreach (TabPage page in this.TabPages)
            {
                page.BackColor = Theme.Panel;
                page.ForeColor = Theme.Text;
            }
        }

        private static void Tab_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = sender as TabControl;
            if (tab == null) return;

            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            TabPage page = tab.TabPages[e.Index];

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color bg = selected ? Theme.Panel : Theme.Control;
            Color textColor = Theme.Text;

            using (SolidBrush brush = new SolidBrush(bg))
            {
                g.FillRectangle(brush, rect);
            }

            using (Pen pen = new Pen(Theme.Border))
            {
                g.DrawRectangle(pen, rect);
            }

            TextRenderer.DrawText(
                g,
                page.Text,
                tab.Font,
                rect,
                textColor,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter
            );

            if (selected)
            {
                using (Pen accentPen = new Pen(Theme.Accent, 2))
                {
                    g.DrawLine(accentPen, rect.Left, rect.Bottom - 1, rect.Right, rect.Bottom - 1);
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Completely override background (removes gray strip)
            using (SolidBrush brush = new SolidBrush(Theme.Back))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_ERASEBKGND = 0x0014;

            // Block Windows from painting background (THIS is the key)
            if (m.Msg == WM_ERASEBKGND)
            {
                return;
            }

            base.WndProc(ref m);
        }
    }
}
