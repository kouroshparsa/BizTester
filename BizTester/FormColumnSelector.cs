using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BizTester
{
    public partial class FormColumnSelector : Form
    {

        public FormColumnSelector(List<string> columns)
        {
            InitializeComponent();
            foreach (string item in columns)
            {
                listBoxColumns.Items.Add(item);
            }
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = listBoxColumns.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listBoxColumns.Items.RemoveAt(listBoxColumns.SelectedIndices[i]);
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
            listBoxColumns.Items.Add(textBoxName.Text);
        }

        public List<string> GetColumns()
        {
            return listBoxColumns.Items.Cast<string>().ToList();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if(listBoxColumns.SelectedIndices.Count == 1 && listBoxColumns.SelectedIndices[0] > 0)
            {
                int ind = listBoxColumns.SelectedIndices[0];
                string temp = listBoxColumns.Items[ind].ToString();
                listBoxColumns.Items[ind] = listBoxColumns.Items[ind-1].ToString();
                listBoxColumns.Items[ind-1] = temp;
                listBoxColumns.SelectedIndex = listBoxColumns.SelectedIndices[0] - 1;
                listBoxColumns.ClearSelected();
                listBoxColumns.SelectedIndex = ind -1;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (listBoxColumns.SelectedIndices.Count == 1 && listBoxColumns.SelectedIndices[0] < listBoxColumns.Items.Count-1)
            {
                int ind = listBoxColumns.SelectedIndices[0];
                string temp = listBoxColumns.Items[ind].ToString();
                listBoxColumns.Items[ind] = listBoxColumns.Items[ind+1].ToString();
                listBoxColumns.Items[ind + 1] = temp;
                listBoxColumns.ClearSelected();
                listBoxColumns.SelectedIndex = ind + 1;
            }
        }
    }
}
