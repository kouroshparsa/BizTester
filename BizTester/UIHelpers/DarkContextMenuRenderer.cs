using System.Drawing;
using System.Windows.Forms;

namespace BizTester.UIHelpers
{
    public class DarkContextMenuRenderer : ToolStripProfessionalRenderer
    {
        private readonly Color menuBack = Color.FromArgb(45, 45, 48);
        private readonly Color menuBorder = Color.FromArgb(70, 70, 73);
        private readonly Color menuText = Color.FromArgb(235, 235, 235);

        private readonly Color hoverBack = Color.FromArgb(0, 122, 204);
        private readonly Color hoverBorder = Color.FromArgb(0, 122, 204);
        private readonly Color separator = Color.FromArgb(70, 70, 73);

        public DarkContextMenuRenderer()
            : base(new DarkColorTable())
        {
        }

        protected override void OnRenderToolStripBackground(
            ToolStripRenderEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(menuBack))
            {
                e.Graphics.FillRectangle(
                    brush,
                    new Rectangle(Point.Empty, e.ToolStrip.Size));
            }
        }

        protected override void OnRenderToolStripBorder(
            ToolStripRenderEventArgs e)
        {
            using (Pen pen = new Pen(menuBorder))
            {
                Rectangle rect = new Rectangle(
                    0,
                    0,
                    e.ToolStrip.Width - 1,
                    e.ToolStrip.Height - 1);

                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        protected override void OnRenderMenuItemBackground(
            ToolStripItemRenderEventArgs e)
        {
            ToolStripItem item = e.Item;

            if (item.Selected && item.Enabled)
            {
                using (SolidBrush brush = new SolidBrush(hoverBack))
                {
                    e.Graphics.FillRectangle(
                        brush,
                        new Rectangle(
                            2,
                            2,
                            item.Width - 4,
                            item.Height - 4));
                }

                using (Pen pen = new Pen(hoverBorder))
                {
                    e.Graphics.DrawRectangle(
                        pen,
                        new Rectangle(
                            2,
                            2,
                            item.Width - 5,
                            item.Height - 5));
                }
            }
            else
            {
                using (SolidBrush brush = new SolidBrush(menuBack))
                {
                    e.Graphics.FillRectangle(
                        brush,
                        new Rectangle(
                            0,
                            0,
                            item.Width,
                            item.Height));
                }
            }
        }

        protected override void OnRenderItemText(
            ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = e.Item.Enabled
                ? menuText
                : Color.FromArgb(120, 120, 120);

            base.OnRenderItemText(e);
        }

        protected override void OnRenderSeparator(
            ToolStripSeparatorRenderEventArgs e)
        {
            int y = e.Item.Height / 2;

            using (Pen pen = new Pen(separator))
            {
                e.Graphics.DrawLine(
                    pen,
                    8,
                    y,
                    e.Item.Width - 8,
                    y);
            }
        }
    }


    public class DarkColorTable : ProfessionalColorTable
    {
        public override Color MenuBorder
        {
            get { return Color.FromArgb(70, 70, 73); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(0, 122, 204); }
        }

        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(0, 122, 204); }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(0, 122, 204); }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(0, 122, 204); }
        }

        public override Color MenuStripGradientBegin
        {
            get { return Color.FromArgb(45, 45, 48); }
        }

        public override Color MenuStripGradientEnd
        {
            get { return Color.FromArgb(45, 45, 48); }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(45, 45, 48); }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(45, 45, 48); }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return Color.FromArgb(45, 45, 48); }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return Color.FromArgb(45, 45, 48); }
        }

        public override Color SeparatorDark
        {
            get { return Color.FromArgb(70, 70, 73); }
        }

        public override Color SeparatorLight
        {
            get { return Color.FromArgb(70, 70, 73); }
        }
    }
}