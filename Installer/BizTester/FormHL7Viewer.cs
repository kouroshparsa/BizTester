using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BizTester
{
    public partial class FormHL7Viewer : Form
    {
        /* If you are not applying Theme
        private Color BlankColor = Color.White;
        private Color SelectedLineColor = Color.LightYellow;
        private Color SelectedFieldColor = Color.Orange;
        private Color SelectColor = Color.LightBlue;
        */

        private readonly Color BlankColor = Color.Black;
        private readonly Color SelectedLineColor = Color.Brown;
        private readonly Color SelectedFieldColor = Color.DarkGreen;
        private readonly Color SelectColor = Color.LightBlue;

        private const int EM_GETSCROLLPOS = 0x04DD;
        private const int EM_SETSCROLLPOS = 0x04DE;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            int Msg,
            IntPtr wParam,
            ref Point lParam);

        public FormHL7Viewer(string content)
        {
            InitializeComponent();
            this.richTextBox1.Text = content;
            richTextBox1.MouseUp += RichTextBox1_SelectionChanged;
        }

        private void RichTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            int caretIndex = richTextBox1.SelectionStart;

            int lineInd = richTextBox1.GetLineFromCharIndex(caretIndex);
            string line = richTextBox1.Lines[lineInd];
            int column = caretIndex - richTextBox1.GetFirstCharIndexOfCurrentLine();

            try
            {
                Highlight();
                textBoxHL7Path.Text = GetHL7Path(line, column, caretIndex);
            }
            catch
            {
                textBoxHL7Path.Text = "";
            }
            richTextBox1.SelectionBackColor = SelectColor;
        }

        private void Highlight()
        {
            int originalSelectionStart = richTextBox1.SelectionStart;
            int originalSelectionLength = richTextBox1.SelectionLength;

            // Save actual scroll position
            Point scrollPos = Point.Empty;

            SendMessage(
                richTextBox1.Handle,
                EM_GETSCROLLPOS,
                IntPtr.Zero,
                ref scrollPos);

            int lineIndex = richTextBox1.GetLineFromCharIndex(originalSelectionStart);
            int lineStart = richTextBox1.GetFirstCharIndexFromLine(lineIndex);

            int lineLength = richTextBox1.Lines[lineIndex].Length;

            // Clear previous formatting
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = BlankColor;

            // Apply highlight to the current line
            richTextBox1.Select(lineStart, lineLength);
            richTextBox1.SelectionBackColor = SelectedLineColor;

            // Apply highlight for the field:
            int fieldEnd = originalSelectionStart;
            while(fieldEnd < richTextBox1.Text.Length)
            {
                char c = richTextBox1.Text[fieldEnd];
                if (c == '|' || c == '^' || c == '~' || c == '\r' || c == '\n')
                    break;
                fieldEnd += 1;
            }
            int fieldStart = originalSelectionStart - 1;
            while (fieldStart > 0)
            {
                char c = richTextBox1.Text[fieldStart];
                if (c == '|' || c == '^' || c == '~' || c == '\r' || c == '\n')
                    break;

                fieldStart--;
            }
            if (fieldStart > 0)
                fieldStart += 1;
            richTextBox1.Select(fieldStart, fieldEnd- fieldStart);
            richTextBox1.SelectionBackColor = SelectedFieldColor;

            // Restore caret/selection
            richTextBox1.Select(
                originalSelectionStart,
                originalSelectionLength);

            // Restore exact scroll position
            SendMessage(
                richTextBox1.Handle,
                EM_SETSCROLLPOS,
                IntPtr.Zero,
                ref scrollPos);
        }

        private string GetHL7Path(string line, int column, int caretIndex)
        {
            string segName = line.Split('|')[0];
            int fieldNum = line.Take(column).Count(c => c == '|');
            if (fieldNum == 0)
                return segName;

            if (segName == "MSH")
                fieldNum += 1;

            int repetitions = 1;
            int subfield = 1;
            int fieldStart = caretIndex - 1;
            while (fieldStart > 0)
            {
                char c = richTextBox1.Text[fieldStart];
                if (c == '|' || c == '\r' || c == '\n')
                    break;

                if (c == '~')
                    repetitions += 1;
                else if (c == '^' && repetitions == 1)
                    subfield += 1;
                fieldStart--;
            }

            string res = $"{segName}-{fieldNum}";
            if (subfield > 1)
                res = $"{res}.{subfield}";

            if(repetitions>1)
                res = $"{res}[{repetitions}]";
            return res;
        }
    }
}
