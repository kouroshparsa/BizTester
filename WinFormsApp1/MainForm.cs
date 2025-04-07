using BizTester.Client;
using BizTester.Libs;
using BizTester.Server;

namespace BizTester
{
    public partial class MainForm : Form
    {
        private dynamic listener;
        private dynamic client;
        private CustomLogger logger;

        public MainForm()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.MultiSelect = false;
            logger = new CustomLogger(dataGridView1);
        }

        private void BtnStart_Click(object sender, EventArgs e)
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
                        listener = new MLLP_Listener(logger, textBoxServerPort.Text, checkBoxAck.Checked);
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

        private void Form_closing(object sender, EventArgs e)
        {
            listener.Stop();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listener != null)
                listener.Stop();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
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
                client.Start();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }
    }
}