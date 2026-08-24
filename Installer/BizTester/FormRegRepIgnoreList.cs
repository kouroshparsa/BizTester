using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BizTester
{
    public partial class FormRegRepIgnoreList : Form
    {
        public FormRegRepIgnoreList(HashSet<string> fields)
        {
            InitializeComponent();
            foreach (string item in fields)
            {
                listBoxFields.Items.Add(item);
            }
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = listBoxFields.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = listBoxFields.SelectedIndices[i];
                listBoxFields.Items.RemoveAt(index);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^[A-Z][A-Z][A-Z,1-9]\-\d+((\.\d+)*)$");
            if (textBoxName.Text.Length < 1 || textBoxName.Text.Contains(" ") || !regex.Match(textBoxName.Text).Success)
            {
                MessageBox.Show("Invalid name. It should be a valid HL7 field or sub-field name");
                return;
            }

            listBoxFields.Items.Add(textBoxName.Text);
        }

        internal HashSet<string> GetIgnoreList()
        {
            return new HashSet<string>(listBoxFields.Items.Cast<string>());
        }
    }
}
