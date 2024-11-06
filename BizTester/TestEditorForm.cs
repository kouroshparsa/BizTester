using BizTester.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BizTester
{
    public partial class TestEditorForm : Form
    {
        TestSpec testSpec;
        string initialTestName;

        public TestEditorForm(string testName, TestSpec testSpec)
        {
            InitializeComponent();
            this.testSpec = testSpec;
            if (testName == null) // we are adding a new test. not modifying
            {
                int ind = 0;
                do
                {
                    ind += 1;
                    testName = $"Test-{ind}";
                } while (testSpec.tests.ContainsKey(testName));
                textBoxTestName.Text = testName;
                initialTestName = testName;
                return;
            }

            textBoxTestName.Text = testName;
            initialTestName = testName;
            if(testSpec != null)
            {
                TestBase testBase = testSpec.tests[testName];
                foreach (var input in testBase.inputs)
                {
                    this.dataGridViewTest.Rows.Add(TestBase.InputDataType, input.protocol, input.GetValue(), input.data_file);
                }
                
                foreach (KeyValuePair<string, TestOutput> entry in testBase.outputs)
                {
                    TestOutput output = entry.Value;
                    this.dataGridViewTest.Rows.Add(TestBase.OutputDataType, output.protocol, output.GetValue(), null, entry.Key);
                }

            }

        }

        private void btnCancelTest_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                if(dataGridViewTest.Rows[e.RowIndex].IsNewRow)
                    MessageBox.Show("Cannot remove uncommitted row.");
                else
                    dataGridViewTest.Rows.RemoveAt(e.RowIndex);
                
            }
        }

        private void dataGridViewTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string dataType = null;
            if (dataGridViewTest.CurrentRow.Cells["DataType"].Value != null)
                dataType = dataGridViewTest.CurrentRow.Cells["DataType"].Value.ToString();

            string protocol = null;
            if (dataGridViewTest.CurrentRow.Cells["Protocol"].Value != null)
                protocol = dataGridViewTest.CurrentRow.Cells["Protocol"].Value.ToString();

            if (e.ColumnIndex == 4 && dataType == TestBase.OutputDataType) {// ValidationSet
                TestOutput testOutput = null;
                if (dataGridViewTest.CurrentRow.Cells["ValidationSet"].Value != null)
                {
                    string uid = dataGridViewTest.CurrentRow.Cells["ValidationSet"].Value.ToString();
                    testOutput = testSpec.tests[initialTestName].outputs[uid];

                }

                if (testOutput == null)
                {
                    if (protocol == null)
                    {
                        MessageBox.Show("Please enter a protocol");
                        return;
                    }

                    string value = null;
                    if (dataGridViewTest.CurrentRow.Cells["Value"].Value != null)
                        value = dataGridViewTest.CurrentRow.Cells["Value"].Value.ToString();

                    if (value == null)
                    {
                        MessageBox.Show("Please enter a value on the third column.");
                        return;
                    }

                    testOutput = new TestOutput(protocol, value, new List<Validation>());

                }
                var form = new ValidationEditorForm(testOutput);
                form.ShowDialog();
                string testName = initialTestName;
                if (initialTestName == null)
                    testName = textBoxTestName.Text;

                if (!this.testSpec.tests.ContainsKey(testName))
                {
                    TestBase testBase = new TestBase();
                    testBase.outputs.Add(testOutput.uid, testOutput);
                    this.testSpec.tests.Add(testName, testBase);
                    dataGridViewTest.CurrentRow.Cells["ValidationSet"].Value = testOutput.uid;
                }
                else if (!this.testSpec.tests[testName].outputs.ContainsKey(testOutput.uid))
                {
                    this.testSpec.tests[testName].outputs.Add(testOutput.uid, testOutput);
                    dataGridViewTest.CurrentRow.Cells["ValidationSet"].Value = testOutput.uid;
                }
                return;

            }else if (e.ColumnIndex == 2 && protocol == Models.Protocol.File)// open folder dialog
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        dataGridViewTest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = fbd.SelectedPath;
                    }
                }
            }
            else if (e.ColumnIndex == 3 && dataType!= TestBase.OutputDataType)// open file dialog
            {
                using (OpenFileDialog of = new OpenFileDialog())
                {
                    if (of.ShowDialog() == DialogResult.OK)
                    {
                        dataGridViewTest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = of.FileName;
                    }
                }
            }
        }

        private void ValidateTestName(string name)
        {
            char[] invalidFileChars = System.IO.Path.GetInvalidFileNameChars();
            foreach (char ch in invalidFileChars)
            {
                if (name.IndexOf(ch) >= 0)
                    throw new Exception($"Invalid name. '{ch}' is not allowed in the test name.");
            }
        }
        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            string newTestName = initialTestName;
            if (newTestName == null)
                newTestName = textBoxTestName.Text;

            if (initialTestName != null && !initialTestName.Equals(textBoxTestName.Text))
            {
                newTestName = textBoxTestName.Text;
                try
                {
                    ValidateTestName(newTestName);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (testSpec.tests.ContainsKey(newTestName)) {
                    MessageBox.Show("Invalid test name. This test name is already used.");
                    return;
                }
                
                testSpec.tests[newTestName] = testSpec.tests[initialTestName];
                testSpec.tests.Remove(initialTestName);
            }

            TestBase testBase = new TestBase();
            
            try
            {
                foreach (DataGridViewRow row in dataGridViewTest.Rows)
                {
                    string dataType = null;
                    if (row.Cells["DataType"].Value != null)
                        dataType = row.Cells["DataType"].Value.ToString();

                    if (dataType == TestBase.InputDataType)
                    {
                        TestInput ti = GetInputsFromCells(row.Cells);
                        testBase.inputs.Add(ti);
                    }
                    else if(dataType == TestBase.OutputDataType)
                    {
                        TestOutput to = GetOutputsFromCells(row.Cells);
                        testBase.outputs.Add(to.uid, to);
                    }
                }

                // validate:
                if (testBase.inputs.Count < 1 | testBase.outputs.Count < 1)
                    throw new Exception("You must have at least one input and one output.");

                if (initialTestName == null)// new test
                {
                    testSpec.tests.Add(newTestName, testBase);
                }
                else
                {
                    var oldTestBase = testSpec.tests[newTestName];
                    oldTestBase.inputs.Clear();
                    oldTestBase.outputs.Clear();
                    oldTestBase.inputs = testBase.inputs;
                    oldTestBase.outputs = testBase.outputs;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            this.Close();
        }

        private TestInput GetInputsFromCells(DataGridViewCellCollection cells)
        {
            if (cells["Value"].Value == null)
                throw new Exception("The input is missing value.");
            if (cells["DataFile"].Value == null)
                throw new Exception("The input is missing data file.");

            string protocol = cells["Protocol"].Value.ToString();
            string value = cells["Value"].Value.ToString();
            string dataFile = cells["DataFile"].Value.ToString();
            return new TestInput(protocol, value, dataFile);
        }

        private TestOutput GetOutputsFromCells(DataGridViewCellCollection cells)
        {
            if (cells["Value"].Value == null)
                throw new Exception("The output is missing value.");
            if (cells["ValidationSet"].Value == null)
                throw new Exception("The input is missing validation set.");

            List<Validation> vals = new List<Validation>();
            string protocol = cells["Protocol"].Value.ToString();
            string value = cells["Value"].Value.ToString();
            string vs = cells["ValidationSet"].Value.ToString();
            string testName = initialTestName;
            if (initialTestName == null)
                testName = textBoxTestName.Text;

            foreach (Validation v in testSpec.tests[testName].outputs[vs].validations)
            {
                vals.Add(v);
            }
            return new TestOutput(protocol, value, vals);//kourosh set val
        }
        private void TestSpecForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewTest_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTest.CurrentRow.Cells["DataType"].Value != null)
            {
                string dataType = dataGridViewTest.CurrentRow.Cells["DataType"].Value.ToString();
                if (dataType.Equals(TestBase.InputDataType))
                {
                    dataGridViewTest.CurrentRow.Cells["ValidationSet"].Value = "";
                    dataGridViewTest.CurrentRow.Cells["ValidationSet"].ReadOnly = true;
                }
                else// output:
                {
                    dataGridViewTest.CurrentRow.Cells["DataFile"].Value = "";
                    dataGridViewTest.CurrentRow.Cells["DataFile"].ReadOnly = true;
                }
            }
        }
    }
}
