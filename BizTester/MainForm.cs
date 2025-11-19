using BizTester.Client;
using BizTester.Libs;
using BizTester.Server;
using System;
using System.IO;
using System.Windows.Forms;
using BizTester.Simulation;
using Newtonsoft.Json;
using BizTester.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace BizTester
{
    public partial class MainForm : Form
    {
        private dynamic listener;
        private dynamic client;
        private CustomLogger logger;
        private SimulationSpec simSpec;
        private TestSpec testSpec;
        private string testPath = null;
        private bool isTestChanged = false;
        public MainForm()
        {
            InitializeComponent();
            dataGridViewMT.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewMT.MultiSelect = false;
            logger = new CustomLogger(dataGridViewMT);
            dataGridViewMT.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.Icon = Properties.Resources.flask_icon;
            this.simSpec = new SimulationSpec();
            this.testSpec = new TestSpec();
            this.comboBoxAckCode.SelectedItem = this.comboBoxAckCode.Items[0];
            try
            {
                this.simSpec.LoadSettingsFromFile();
            }catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Contains("Stop"))// stopping
            {
                btnStart.Text = "Start Listening";
                listener.Stop();
                foreach (Control con in groupBoxServerControls.Controls)
                {
                    con.Enabled = true;
                }
            }
            else// starting
            {
                foreach (Control con in groupBoxServerControls.Controls)
                {
                    if (con.Name != "btnStart")
                        con.Enabled = false;
                }

                try
                {
                    if (radioButtonServerFolder.Checked)
                    {
                        listener = new Folder_Listener(textBoxServerPath.Text, logger);
                    }
                    else if (radioButtonServerMSMQ.Checked)
                    {
                        listener = new MSMQ_Listener(textBoxServerQueue.Text, logger);
                    }
                    else// MLLP
                    {
                        if (textBoxServerPort.Text.Contains(","))
                        {
                            listener = new MLLP_Listener_Array(textBoxServerPort.Text, checkBoxServerAck.Checked, comboBoxAckCode.Text, logger);
                        }
                        else
                        {
                            listener = new MLLP_Listener(textBoxServerPort.Text, checkBoxServerAck.Checked, comboBoxAckCode.Text, logger);
                        }
                    }

                    listener.Start();
                    btnStart.Text = "Stop Listening";
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    btnStart.Text.Contains("Start Listening");
                    foreach (Control con in groupBoxServerControls.Controls)
                    {
                        con.Enabled = true;
                    }
                }


            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(textBoxSourcePath.Text.Length < 1)
            {
                MessageBox.Show("Please enter a file or folder path");
                return;
            }

            string[] files = null;
            int count = 1;
            string data = null;
            if(!int.TryParse(textBoxClientCount.Text, out count))
            {
                MessageBox.Show("Invalid count. It must be an integer.");
                return;
            }

            if (count < 1)
            {
                MessageBox.Show("Invalid count. It must be a positive integer greater than 1.");
                return;
            }

            try
            {
                if (radioButtonGenFromFile.Checked)
                {
                    if (!File.Exists(textBoxSourcePath.Text))
                    {
                        logger.Error("Missing source file path");
                        return;
                    }
                    files = new string[1]{ textBoxSourcePath.Text };

                }else if (radioButtonGenFromFolder.Checked){

                    if (!Directory.Exists(textBoxSourcePath.Text))
                    {
                        logger.Error("Missing source folder path");
                        return;
                    }
                    files = Directory.GetFiles(textBoxSourcePath.Text, "*", SearchOption.AllDirectories);

                }
                
                if (radioButtonClientFiles.Checked)
                {
                    client = new File_Sender(logger, textBoxClientFolder.Text);
                }
                else if (radioButtonClientMLLP.Checked)
                {
                    client = new MLLP_Sender(logger, textBoxClientPort.Text, textBoxClientIP.Text);
                }
                else// MSMQ
                {
                    client = new MSMQ_Sender(logger, textBoxClientQueue.Text);
                }

                if(files != null)
                {
                    foreach (string filePath in files)
                    {
                        for (int counter = 0; counter < count; counter++)
                        {
                            data = HL7Helper.GetMessageFromFile(filePath, simSpec);
                            client.Send(data);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ignore if a column or row header is clicked
            if (e.Button.Equals(MouseButtons.Right) && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];

                    // Here you can do whatever you want with the cell
                    this.dataGridViewMT.CurrentCell = clickedCell;  // Select the clicked cell, for instance

                    // Get mouse position relative to the vehicles grid
                    var relativeMousePosition = dataGridViewMT.PointToClient(Cursor.Position);

                    // Show the context menu
                    this.contextMenuStripMT.Show(dataGridViewMT, relativeMousePosition);
                }
            }
        }

        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            dataGridViewMT.Rows.Clear();
        }

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            if (dataGridViewMT.CurrentCell.Value != null)
            {
                string data = dataGridViewMT.CurrentCell.Value.ToString().Trim();
                Clipboard.SetDataObject(data, false);
            }
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            if (radioButtonGenFromFile.Checked)
            {
                using (OpenFileDialog of = new OpenFileDialog())
                {
                    if (of.ShowDialog() == DialogResult.OK)
                    {
                        textBoxSourcePath.Text = of.FileName;
                    }
                }
            }
            else if (radioButtonGenFromFolder.Checked)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        textBoxSourcePath.Text = fbd.SelectedPath;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select either a file or a folder source.");
            }
            
        }

        private void radioButtonGenFromFile_CheckedChanged(object sender, EventArgs e)
        {

        }
        

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(listener != null)
            {
                listener.Stop();
            }

            if(isTestChanged && testPath != null)
            {
                DialogResult dialogResult = MessageBox.Show($"Do you want to save the automated test before exit?",
                    "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SaveTests(testPath);
                }
            }
        }

        private void btnSimSettings_Click(object sender, EventArgs e)
        {
            var form = new FormSimulationSettings(simSpec);
            form.ShowDialog();
            int x = form.Spec.records.Count;
            this.simSpec = form.Spec;
        }

        private void newTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isTestChanged)
            {
                DialogResult dialogResult = MessageBox.Show($"Do you want to save the previous automated test?",
                    "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SaveTests(textBoxTestSpecPath.Text);
                }
            }
            treeView1.Nodes.Clear();
            textBoxTestSpecPath.Text = "";
            this.testSpec = new TestSpec();
            TreeNodeHelper.Add(treeView1, testSpec);
            isTestChanged = true;
        }

        private void openTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTestSpecFile();
        }

        private void OpenTestSpecFile()
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "Json files (Json)|*.json";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    this.testPath = of.FileName;
                    using (StreamReader file = File.OpenText(of.FileName))
                    {
                        try
                        {
                            this.testSpec = JsonConvert.DeserializeObject<TestSpec>(file.ReadToEnd());
                            TreeNodeHelper.DrawTree(this.treeView1, this.testSpec.tests);
                            this.treeView1.ExpandAll();
                            textBoxTestSpecPath.Text = this.testPath;
                            isTestChanged = false;
                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
            }
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


        private void textBoxTestSpecPath_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxTestSpecPath_MouseClick(object sender, MouseEventArgs e)
        {
            OpenTestSpecFile();
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (testSpec != null)
            {
                TreeNodeHelper.Modify(treeView1, testSpec);
                isTestChanged = true;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNodeHelper.Delete(treeView1, testSpec);
            isTestChanged = true;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNodeHelper.Add(treeView1, testSpec);
            isTestChanged = true;
        }

        private void expandAllNodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        private void saveTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTests(testPath);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Json file|*.json";
            sfd.Title = "Save test file";
            sfd.ShowDialog();

            if (sfd.FileName != "")
            {
                SaveTests(sfd.FileName);
            }
        }

        public void SaveTests(string path)
        {
            if (path == null)
                saveAsToolStripMenuItem_Click(null, null);
            else
                File.WriteAllText(path, JsonConvert.SerializeObject(this.testSpec));

            textBoxTestSpecPath.Text = path;
            isTestChanged = false;
        }
        private void btnRunTests_Click(object sender, EventArgs e)
        {
            if (testSpec == null)
            {
                MessageBox.Show("Please choose the test file to run.");
                return;
            }
            btnRunTests.Enabled = false;
            TestRunner tr = new TestRunner(testSpec, dataGridViewATLogs);
            tr.Run();
            btnRunTests.Enabled = true;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewATLogs.Rows.Clear();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxServerAck_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxAckCode.Enabled = checkBoxServerAck.Checked;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            Excel._Worksheet worksheet = excelApp.ActiveSheet;

            // Add DataGridView column headers to Excel
            for (int i = 1; i < dataGridViewMT.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridViewMT.Columns[i - 1].HeaderText;
            }

            // Add DataGridView rows to Excel
            for (int i = 0; i < dataGridViewMT.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewMT.Columns.Count; j++)
                {
                    var row = dataGridViewMT.Rows[i];
                    var cell = row.Cells[j];
                    if(cell.Value != null) {
                        worksheet.Cells[i + 2, j + 1] = cell.Value.ToString();
                    }
                    
                }
            }

            // Save the Excel file
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                worksheet.SaveAs(saveFileDialog.FileName);
                excelApp.Quit();
                MessageBox.Show("Data Exported Successfully!", "Info");
            }
        }

        private void radioButtonGenFromFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGenFromFolder.Checked)
            {
                textBoxClientCount.Text = "1";
                textBoxClientCount.Enabled = false;
            }
            else
            {
                textBoxClientCount.Enabled = true;
            }
            

        }
        

        private void createReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportController.Create(dataGridViewMT);
        }
    }
}
