using BizTester.Client;
using BizTester.Helpers;
using BizTester.Models;
using BizTester.Server;
using BizTester.Transformer;
using BizTester.UIHelpers;
//using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizTester
{
    public partial class MainForm : Form
    {
        private dynamic listener;
        private dynamic client;
        private CustomLogger logger;
        private TransformationSpec trSpec;
        private string[] selectedClientFiles;
        private List<string> columns = new List<string>();


        public MainForm()
        {
            InitializeComponent();
        }

        private void UpdateGroupBox(GroupBox groupBox, bool enable)
        {
            foreach (Control con in groupBox.Controls)
            {
                if (con.Name != "btnStart")
                {
                    if (con is RadioButton rb)
                        rb.AutoCheck = enable;
                    else if (con is CheckBox cb)
                        cb.AutoCheck = enable;
                    else  if (con is TextBox tb)
                        tb.ReadOnly = !enable;
                }
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Contains("Stop"))// stopping
            {
                progressBarServer.Style = ProgressBarStyle.Blocks;
                progressBarServer.Visible = false;
                btnStart.Text = "Start Listening";
                listener.Stop();

                UpdateGroupBox(groupBoxServerControls, true);
                UpdateServerOptions();
            }
            else// starting
            {
                progressBarServer.Style = ProgressBarStyle.Marquee;
                progressBarServer.Visible = true;
                UpdateGroupBox(groupBoxServerControls, false);

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
                    progressBarServer.Style = ProgressBarStyle.Blocks;
                    progressBarServer.Visible = false;
                    btnStart.Text = "Start Listening";
                    btnStart.Enabled = true;
                    UpdateGroupBox(groupBoxServerControls, true);
                    UpdateServerOptions();
                }


            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
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

            progressBarClient.Style = ProgressBarStyle.Marquee;
            progressBarClient.Visible = true;
            HL7Helper.ResetCounter();
            int count = 1;
            if(!int.TryParse(clientCount.Text, out count))
            {
                MessageBox.Show("Invalid count. It must be an integer.");
                return;
            }

            decimal delay = clientDelay.Value;
            
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

                await Task.Run(async () =>
                {
                    foreach (string filePath in selectedClientFiles)
                    {
                        string parsedData = HL7Helper.GetMessageFromFile(filePath);
                        string fileName = Path.GetFileName(filePath);
                        for (int counter = 0; counter < count; counter++)
                        {
                            string data = parsedData;
                            if (trSpec != null && trSpec.records.Count > 0)
                            {
                                data = HL7Helper.Transform(parsedData, trSpec);
                            }
                            client.Send(data, fileName);

                            await Task.Delay(
                                TimeSpan.FromSeconds((double)delay));

                            logger.Flush();
                        }
                    }
                });

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            progressBarClient.Style = ProgressBarStyle.Blocks;
            progressBarClient.Visible = false;
        }
        

        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            dataGridViewMT.Rows.Clear();
        }

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            if (dataGridViewMT.SelectedCells.Count > 0)
            {
                int ind = dataGridViewMT.SelectedCells[0].RowIndex;
                string data = dataGridViewMT.Rows[0].Cells[3].Value.ToString();
                if (!string.IsNullOrEmpty(data))
                {
                    Clipboard.SetDataObject(data, false);
                }
            }
        }
        
                
        private void checkBoxServerAck_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxAckCode.Enabled = checkBoxServerAck.Checked;
        }

        private void exportLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReportController.ExportLogs(dataGridViewMT);
                MessageBox.Show(
                "Data Exported Successfully!",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to export data: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
       

        private void exportReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 1,
                RestoreDirectory = true,
                DefaultExt = "xlsx",
                AddExtension = true
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var report = ReportController.CreateReport(dataGridViewMT);
                if (string.IsNullOrEmpty(report.error))
                {
                    ReportController.ExportReport(report, saveFileDialog.FileName);
                }
                else
                {
                    MessageBox.Show($"Failed to create report. {report.error}");
                }
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
            Theme.ApplyTheme(form);
            form.ShowDialog();
            this.columns.Clear();
            var cols = form.GetColumns();
            foreach (string col in cols)
                this.columns.Add(col);

            UpdateColumns();
        }

        private void UpdateColumns()
        {
            int i = 4;
            foreach(string col in columns)
            {
                if(i == dataGridViewMT.Columns.Count)
                {
                    var column = new DataGridViewTextBoxColumn
                    {
                        Name = col,
                        HeaderText = col,
                        Width = 100
                    };

                    dataGridViewMT.Columns.Add(column);
                    i++;
                }else
                {
                    if (dataGridViewMT.Columns[i].HeaderText.Equals(col))
                    {
                        i++;
                    }else {
                        dataGridViewMT.Columns.RemoveAt(i);
                        var column = new DataGridViewTextBoxColumn
                        {
                            Name = col,
                            HeaderText = col,
                            Width = 100
                        };

                        dataGridViewMT.Columns.Insert(i, column);
                        i++;
                    }
                }
            }

            while(i < dataGridViewMT.Columns.Count)
            {
                dataGridViewMT.Columns.RemoveAt(i);
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Theme.ApplyTheme(this);
            Theme.ApplyContextMenuTheme(contextMenuStripMT);
            dataGridViewMT.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewMT.MultiSelect = false;
            logger = new CustomLogger(dataGridViewMT, columns);
            dataGridViewMT.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewMT.AllowUserToOrderColumns = true;

            this.Icon = Properties.Resources.flask_icon;
            this.trSpec = new TransformationSpec(Properties.Settings.Default.TransformationSourceFilePathValue);
            textBoxSourcePath.Text = Properties.Settings.Default.SourcePathValue;
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
            toolTipClientCount.SetToolTip(clientCount, "Here you can specify a number if you want to send a message several times.");

            columns.Add("MSH-9.1");
            columns.Add("MSH-9.2");
            columns.Add("MSH-10");
            columns.Add("MSA-2");
            UpdateColumns();
            progressBarServer.Visible = false;
            progressBarClient.Visible = false;
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text += " v" + version;
            ResizeDataGridView();

            try
            {
                this.trSpec.LoadSettingsFromFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnTransformation_Click(object sender, EventArgs e)
        {
            var form = new FormTransformerSettings(trSpec);
            Theme.ApplyTheme(form);
            form.ShowDialog();
            this.trSpec = form.Spec;
        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Multiselect = true;
                try
                {
                    if (selectedClientFiles != null && selectedClientFiles.Length > 0)
                        of.InitialDirectory = Path.GetDirectoryName(selectedClientFiles[0]);
                }
                catch (Exception) { }

                if (of.ShowDialog() == DialogResult.OK)
                {
                    selectedClientFiles = of.FileNames;
                    if (selectedClientFiles.Length == 1)
                    {
                        textBoxSourcePath.Text = selectedClientFiles[0];
                    }
                    else
                    {
                        textBoxSourcePath.Text = $"{selectedClientFiles.Length} files selected";
                    }

                }
            }
        }

        private void viewDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewMT.SelectedCells.Count > 0)
            {
                int ind = dataGridViewMT.SelectedCells[0].RowIndex;
                string data = dataGridViewMT.Rows[ind].Cells[3].Value?.ToString();
                if (!string.IsNullOrEmpty(data))
                {
                    if (data.Trim().StartsWith("<"))
                    {
                        var form = new FormXmlViewer(data);
                        Theme.ApplyTheme(form);
                        form.ShowDialog();
                    }
                    else
                    {
                        var form = new FormHL7Viewer(data);
                        Theme.ApplyTheme(form);
                        form.ShowDialog();
                    }
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SourcePathValue = textBoxSourcePath.Text;
            Properties.Settings.Default.Save();

            if (listener != null)
                listener.Stop();
        }

        private void ResizeDataGridView()// There is a bug where the bottom of the grid is cut off on screens with different dpi. You only need to call this at the load time.
        {
            int newHeight = ClientSize.Height - dataGridViewMT.Top;

            if (newHeight < 0)
                newHeight = 0;

            dataGridViewMT.SetBounds(
                dataGridViewMT.Left,
                dataGridViewMT.Top,
                ClientSize.Width - dataGridViewMT.Left - 12,
                newHeight);
        }

        private void viewReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormReportViewer(dataGridViewMT);
            Theme.ApplyTheme(form);
            form.ShowDialog();
        }
    }
}
