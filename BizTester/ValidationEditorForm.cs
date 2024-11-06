using BizTester.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BizTester
{
    public partial class ValidationEditorForm : Form
    {
        public TestOutput testOutput;

        public ValidationEditorForm(TestOutput testOutput)
        {
            InitializeComponent();
            this.testOutput = testOutput;
            foreach (Validation val in testOutput.validations)
            {
                dataGridViewValidations.Rows.Add(val.data_type, val.path, val.expectedResult);
            }

        }

        private void btnCancelTest_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                if(dataGridViewValidations.Rows[e.RowIndex].IsNewRow)
                    MessageBox.Show("Cannot remove uncommitted row.");
                else
                    dataGridViewValidations.Rows.RemoveAt(e.RowIndex);
                
            }
        }

        private void dataGridViewTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            try
            {
                this.testOutput.validations.Clear();
                foreach (DataGridViewRow row in dataGridViewValidations.Rows)
                {
                    string dataType = null;
                    string path = null;
                    string value = null;

                    if (row.Cells[0].Value != null &&
                        row.Cells[1].Value != null &&
                        row.Cells[2].Value != null)
                    {
                        dataType = row.Cells[0].Value.ToString();
                        path = row.Cells[1].Value.ToString();
                        value = row.Cells[2].Value.ToString();
                        this.testOutput.validations.Add(new Validation(dataType, path, value));
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            this.Close();
        }

        private void TestSpecForm_Load(object sender, EventArgs e)
        {

        }
    }
}
