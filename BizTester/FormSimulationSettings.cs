using System;
using System.Windows.Forms;
using BizTester.Simulation;
using System.IO;
using BizTester.Libs;

namespace BizTester
{
    public partial class FormSimulationSettings : Form
    {
        private int rowIndex = -1;
        private class Record
        {
            public string field = null;
            public string value = null;
            public string description = null;
            public Record(string field, string value)
            {
                this.field = field;
                this.value = value;
            }
        }
        private SimulationSpec spec;
        public SimulationSpec Spec
        {
            get { return spec; }
            set
            {
                spec = value;
                textBoxSourceFilePath.Text = value.settingsPath;
                LoadDataIntoDataGrid();
            }
        }

        private void LoadDataIntoDataGrid()
        {
            try
            {
                dataGridView1.Rows.Clear();
                spec.LoadSettingsFromFile();
                foreach (var record in spec.records)
                {
                    dataGridView1.Rows.Add(record.Field, record.Value, record.Description);
                }
                richTextBoxSample.Text = spec.sampleData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public FormSimulationSettings(SimulationSpec _spec)
        {
            InitializeComponent();
            if (_spec == null)
            {
                this.spec = new SimulationSpec();
            }
            else
            {
                this.spec = _spec;
            }

            textBoxSourceFilePath.Text = spec.settingsPath;
            LoadDataIntoDataGrid();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SaveSettingsToFile()
        {
            this.spec = new SimulationSpec();
            this.spec.settingsPath = textBoxSourceFilePath.Text;
            this.spec.sampleData = richTextBoxSample.Text;
            using (StreamWriter outputFile = new StreamWriter(textBoxSourceFilePath.Text))
            {
                outputFile.WriteLine("Field,Value,Description");
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null &&
                        row.Cells[0].Value.ToString().Length > 0 &&
                        row.Cells[1].Value.ToString().Length > 0)
                    {
                        string field = row.Cells[0].Value.ToString();
                        string val = row.Cells[1].Value.ToString();
                        string description = "";
                        if (row.Cells[2].Value != null && row.Cells[2].Value.ToString().Length > 0)
                        {
                            description = row.Cells[2].Value.ToString();
                        }
                        outputFile.WriteLine($"{field},{val},{description}");
                        this.spec.records.Add(new SimulationSpec.Record(field, val, description));
                    }
                }

                outputFile.WriteLine("---");
                outputFile.WriteLine(this.spec.sampleData);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettingsToFile();
                MessageBox.Show("Saved successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnFileDialog_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    textBoxSourceFilePath.Text = of.FileName;
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (spec == null)
                spec = new SimulationSpec();

            spec.settingsPath = textBoxSourceFilePath.Text;
            richTextBoxSample.Text = spec.sampleData;
            LoadDataIntoDataGrid();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ignore if a column or row header is clicked
            if (e.Button.Equals(MouseButtons.Right) && e.RowIndex != -1 && e.Button == MouseButtons.Right)
            {
                DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[0];
                this.rowIndex = e.RowIndex;

                // Here you can do whatever you want with the cell
                this.dataGridView1.CurrentCell = clickedCell;  // Select the clicked cell, for instance

                // Get mouse position relative to the vehicles grid
                var relativeMousePosition = dataGridView1.PointToClient(Cursor.Position);

                // Show the context menu
                this.contextMenuStripSimulationDataGrid.Show(dataGridView1, relativeMousePosition);

            }
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.rowIndex >= 0 && !this.dataGridView1.Rows[this.rowIndex].IsNewRow)
            {
                this.dataGridView1.Rows.RemoveAt(this.rowIndex);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxSample.Clear();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxSample.Text = Clipboard.GetText();
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    richTextBoxSample.Text = HL7Helper.GetMessageFromFile(of.FileName);
                }
            }
        }
    }       
}
