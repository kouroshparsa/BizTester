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
        private HashSet<string> columns;

        public FormColumnSelector(HashSet<string> columns)
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
                columns.Remove(listBoxColumns.SelectedIndices[i].ToString());
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
    }
}
