using BizTester.Client;
using BizTester.Libs;
using BizTester.Server;
using System;
using System.IO;
using System.Windows.Forms;
using BizTester.Simulation;

namespace BizTester
{
    public partial class MainForm : Form
    {
        private dynamic listener;
        private dynamic client;
        private CustomLogger logger;
        private SimulationSpec simSpec;
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.MultiSelect = false;
            logger = new CustomLogger(dataGridView1);
            dataGridView1.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.Icon = Properties.Resources.flask_icon;
            this.simSpec = new SimulationSpec();
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
            if (btnStart.Text.Contains("Stop"))
            {
                btnStart.Text = "Start Listening";
                listener.Stop();
            }
            else
            {
                try
                {
                    if (radioButtonServerFolder.Checked)
                    {
                        listener = new Folder_Listener(logger, textBoxServerPath.Text);
                    }
                    else if (radioButtonServerMSMQ.Checked)
                    {
                        listener = new MSMQ_Listener(logger, textBoxServerQueue.Text);
                    }
                    else// MLLP
                    {
                        listener = new MLLP_Listener(logger, textBoxServerPort.Text);
                    }

                    listener.Start();
                    btnStart.Text = "Stop Listening";
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                }


            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string data;
                if (radioButtonGenFromFile.Checked)
                {
                    if (!File.Exists(textBoxSourceFilePath.Text))
                    {
                        logger.Error("Missing source file path");
                        return;
                    }
                    data = Simulator.GetMessageFromFile(textBoxSourceFilePath.Text);
                }
                else
                {
                    data = Simulator.GetHL7Message(simSpec);
                }
                
                if (radioButtonClientFiles.Checked)
                {
                    client = new File_Sender(logger, textBoxClientFolder.Text);
                }
                else if (radioButtonClientMLLP.Checked)
                {
                    client = new MLLP_Sender(logger, textBoxClientPort.Text);
                }
                else// MSMQ
                {
                    client = new MSMQ_Sender(logger, textBoxClientQueue.Text);
                }
                client.Start(data);
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
                    this.dataGridView1.CurrentCell = clickedCell;  // Select the clicked cell, for instance

                    // Get mouse position relative to the vehicles grid
                    var relativeMousePosition = dataGridView1.PointToClient(Cursor.Position);

                    // Show the context menu
                    this.contextMenuStrip1.Show(dataGridView1, relativeMousePosition);
                }
            }
        }

        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Value != null)
            {
                string data = dataGridView1.CurrentCell.Value.ToString().Trim();
                Clipboard.SetDataObject(data, false);
            }
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                if (of.ShowDialog() == DialogResult.OK)
                {
                    textBoxSourceFilePath.Text = of.FileName;
                }
            }
        }

        private void radioButtonGenFromFile_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSourceFilePath.Enabled = radioButtonGenFromFile.Checked;
            btnOpenFileDialog.Enabled = radioButtonGenFromFile.Checked;
        }

        private void radioButtonSimulate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(listener != null)
            {
                listener.Stop();
            }
        }

        private void btnSimSettings_Click(object sender, EventArgs e)
        {
            var form = new FormSimulationSettings(this.simSpec);
            form.ShowDialog();
            this.simSpec = form.Spec;
        }
    }
}
