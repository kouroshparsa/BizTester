namespace BizTester
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.textBoxServerQueue = new System.Windows.Forms.TextBox();
            this.textBoxServerPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonServerMLLP = new System.Windows.Forms.RadioButton();
            this.radioButtonServerMSMQ = new System.Windows.Forms.RadioButton();
            this.radioButtonServerFolder = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.textBoxClientPort = new System.Windows.Forms.TextBox();
            this.textBoxClientQueue = new System.Windows.Forms.TextBox();
            this.textBoxClientFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButtonClientMLLP = new System.Windows.Forms.RadioButton();
            this.radioButtonClientMSMQ = new System.Windows.Forms.RadioButton();
            this.radioButtonClientFiles = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.textBoxSourceFilePath = new System.Windows.Forms.TextBox();
            this.radioButtonGenFromFile = new System.Windows.Forms.RadioButton();
            this.radioButtonSimulate = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSimSettings = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.textBoxServerPort);
            this.groupBox1.Controls.Add(this.textBoxServerQueue);
            this.groupBox1.Controls.Add(this.textBoxServerPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButtonServerMLLP);
            this.groupBox1.Controls.Add(this.radioButtonServerMSMQ);
            this.groupBox1.Controls.Add(this.radioButtonServerFolder);
            this.groupBox1.Location = new System.Drawing.Point(0, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server (Consumer)";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 143);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 27);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start Listening";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(135, 69);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(79, 20);
            this.textBoxServerPort.TabIndex = 8;
            // 
            // textBoxServerQueue
            // 
            this.textBoxServerQueue.Location = new System.Drawing.Point(135, 44);
            this.textBoxServerQueue.Name = "textBoxServerQueue";
            this.textBoxServerQueue.Size = new System.Drawing.Size(158, 20);
            this.textBoxServerQueue.TabIndex = 7;
            this.textBoxServerQueue.Text = ".\\private$\\test";
            // 
            // textBoxServerPath
            // 
            this.textBoxServerPath.Location = new System.Drawing.Point(135, 20);
            this.textBoxServerPath.Name = "textBoxServerPath";
            this.textBoxServerPath.Size = new System.Drawing.Size(159, 20);
            this.textBoxServerPath.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Queue:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path:";
            // 
            // radioButtonServerMLLP
            // 
            this.radioButtonServerMLLP.AutoSize = true;
            this.radioButtonServerMLLP.Location = new System.Drawing.Point(13, 68);
            this.radioButtonServerMLLP.Name = "radioButtonServerMLLP";
            this.radioButtonServerMLLP.Size = new System.Drawing.Size(53, 17);
            this.radioButtonServerMLLP.TabIndex = 2;
            this.radioButtonServerMLLP.Text = "MLLP";
            this.radioButtonServerMLLP.UseVisualStyleBackColor = true;
            // 
            // radioButtonServerMSMQ
            // 
            this.radioButtonServerMSMQ.AutoSize = true;
            this.radioButtonServerMSMQ.Checked = true;
            this.radioButtonServerMSMQ.Location = new System.Drawing.Point(13, 44);
            this.radioButtonServerMSMQ.Name = "radioButtonServerMSMQ";
            this.radioButtonServerMSMQ.Size = new System.Drawing.Size(58, 17);
            this.radioButtonServerMSMQ.TabIndex = 1;
            this.radioButtonServerMSMQ.TabStop = true;
            this.radioButtonServerMSMQ.Text = "MSMQ";
            this.radioButtonServerMSMQ.UseVisualStyleBackColor = true;
            // 
            // radioButtonServerFolder
            // 
            this.radioButtonServerFolder.AutoSize = true;
            this.radioButtonServerFolder.Location = new System.Drawing.Point(13, 20);
            this.radioButtonServerFolder.Name = "radioButtonServerFolder";
            this.radioButtonServerFolder.Size = new System.Drawing.Size(54, 17);
            this.radioButtonServerFolder.TabIndex = 0;
            this.radioButtonServerFolder.Text = "Folder";
            this.radioButtonServerFolder.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSimSettings);
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.textBoxClientPort);
            this.groupBox2.Controls.Add(this.textBoxClientQueue);
            this.groupBox2.Controls.Add(this.textBoxClientFolder);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.radioButtonClientMLLP);
            this.groupBox2.Controls.Add(this.radioButtonClientMSMQ);
            this.groupBox2.Controls.Add(this.radioButtonClientFiles);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(306, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 165);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client (Generator)";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(218, 137);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 28);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // textBoxClientPort
            // 
            this.textBoxClientPort.Location = new System.Drawing.Point(138, 63);
            this.textBoxClientPort.Name = "textBoxClientPort";
            this.textBoxClientPort.Size = new System.Drawing.Size(73, 20);
            this.textBoxClientPort.TabIndex = 14;
            // 
            // textBoxClientQueue
            // 
            this.textBoxClientQueue.Location = new System.Drawing.Point(138, 40);
            this.textBoxClientQueue.Name = "textBoxClientQueue";
            this.textBoxClientQueue.Size = new System.Drawing.Size(171, 20);
            this.textBoxClientQueue.TabIndex = 13;
            this.textBoxClientQueue.Text = ".\\private$\\test";
            // 
            // textBoxClientFolder
            // 
            this.textBoxClientFolder.Location = new System.Drawing.Point(138, 16);
            this.textBoxClientFolder.Name = "textBoxClientFolder";
            this.textBoxClientFolder.Size = new System.Drawing.Size(171, 20);
            this.textBoxClientFolder.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Queue:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Folder Path:";
            // 
            // radioButtonClientMLLP
            // 
            this.radioButtonClientMLLP.AutoSize = true;
            this.radioButtonClientMLLP.Location = new System.Drawing.Point(7, 62);
            this.radioButtonClientMLLP.Name = "radioButtonClientMLLP";
            this.radioButtonClientMLLP.Size = new System.Drawing.Size(53, 17);
            this.radioButtonClientMLLP.TabIndex = 2;
            this.radioButtonClientMLLP.Text = "MLLP";
            this.radioButtonClientMLLP.UseVisualStyleBackColor = true;
            // 
            // radioButtonClientMSMQ
            // 
            this.radioButtonClientMSMQ.AutoSize = true;
            this.radioButtonClientMSMQ.Checked = true;
            this.radioButtonClientMSMQ.Location = new System.Drawing.Point(7, 38);
            this.radioButtonClientMSMQ.Name = "radioButtonClientMSMQ";
            this.radioButtonClientMSMQ.Size = new System.Drawing.Size(58, 17);
            this.radioButtonClientMSMQ.TabIndex = 1;
            this.radioButtonClientMSMQ.TabStop = true;
            this.radioButtonClientMSMQ.Text = "MSMQ";
            this.radioButtonClientMSMQ.UseVisualStyleBackColor = true;
            // 
            // radioButtonClientFiles
            // 
            this.radioButtonClientFiles.AutoSize = true;
            this.radioButtonClientFiles.Location = new System.Drawing.Point(7, 14);
            this.radioButtonClientFiles.Name = "radioButtonClientFiles";
            this.radioButtonClientFiles.Size = new System.Drawing.Size(41, 17);
            this.radioButtonClientFiles.TabIndex = 0;
            this.radioButtonClientFiles.Text = "File";
            this.radioButtonClientFiles.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnOpenFileDialog);
            this.groupBox3.Controls.Add(this.textBoxSourceFilePath);
            this.groupBox3.Controls.Add(this.radioButtonGenFromFile);
            this.groupBox3.Controls.Add(this.radioButtonSimulate);
            this.groupBox3.Location = new System.Drawing.Point(7, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 45);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Source";
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Enabled = false;
            this.btnOpenFileDialog.Location = new System.Drawing.Point(267, 15);
            this.btnOpenFileDialog.Name = "btnOpenFileDialog";
            this.btnOpenFileDialog.Size = new System.Drawing.Size(35, 23);
            this.btnOpenFileDialog.TabIndex = 3;
            this.btnOpenFileDialog.Text = "<";
            this.btnOpenFileDialog.UseVisualStyleBackColor = true;
            this.btnOpenFileDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
            // 
            // textBoxSourceFilePath
            // 
            this.textBoxSourceFilePath.Enabled = false;
            this.textBoxSourceFilePath.Location = new System.Drawing.Point(167, 16);
            this.textBoxSourceFilePath.Name = "textBoxSourceFilePath";
            this.textBoxSourceFilePath.Size = new System.Drawing.Size(100, 20);
            this.textBoxSourceFilePath.TabIndex = 2;
            // 
            // radioButtonGenFromFile
            // 
            this.radioButtonGenFromFile.AutoSize = true;
            this.radioButtonGenFromFile.Location = new System.Drawing.Point(86, 18);
            this.radioButtonGenFromFile.Name = "radioButtonGenFromFile";
            this.radioButtonGenFromFile.Size = new System.Drawing.Size(82, 17);
            this.radioButtonGenFromFile.TabIndex = 1;
            this.radioButtonGenFromFile.TabStop = true;
            this.radioButtonGenFromFile.Text = "Specific file:";
            this.radioButtonGenFromFile.UseVisualStyleBackColor = true;
            this.radioButtonGenFromFile.CheckedChanged += new System.EventHandler(this.radioButtonGenFromFile_CheckedChanged);
            // 
            // radioButtonSimulate
            // 
            this.radioButtonSimulate.AutoSize = true;
            this.radioButtonSimulate.Checked = true;
            this.radioButtonSimulate.Location = new System.Drawing.Point(9, 17);
            this.radioButtonSimulate.Name = "radioButtonSimulate";
            this.radioButtonSimulate.Size = new System.Drawing.Size(65, 17);
            this.radioButtonSimulate.TabIndex = 0;
            this.radioButtonSimulate.TabStop = true;
            this.radioButtonSimulate.Text = "Simulate";
            this.radioButtonSimulate.UseVisualStyleBackColor = true;
            this.radioButtonSimulate.CheckedChanged += new System.EventHandler(this.radioButtonSimulate_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Timestamp,
            this.Type,
            this.Message,
            this.Data});
            this.dataGridView1.Location = new System.Drawing.Point(0, 183);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(621, 130);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // Timestamp
            // 
            this.Timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Timestamp.HeaderText = "Timestamp";
            this.Timestamp.Name = "Timestamp";
            this.Timestamp.ReadOnly = true;
            this.Timestamp.Width = 81;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 54;
            // 
            // Message
            // 
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCopy,
            this.toolStripMenuItemClear});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 48);
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItemCopy.Text = "Copy Data";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItemClear.Text = "Clear all logs";
            this.toolStripMenuItemClear.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // btnSimSettings
            // 
            this.btnSimSettings.Location = new System.Drawing.Point(7, 136);
            this.btnSimSettings.Name = "btnSimSettings";
            this.btnSimSettings.Size = new System.Drawing.Size(109, 27);
            this.btnSimSettings.TabIndex = 17;
            this.btnSimSettings.Text = "Simulation Settings";
            this.btnSimSettings.UseVisualStyleBackColor = true;
            this.btnSimSettings.Click += new System.EventHandler(this.btnSimSettings_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 314);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "BizTester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonServerMLLP;
        private System.Windows.Forms.RadioButton radioButtonServerMSMQ;
        private System.Windows.Forms.RadioButton radioButtonServerFolder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonClientMLLP;
        private System.Windows.Forms.RadioButton radioButtonClientMSMQ;
        private System.Windows.Forms.RadioButton radioButtonClientFiles;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxServerPort;
        private System.Windows.Forms.TextBox textBoxServerQueue;
        private System.Windows.Forms.TextBox textBoxServerPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox textBoxClientPort;
        private System.Windows.Forms.TextBox textBoxClientQueue;
        private System.Windows.Forms.TextBox textBoxClientFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOpenFileDialog;
        private System.Windows.Forms.TextBox textBoxSourceFilePath;
        private System.Windows.Forms.RadioButton radioButtonGenFromFile;
        private System.Windows.Forms.RadioButton radioButtonSimulate;
        private System.Windows.Forms.Button btnSimSettings;
    }
}

