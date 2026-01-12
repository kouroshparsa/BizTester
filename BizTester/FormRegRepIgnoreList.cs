using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BizTester
{
    public partial class FormRegRepIgnoreList : Form
    {
        public HashSet<string> fields;

        public FormRegRepIgnoreList(HashSet<string> fields)
        {
            this.fields = fields;
            InitializeComponent();
            foreach (string item in fields)
            {
                listBoxFields.Items.Add(item);
            }
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var itemsToDelete = new List<string>();
            foreach(var item in listBoxFields.SelectedItems)
            {
                itemsToDelete.Add(item.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(textBoxName.Text.Contains(" "))
            {
                MessageBox.Show("Invalid name. It should be a valid HL7 field name");
            }
            listBoxFields.Items.Add(textBoxName.Text);
            fields.Add(textBoxName.Text);
        }
        
        
    }
}
