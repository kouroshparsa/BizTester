using BizTester.Client;
using BizTester.Helpers;
using BizTester.Server;
using System;
using System.IO;
using System.Windows.Forms;
using BizTester.Simulation;
using Newtonsoft.Json;
using BizTester.Models;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing;

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
        private string[] selectedClientFiles;
        private HashSet<string> columns = new HashSet<string>();

        public MainForm()
        {
            InitializeComponent();
            dataGridViewMT.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewMT.MultiSelect = false;
            logger = new CustomLogger(dataGridViewMT, columns);
            dataGridViewMT.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewMT.AllowUserToOrderColumns = true;

            comboBoxDllFolder.SelectedIndex = 0;

            dataGridViewMapTestResult.CellFormatting += dataGridViewMapTestResult_CellFormatting;

            this.Icon = Properties.Resources.flask_icon;
            this.simSpec = new SimulationSpec();
            this.testSpec = new TestSpec();
            this.comboBoxAckCode.SelectedItem = this.comboBoxAckCode.Items[0];
            UpdateServerOptions();
            ToolTip toolTipServerPort = new ToolTip();
            toolTipServerPort.SetToolTip(textBoxServerPort, "You can enter multiple ports by separating them by comma");

            UpdateClientOptions();
            ToolTip toolTipClientPort = new ToolTip();
            toolTipClientPort.SetToolTip(textBoxClientPort, "You can enter multiple ports by separating them by comma");
            
            ToolTip toolTipClientIP = new ToolTip();
            toolTipClientIP.SetToolTip(textBoxClientIP, "This is optional. If blank, it will send it to the local server.");

            ToolTip toolTipClientCount = new ToolTip();
            toolTipClientCount.SetToolTip(textBoxClientCount, "Here you can specify a number if you want to send a message several times.");

            columns.Add("MSH-9.1");
            columns.Add("MSH-9.2");
            columns.Add("MSH-10");
            UpdateColumns();

            
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
                UpdateServerOptions();
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
            if (Directory.Exists(textBoxSourcePath.Text))
            {
                selectedClientFiles = Directory.GetFiles(textBoxSourcePath.Text);
            }
            else if (File.Exists(textBoxSourcePath.Text))
            {
                selectedClientFiles = new string[] { textBoxSourcePath.Text  };
            }

            if (selectedClientFiles.Length < 1)
            {
                MessageBox.Show("Please enter a file or folder path");
                return;
            }

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
                if (selectedClientFiles == null || selectedClientFiles.Length < 1)
                {
                    logger.Error("Missing source file path");
                    return;
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

                foreach (string filePath in selectedClientFiles)
                {
                    for (int counter = 0; counter < count; counter++)
                    {
                        data = HL7Helper.GetMessageFromFile(filePath, simSpec);
                        client.Send(data);
                    }
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
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
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Multiselect = true;
                if (of.ShowDialog() == DialogResult.OK)
                {
                    selectedClientFiles = of.FileNames;
                    if(selectedClientFiles.Length == 1)
                    {
                        textBoxSourcePath.Text = selectedClientFiles[0];
                    }else
                    {
                        textBoxSourcePath.Text = $"{selectedClientFiles.Length} files selected";
                    }
                    
                }
            }

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
       

        private void createReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReportController.Create(dataGridViewMT);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Failed to create report. {ex.Message} {ex.StackTrace}");
            }
        }

        private void radioButtonServerFolder_CheckedChanged(object sender, EventArgs e)
        {
            UpdateServerOptions();
        }


        private void radioButtonServerMSMQ_CheckedChanged(object sender, EventArgs e)
        {
            UpdateServerOptions();
        }

        private void radioButtonServerMLLP_CheckedChanged(object sender, EventArgs e)
        {
            UpdateServerOptions();
        }
        private void UpdateServerOptions()
        {
            if (radioButtonServerFolder.Checked)
            {
                textBoxServerPath.Enabled = true;
                textBoxServerQueue.Enabled = false;
                textBoxServerPort.Enabled = false;
            }
            else if (radioButtonServerMSMQ.Checked)
            {
                textBoxServerPath.Enabled = false;
                textBoxServerQueue.Enabled = true;
                textBoxServerPort.Enabled = false;
            }
            else if (radioButtonServerMLLP.Checked)
            {
                textBoxServerPath.Enabled = false;
                textBoxServerQueue.Enabled = false;
                textBoxServerPort.Enabled = true;
            }
        }

        private void UpdateClientOptions()
        {
            if (radioButtonClientFiles.Checked)
            {
                textBoxClientFolder.Enabled = true;
                textBoxClientQueue.Enabled = false;
                textBoxClientPort.Enabled = false;
                textBoxClientIP.Enabled = false;
            }
            else if (radioButtonClientMSMQ.Checked)
            {
                textBoxClientFolder.Enabled = false;
                textBoxClientQueue.Enabled = true;
                textBoxClientPort.Enabled = false;
                textBoxClientIP.Enabled = false;
            }
            else if (radioButtonClientMLLP.Checked)
            {
                textBoxClientFolder.Enabled = false;
                textBoxClientQueue.Enabled = false;
                textBoxClientPort.Enabled = true;
                textBoxClientIP.Enabled = true;
            }
        }

        private void radioButtonClientFiles_CheckedChanged(object sender, EventArgs e)
        {
            UpdateClientOptions();
        }

        private void radioButtonClientMSMQ_CheckedChanged(object sender, EventArgs e)
        {
            UpdateClientOptions();
        }

        private void radioButtonClientMLLP_CheckedChanged(object sender, EventArgs e)
        {
            UpdateClientOptions();
        }

        private void btnColumns_Click(object sender, EventArgs e)
        {
            var form = new FormColumnSelector(columns);
            form.ShowDialog();
            UpdateColumns();
        }

        private void UpdateColumns()
        {
            foreach (string col in columns)
            {
                if (!dataGridViewMT.Columns.Contains(col))
                {
                    var column = new DataGridViewTextBoxColumn
                    {
                        Name = col,
                        HeaderText = col,
                        Width = 100
                    };

                    dataGridViewMT.Columns.Add(column);
                }
            }

            var ColsToDelete = new List<DataGridViewColumn>();
            int ind = 0;
            foreach (DataGridViewColumn col in dataGridViewMT.Columns)
            {
                if (ind > 3 && !columns.Contains(col.HeaderText)){
                    ColsToDelete.Add(col);
                }
                ind++;
            }

            foreach (DataGridViewColumn col in ColsToDelete) {
                dataGridViewMT.Columns.Remove(col);
            }

        }

        private string GetMapDllPath(string mapDir)
        {
            string dllFolder = comboBoxDllFolder.Text;
            string dir = $"{mapDir}\\bin\\{dllFolder}";
            if(!Directory.Exists(dir)){
                throw new Exception("Could not find any mapping dlls. Please compile your maps.");
            }
            string[] mapDllVals = Directory.GetFiles(dir, "*.Maps.dll");
            if(mapDllVals.Length < 1)
            {
                throw new Exception("Could not find any mapping dlls. Please compile your maps.");
            }
            return mapDllVals[0];
        }

        private HashSet<string> GetMapNames(string mapFolder)
        {
            return new HashSet<string>((Directory
                .GetFiles(mapFolder, "*.btm")
                .Select(Path.GetFileNameWithoutExtension)));
        }

        private void btnRunMapTests_Click(object sender, EventArgs e)
        {
            dataGridViewMapTestResult.Rows.Clear();
            if (string.IsNullOrEmpty(textBoxMapFolder.Text) || !Directory.Exists(textBoxMapFolder.Text))
            {
                MessageBox.Show("Please specify the folder that has the mapping files");
            }

            string mapDir = textBoxMapFolder.Text;
            try
            {
                var mapNames = GetMapNames(mapDir);
                string mapDllPath = GetMapDllPath(mapDir);
                foreach(string dir in Directory.GetDirectories(mapDir, "tests\\*"))
                {
                    string dirName = Path.GetFileNameWithoutExtension(dir);
                    if (!mapNames.Contains(dirName))
                    {
                        dataGridViewMapTestResult.Rows.Add("Warning", $"The folder name {dirName} does not match any map. You should remove the folder.");
                    }else
                    {
                        string dllFolder = Path.GetDirectoryName(mapDllPath);
                        string mapPath = GetMapPath(mapDir, dirName);
                        foreach (string inputPath in Directory.GetFiles($"{mapDir}\\tests\\{dirName}\\inputs", "*.xml"))
                        {
                            string inputFileName = Path.GetFileName(inputPath);
                            string expOutput = $"{mapDir}\\tests\\{dirName}\\expected_outputs\\{inputFileName}";
                            string obsOutput = $"{mapDir}\\tests\\{dirName}\\observed_outputs\\{inputFileName}";
                            if (File.Exists(expOutput))
                            {

                                BiztalkMapExecutor.ApplyBizTalkMap(inputPath, mapDllPath, obsOutput, mapPath, dllFolder);
                                List<string> diffs = XmlComparator.CompareXmlFiles(expOutput, obsOutput);
                                XmlComparator.FilterOutIgnoreList(diffs, $"{mapDir}\\tests\\{dirName}\\ignore-list.txt");
                                if (diffs.Count == 0)
                                {
                                    dataGridViewMapTestResult.Rows.Add("✅ Passed", "", dirName, inputFileName, expOutput, obsOutput);
                                }
                                foreach (string diff in diffs)
                                {
                                    dataGridViewMapTestResult.Rows.Add("❌ Failed", diff, dirName, inputFileName, expOutput, obsOutput);
                                }
                            }
                            else
                            {
                                dataGridViewMapTestResult.Rows.Add("Warning", $"There was no expected output file at {expOutput}");
                            }
                        }
                        
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void dataGridViewMapTestResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Status column index
            if (e.ColumnIndex == 0 && e.Value != null)
            {
                string text = e.Value.ToString();

                if (text.Contains("Passed"))
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.SelectionForeColor = Color.Green;
                    e.CellStyle.Font = new Font(dataGridViewMapTestResult.Font, FontStyle.Bold);
                }
                else if (text.Contains("Failed"))
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.SelectionForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dataGridViewMapTestResult.Font, FontStyle.Bold);
                }
            }
        }

        private string GetMapPath(string mapDir, string mapName)
        {
            return Directory.GetFiles(mapDir, mapName + ".btm")[0];
        }

        private void btnBrowseBTMFile_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.ValidateNames = false;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                dialog.FileName = "Select Folder";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxMapFolder.Text = Path.GetDirectoryName(dialog.FileName);
                }
            }
        }

        private void btnGenerateExpOutputs_Click(object sender, EventArgs e)
        {
            dataGridViewMapTestResult.Rows.Clear();
            if (string.IsNullOrEmpty(textBoxMapFolder.Text) || !Directory.Exists(textBoxMapFolder.Text))
            {
                MessageBox.Show("Please specify the folder that has the mapping files");
            }

            string mapDir = textBoxMapFolder.Text;
            try
            {
                var mapNames = GetMapNames(mapDir);
                string mapDllPath = GetMapDllPath(mapDir);
                foreach (string dir in Directory.GetDirectories(mapDir, "tests\\*"))
                {
                    string dirName = Path.GetFileNameWithoutExtension(dir);
                    if (!mapNames.Contains(dirName))
                    {
                        dataGridViewMapTestResult.Rows.Add("Warning", $"The folder name {dirName} does not match any map. You should remove the folder.");
                    }
                    else
                    {
                        string dllFolder = Path.GetDirectoryName(mapDllPath);
                        string mapPath = GetMapPath(mapDir, dirName);
                        foreach (string inputPath in Directory.GetFiles($"{mapDir}\\tests\\{dirName}\\inputs", "*.xml"))
                        {
                            string inputFileName = Path.GetFileName(inputPath);
                            string expOutput = $"{mapDir}\\tests\\{dirName}\\expected_outputs\\{inputFileName}";
                            if (File.Exists(expOutput))
                            {
                                dataGridViewMapTestResult.Rows.Add("Info", $"Already exists: {expOutput}");
                            }
                            else
                            {
                                BiztalkMapExecutor.ApplyBizTalkMap(inputPath, mapDllPath, expOutput, mapPath, dllFolder);
                                dataGridViewMapTestResult.Rows.Add("Info", $"Generated {expOutput}");
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
