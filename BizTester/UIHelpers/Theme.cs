using System;
using System.Drawing;
using System.Windows.Forms;

namespace BizTester.UIHelpers
{
    public static class Theme
    {
        // Colors
        public static Color Back = Color.FromArgb(30, 30, 30);
        public static Color Panel = Color.FromArgb(45, 45, 48);
        public static Color Control = Color.FromArgb(37, 37, 38);
        public static Color Border = Color.FromArgb(70, 70, 70);
        public static Color Text = Color.White;
        public static Color Accent = Color.FromArgb(0, 122, 204);
        public static Font DefaultFont = new Font("Segoe UI", 9F, FontStyle.Regular);
        public static Font BoldFont = new Font("Segoe UI", 9F, FontStyle.Bold);
        public static Font HeaderFont = new Font("Segoe UI", 11F, FontStyle.Bold);
        // Entry point
        public static void ApplyTheme(Control parent)
        {
            if (parent == null) return;

            parent.BackColor = Back;
            parent.ForeColor = Text;
            ApplyToChildren(parent);
        }

        private static void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            if (box == null) return;

            Graphics g = e.Graphics;
            g.Clear(Theme.Back);

            Size textSize = TextRenderer.MeasureText(box.Text, box.Font);

            int textX = 8;
            int textY = 0;
            int borderY = textSize.Height / 2;

            using (Pen pen = new Pen(Theme.Border))
            {
                // Left top line
                g.DrawLine(pen, 0, borderY, textX - 2, borderY);

                // Right top line
                g.DrawLine(pen, textX + textSize.Width + 2, borderY, box.Width - 1, borderY);

                // Left side
                g.DrawLine(pen, 0, borderY, 0, box.Height - 1);

                // Right side
                g.DrawLine(pen, box.Width - 1, borderY, box.Width - 1, box.Height - 1);

                // Bottom
                g.DrawLine(pen, 0, box.Height - 1, box.Width - 1, box.Height - 1);
            }

            using (Brush brush = new SolidBrush(Theme.Text))
            {
                g.DrawString(box.Text, box.Font, brush, textX, textY);
            }
        }

        // Recursive application
        private static void ApplyToChildren(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.ForeColor = Text;
                
                // Panel
                Panel panel = ctrl as Panel;
                if (panel != null)
                {
                    panel.BackColor = Panel;
                }

                // GroupBox
                GroupBox group = ctrl as GroupBox;
                if (group != null)
                {
                    group.BackColor = Back;
                    group.ForeColor = Text;
                    group.Paint -= GroupBox_Paint;
                    group.Paint += GroupBox_Paint;
                }

                // TabControl
                TabControl tab = ctrl as TabControl;
                if (tab != null)
                {
                    StyleTabControl(tab);
                }

                // Button
                Button btn = ctrl as Button;
                if (btn != null)
                {
                    btn.BackColor = Accent;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                }

                // TextBox
                TextBox txt = ctrl as TextBox;
                if (txt != null)
                {
                    txt.BackColor = Control;
                    txt.ForeColor = Text;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }

                // ComboBox
                ComboBox cmb = ctrl as ComboBox;
                if (cmb != null)
                {
                    cmb.BackColor = Control;
                    cmb.ForeColor = Text;
                    cmb.FlatStyle = FlatStyle.Flat;
                }

                // DataGridView
                DataGridView dgv = ctrl as DataGridView;
                if (dgv != null)
                {
                    StyleGrid(dgv);
                }

                Label lbl = ctrl as Label;
                if (lbl != null)
                {
                    lbl.ForeColor = Theme.Text;
                    lbl.BackColor = Color.Transparent;
                    lbl.AutoSize = true;
                    lbl.UseCompatibleTextRendering = true; // smoother text
                }

                // Default fallback
                if (!(ctrl is Button) &&
                !(ctrl is TextBox) &&
                !(ctrl is ComboBox) &&
                !(ctrl is DataGridView))
                {
                    ctrl.BackColor = Theme.Back;
                }

                // Recursive call
                if (ctrl.HasChildren)
                {
                    ApplyToChildren(ctrl);

                    CheckBox chk = ctrl as CheckBox;
                    if (chk != null)
                    {
                        chk.ForeColor = chk.Enabled ? Theme.Text : Color.Gray;
                    }

                    RadioButton radio = ctrl as RadioButton;
                    if (radio != null)
                    {
                        radio.ForeColor = radio.Enabled ? Theme.Text : Color.Gray;
                    }
                }
            }
        }

        // DataGrid styling
        private static void StyleGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Panel;
            dgv.BorderStyle = BorderStyle.None;

            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Back;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Text;

            dgv.DefaultCellStyle.BackColor = Panel;
            dgv.DefaultCellStyle.ForeColor = Text;

            dgv.RowHeadersDefaultCellStyle.BackColor = Theme.Panel;
            dgv.RowHeadersDefaultCellStyle.ForeColor = Theme.Text;

            dgv.RowsDefaultCellStyle.BackColor = Theme.Panel;

            // Fix empty area below rows
            dgv.DefaultCellStyle.SelectionBackColor = Theme.Accent;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Control;

            dgv.GridColor = Border;

            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.RowTemplate.Height = 24;

            // Don't let the grid itself be clipped by a fixed layout
            dgv.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right;
        }

        // TabControl styling
        private static void StyleTabControl(TabControl tab)
        {
            tab.DrawMode = TabDrawMode.OwnerDrawFixed;
            tab.BackColor = Back;
            tab.ForeColor = Text;

            tab.DrawItem -= Tab_DrawItem; // prevent duplicate handler
            tab.DrawItem += Tab_DrawItem;

            tab.Appearance = TabAppearance.Normal;
            tab.SizeMode = TabSizeMode.Fixed;
            tab.ItemSize = new Size(120, 30);

            foreach (TabPage page in tab.TabPages)
            {
                page.BackColor = Panel;
                page.ForeColor = Text;
            }
        }

        // Custom tab drawing
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

        public static void ApplyContextMenuTheme(ContextMenuStrip contextMenu)
        {
            if (contextMenu == null)
                return;

            contextMenu.Renderer = new DarkContextMenuRenderer();

            contextMenu.BackColor = Color.FromArgb(45, 45, 48);
            contextMenu.ForeColor = Color.FromArgb(235, 235, 235);

            contextMenu.Font = new Font(
                "Segoe UI",
                9F,
                FontStyle.Regular);

            contextMenu.ShowImageMargin = false;
            contextMenu.ShowCheckMargin = false;

            contextMenu.Padding = new Padding(4, 5, 4, 5);

            foreach (ToolStripItem item in contextMenu.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    item.Padding = new Padding(8, 6, 8, 6);
                }
            }
        }
    }
}
