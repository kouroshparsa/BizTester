using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizTester
{
    public partial class FormColumnSelector : Form
    {
        private List<string> columns;

        public FormColumnSelector(List<string> columns)
        {
            this.columns = columns;
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
                columns.RemoveAt(i);
                listBoxColumns.Items.RemoveAt(listBoxColumns.SelectedIndices[i]);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text.Contains(" "))
            {
                MessageBox.Show("Invalid name. It should be a valid HL7 field name");
            }
            listBoxColumns.Items.Add(textBoxName.Text);
            columns.Add(textBoxName.Text);
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
                columns[ind] =  listBoxColumns.Items[ind-1].ToString();
                listBoxColumns.Items[ind-1] = temp;
                columns[ind-1] = temp;
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
                columns[ind] = listBoxColumns.Items[ind+1].ToString();
                listBoxColumns.Items[ind + 1] = temp;
                columns[ind + 1] = temp;
                listBoxColumns.ClearSelected();
                listBoxColumns.SelectedIndex = ind + 1;
            }
        }
    }
}
