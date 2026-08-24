using System;
using System.Windows.Forms;
using System.IO;
using BizTester.Transformer;

namespace BizTester
{
    public partial class FormTransformerSettings : Form
    {

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
        
        private TransformationSpec spec;
        public TransformationSpec Spec
        {
            get { return spec; }
            set
            {
                spec = value;
                textBoxTransformationSourceFilePath.Text = value.settingsPath;
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
        public FormTransformerSettings(TransformationSpec _spec)
        {
            InitializeComponent();
            if (_spec == null)
            {
                this.spec = new TransformationSpec();
            }
            else
            {
                this.spec = _spec;
            }

            textBoxTransformationSourceFilePath.Text = spec.settingsPath;
            LoadDataIntoDataGrid();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SaveSettingsToFile()
        {
            if(textBoxTransformationSourceFilePath.Text.Length < 1)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "CSV|*.csv";
                saveFileDialog1.Title = "Save Settings File";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName == "")
                {
                    throw new Exception("Aborted since you did not specify where to save the settings.");
                }

                textBoxTransformationSourceFilePath.Text = saveFileDialog1.FileName;
            }
            this.spec = new TransformationSpec();
            this.spec.settingsPath = textBoxTransformationSourceFilePath.Text;
            using (StreamWriter outputFile = new StreamWriter(textBoxTransformationSourceFilePath.Text))
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
                        spec.records.Add(new TransformationSpec.Record(field, val, description));
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
                    textBoxTransformationSourceFilePath.Text = of.FileName;
                    LoadSettings();
                }
            }
        }
        
        private void LoadSettings()
        {
            if (spec == null)
                spec = new TransformationSpec();

            spec.settingsPath = textBoxTransformationSourceFilePath.Text;
            LoadDataIntoDataGrid();
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewOverwrites.SelectedRows.Count == 0)
                MessageBox.Show("You have not selected any rows. Make sure you select the whole row.");

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
            var form = new FormTransformerSettingsHelp();
            form.ShowDialog();
        }

        private void textBoxSourceFilePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && textBoxTransformationSourceFilePath.Text.Length > 0)
            {
                LoadSettings();
            }
        }

        private void textBoxSourceFilePath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TransformationSourceFilePathValue = textBoxTransformationSourceFilePath.Text;
            Properties.Settings.Default.Save();
        }
    }       
}
