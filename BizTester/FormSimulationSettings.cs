using System;
using System.Windows.Forms;
using BizTester.Simulation;
using System.IO;

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
                dataGridViewOverwrites.Rows.Clear();
                spec.LoadSettingsFromFile();
                foreach (var record in spec.records)
                {
                    dataGridViewOverwrites.Rows.Add(record.Field, record.Value, record.Description);
                }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SaveSettingsToFile()
        {
            if(textBoxSourceFilePath.Text.Length < 1)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "CSV|*.csv";
                saveFileDialog1.Title = "Save Settings File";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName == "")
                {
                    throw new Exception("Aborted since you did not specify where to save the settings.");
                }

                textBoxSourceFilePath.Text = saveFileDialog1.FileName;
            }
            this.spec = new SimulationSpec();
            this.spec.settingsPath = textBoxSourceFilePath.Text;
            using (StreamWriter outputFile = new StreamWriter(textBoxSourceFilePath.Text))
            {
                outputFile.WriteLine("Field,Value,Description");
                foreach (DataGridViewRow row in dataGridViewOverwrites.Rows)
                {
                    if (row.Cells[0].Value != null &&
                        row.Cells[0].Value.ToString().Length > 0)
                    {
                        string field = row.Cells[0].Value.ToString();
                        string val = "";
                        if(row.Cells[1].Value != null)
                            val = row.Cells[1].Value.ToString();

                        string description = "";
                        if (row.Cells[2].Value != null && row.Cells[2].Value.ToString().Length > 0)
                        {
                            description = row.Cells[2].Value.ToString();
                        }
                        outputFile.WriteLine($"{field},{val},{description}");
                        spec.records.Add(new SimulationSpec.Record(field, val, description));
                    }
                }
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettingsToFile();
                MessageBox.Show("Saved successfully.");
                this.Close();
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
                    LoadSettings();
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
        }

        private void LoadSettings()
        {
            if (spec == null)
                spec = new SimulationSpec();

            spec.settingsPath = textBoxSourceFilePath.Text;
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
                this.dataGridViewOverwrites.CurrentCell = clickedCell;  // Select the clicked cell, for instance

                // Get mouse position relative to the vehicles grid
                var relativeMousePosition = dataGridViewOverwrites.PointToClient(Cursor.Position);

                // Show the context menu
                this.contextMenuStripSimulationDataGrid.Show(dataGridViewOverwrites, relativeMousePosition);

            }
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = dataGridViewOverwrites.SelectedRows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow selectedRow = dataGridViewOverwrites.SelectedRows[i];

                if (!selectedRow.IsNewRow)
                {
                    dataGridViewOverwrites.Rows.RemoveAt(selectedRow.Index);
                }
            }

        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewOverwrites.Rows.Clear();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            var form = new SimulationSettingsHelpForm();
            form.ShowDialog();
        }

        private void textBoxSourceFilePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && textBoxSourceFilePath.Text.Length > 0)
            {
                LoadSettings();
            }
        }
    }       
}
