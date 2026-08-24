using BizTester.UIHelpers;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStripMT = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.viewReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewMT = new System.Windows.Forms.DataGridView();
            this.Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBoxServerControls = new System.Windows.Forms.GroupBox();
            this.progressBarServer = new System.Windows.Forms.ProgressBar();
            this.comboBoxAckCode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxServerAck = new System.Windows.Forms.CheckBox();
            this.btnStart = new BizTester.UIHelpers.RoundedButton();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.textBoxServerQueue = new System.Windows.Forms.TextBox();
            this.textBoxServerPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonServerMLLP = new System.Windows.Forms.RadioButton();
            this.radioButtonServerMSMQ = new System.Windows.Forms.RadioButton();
            this.radioButtonServerFolder = new System.Windows.Forms.RadioButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clientDelay = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.clientCount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBarClient = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxClientIP = new System.Windows.Forms.TextBox();
            this.btnTransformation = new BizTester.UIHelpers.RoundedButton();
            this.btnSend = new BizTester.UIHelpers.RoundedButton();
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
            this.btnOpenDialog = new BizTester.UIHelpers.RoundedButton();
            this.textBoxSourcePath = new System.Windows.Forms.TextBox();
            this.btnColumns = new BizTester.UIHelpers.RoundedButton();
            this.contextMenuStripMT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMT)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBoxServerControls.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientCount)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripMT
            // 
            this.contextMenuStripMT.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripMT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDataToolStripMenuItem,
            this.toolStripMenuItemCopy,
            this.viewReportToolStripMenuItem,
            this.exportReportToolStripMenuItem,
            this.exportLogsToolStripMenuItem,
            this.toolStripMenuItemClear});
            this.contextMenuStripMT.Name = "contextMenuStrip1";
            this.contextMenuStripMT.Size = new System.Drawing.Size(146, 136);
            // 
            // viewDataToolStripMenuItem
            // 
            this.viewDataToolStripMenuItem.Name = "viewDataToolStripMenuItem";
            this.viewDataToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.viewDataToolStripMenuItem.Text = "View Data";
            this.viewDataToolStripMenuItem.Click += new System.EventHandler(this.viewDataToolStripMenuItem_Click);
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(145, 22);
            this.toolStripMenuItemCopy.Text = "Copy Data";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // viewReportToolStripMenuItem
            // 
            this.viewReportToolStripMenuItem.Name = "viewReportToolStripMenuItem";
            this.viewReportToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.viewReportToolStripMenuItem.Text = "View Report";
            this.viewReportToolStripMenuItem.Click += new System.EventHandler(this.viewReportToolStripMenuItem_Click);
            // 
            // exportReportToolStripMenuItem
            // 
            this.exportReportToolStripMenuItem.Name = "exportReportToolStripMenuItem";
            this.exportReportToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exportReportToolStripMenuItem.Text = "Export Report";
            this.exportReportToolStripMenuItem.Click += new System.EventHandler(this.exportReportToolStripMenuItem_Click);
            // 
            // exportLogsToolStripMenuItem
            // 
            this.exportLogsToolStripMenuItem.Name = "exportLogsToolStripMenuItem";
            this.exportLogsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.exportLogsToolStripMenuItem.Text = "Export Logs";
            this.exportLogsToolStripMenuItem.Click += new System.EventHandler(this.exportLogsToolStripMenuItem_Click);
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(145, 22);
            this.toolStripMenuItemClear.Text = "Clear all logs";
            this.toolStripMenuItemClear.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // dataGridViewMT
            // 
            this.dataGridViewMT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Timestamp,
            this.Type,
            this.Message,
            this.Data});
            this.dataGridViewMT.ContextMenuStrip = this.contextMenuStripMT;
            this.dataGridViewMT.Location = new System.Drawing.Point(4, 281);
            this.dataGridViewMT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewMT.Name = "dataGridViewMT";
            this.dataGridViewMT.RowHeadersWidth = 62;
            this.dataGridViewMT.Size = new System.Drawing.Size(627, 143);
            this.dataGridViewMT.TabIndex = 18;
            // 
            // Timestamp
            // 
            this.Timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Timestamp.HeaderText = "Timestamp";
            this.Timestamp.MinimumWidth = 8;
            this.Timestamp.Name = "Timestamp";
            this.Timestamp.ReadOnly = true;
            this.Timestamp.Width = 112;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 8;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 68;
            // 
            // Message
            // 
            this.Message.HeaderText = "Message";
            this.Message.MinimumWidth = 8;
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.Width = 150;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Data.HeaderText = "Data";
            this.Data.MinimumWidth = 8;
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Width = 150;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(4, 14);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(627, 235);
            this.tabControl2.TabIndex = 17;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBoxServerControls);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(619, 202);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Server";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBoxServerControls
            // 
            this.groupBoxServerControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxServerControls.Controls.Add(this.progressBarServer);
            this.groupBoxServerControls.Controls.Add(this.comboBoxAckCode);
            this.groupBoxServerControls.Controls.Add(this.label9);
            this.groupBoxServerControls.Controls.Add(this.checkBoxServerAck);
            this.groupBoxServerControls.Controls.Add(this.btnStart);
            this.groupBoxServerControls.Controls.Add(this.textBoxServerPort);
            this.groupBoxServerControls.Controls.Add(this.textBoxServerQueue);
            this.groupBoxServerControls.Controls.Add(this.textBoxServerPath);
            this.groupBoxServerControls.Controls.Add(this.label3);
            this.groupBoxServerControls.Controls.Add(this.label2);
            this.groupBoxServerControls.Controls.Add(this.label1);
            this.groupBoxServerControls.Controls.Add(this.radioButtonServerMLLP);
            this.groupBoxServerControls.Controls.Add(this.radioButtonServerMSMQ);
            this.groupBoxServerControls.Controls.Add(this.radioButtonServerFolder);
            this.groupBoxServerControls.Location = new System.Drawing.Point(4, 5);
            this.groupBoxServerControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxServerControls.Name = "groupBoxServerControls";
            this.groupBoxServerControls.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxServerControls.Size = new System.Drawing.Size(602, 164);
            this.groupBoxServerControls.TabIndex = 1;
            this.groupBoxServerControls.TabStop = false;
            this.groupBoxServerControls.Text = "Server (Consumer)";
            // 
            // progressBarServer
            // 
            this.progressBarServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarServer.Location = new System.Drawing.Point(139, 117);
            this.progressBarServer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBarServer.Name = "progressBarServer";
            this.progressBarServer.Size = new System.Drawing.Size(455, 24);
            this.progressBarServer.TabIndex = 13;
            // 
            // comboBoxAckCode
            // 
            this.comboBoxAckCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAckCode.Items.AddRange(new object[] {
            "AA",
            "AE",
            "AR",
            "CA",
            "CE",
            "CR"});
            this.comboBoxAckCode.Location = new System.Drawing.Point(247, 93);
            this.comboBoxAckCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxAckCode.Name = "comboBoxAckCode";
            this.comboBoxAckCode.Size = new System.Drawing.Size(114, 28);
            this.comboBoxAckCode.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 93);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "ACK Code:";
            // 
            // checkBoxServerAck
            // 
            this.checkBoxServerAck.AutoSize = true;
            this.checkBoxServerAck.Checked = true;
            this.checkBoxServerAck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxServerAck.Location = new System.Drawing.Point(20, 90);
            this.checkBoxServerAck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxServerAck.Name = "checkBoxServerAck";
            this.checkBoxServerAck.Size = new System.Drawing.Size(199, 24);
            this.checkBoxServerAck.TabIndex = 6;
            this.checkBoxServerAck.Text = "Send acknowledgement";
            this.checkBoxServerAck.UseVisualStyleBackColor = true;
            this.checkBoxServerAck.CheckedChanged += new System.EventHandler(this.checkBoxServerAck_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnStart.BorderRadius = 10;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(20, 117);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(111, 24);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start Listening";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(139, 63);
            this.textBoxServerPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(116, 26);
            this.textBoxServerPort.TabIndex = 5;
            // 
            // textBoxServerQueue
            // 
            this.textBoxServerQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerQueue.Location = new System.Drawing.Point(139, 44);
            this.textBoxServerQueue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxServerQueue.Name = "textBoxServerQueue";
            this.textBoxServerQueue.Size = new System.Drawing.Size(456, 26);
            this.textBoxServerQueue.TabIndex = 4;
            this.textBoxServerQueue.Text = ".\\private$\\test";
            // 
            // textBoxServerPath
            // 
            this.textBoxServerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerPath.Location = new System.Drawing.Point(139, 25);
            this.textBoxServerPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxServerPath.Name = "textBoxServerPath";
            this.textBoxServerPath.Size = new System.Drawing.Size(456, 26);
            this.textBoxServerPath.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Queue:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path:";
            // 
            // radioButtonServerMLLP
            // 
            this.radioButtonServerMLLP.AutoSize = true;
            this.radioButtonServerMLLP.Location = new System.Drawing.Point(20, 63);
            this.radioButtonServerMLLP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonServerMLLP.Name = "radioButtonServerMLLP";
            this.radioButtonServerMLLP.Size = new System.Drawing.Size(68, 24);
            this.radioButtonServerMLLP.TabIndex = 2;
            this.radioButtonServerMLLP.Text = "MLLP";
            this.radioButtonServerMLLP.UseVisualStyleBackColor = true;
            this.radioButtonServerMLLP.CheckedChanged += new System.EventHandler(this.radioButtonServerMLLP_CheckedChanged);
            // 
            // radioButtonServerMSMQ
            // 
            this.radioButtonServerMSMQ.AutoSize = true;
            this.radioButtonServerMSMQ.Checked = true;
            this.radioButtonServerMSMQ.Location = new System.Drawing.Point(20, 45);
            this.radioButtonServerMSMQ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonServerMSMQ.Name = "radioButtonServerMSMQ";
            this.radioButtonServerMSMQ.Size = new System.Drawing.Size(76, 24);
            this.radioButtonServerMSMQ.TabIndex = 1;
            this.radioButtonServerMSMQ.TabStop = true;
            this.radioButtonServerMSMQ.Text = "MSMQ";
            this.radioButtonServerMSMQ.UseVisualStyleBackColor = true;
            this.radioButtonServerMSMQ.CheckedChanged += new System.EventHandler(this.radioButtonServerMSMQ_CheckedChanged);
            // 
            // radioButtonServerFolder
            // 
            this.radioButtonServerFolder.AutoSize = true;
            this.radioButtonServerFolder.Location = new System.Drawing.Point(20, 25);
            this.radioButtonServerFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonServerFolder.Name = "radioButtonServerFolder";
            this.radioButtonServerFolder.Size = new System.Drawing.Size(72, 24);
            this.radioButtonServerFolder.TabIndex = 2;
            this.radioButtonServerFolder.Text = "Folder";
            this.radioButtonServerFolder.UseVisualStyleBackColor = true;
            this.radioButtonServerFolder.CheckedChanged += new System.EventHandler(this.radioButtonServerFolder_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Size = new System.Drawing.Size(619, 202);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Client";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.clientDelay);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.clientCount);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.progressBarClient);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxClientIP);
            this.groupBox2.Controls.Add(this.btnTransformation);
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
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(611, 207);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client (Generator)";
            // 
            // clientDelay
            // 
            this.clientDelay.DecimalPlaces = 1;
            this.clientDelay.Location = new System.Drawing.Point(211, 167);
            this.clientDelay.Name = "clientDelay";
            this.clientDelay.Size = new System.Drawing.Size(62, 26);
            this.clientDelay.TabIndex = 27;
            this.clientDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(117, 171);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Delay (Seconds):";
            // 
            // clientCount
            // 
            this.clientCount.Location = new System.Drawing.Point(211, 148);
            this.clientCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.clientCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.clientCount.Name = "clientCount";
            this.clientCount.Size = new System.Drawing.Size(62, 26);
            this.clientCount.TabIndex = 25;
            this.clientCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 69);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "IP:";
            // 
            // progressBarClient
            // 
            this.progressBarClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarClient.Location = new System.Drawing.Point(373, 143);
            this.progressBarClient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBarClient.Name = "progressBarClient";
            this.progressBarClient.Size = new System.Drawing.Size(230, 24);
            this.progressBarClient.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 149);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Count:";
            // 
            // textBoxClientIP
            // 
            this.textBoxClientIP.Location = new System.Drawing.Point(273, 67);
            this.textBoxClientIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxClientIP.Name = "textBoxClientIP";
            this.textBoxClientIP.Size = new System.Drawing.Size(148, 26);
            this.textBoxClientIP.TabIndex = 23;
            // 
            // btnTransformation
            // 
            this.btnTransformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnTransformation.BorderRadius = 10;
            this.btnTransformation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransformation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTransformation.ForeColor = System.Drawing.Color.White;
            this.btnTransformation.Location = new System.Drawing.Point(12, 143);
            this.btnTransformation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTransformation.Name = "btnTransformation";
            this.btnTransformation.Size = new System.Drawing.Size(117, 24);
            this.btnTransformation.TabIndex = 12;
            this.btnTransformation.Text = "Transformations";
            this.btnTransformation.UseVisualStyleBackColor = true;
            this.btnTransformation.Click += new System.EventHandler(this.btnTransformation_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSend.BorderRadius = 10;
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(286, 143);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(79, 24);
            this.btnSend.TabIndex = 14;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // textBoxClientPort
            // 
            this.textBoxClientPort.Location = new System.Drawing.Point(140, 67);
            this.textBoxClientPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxClientPort.Name = "textBoxClientPort";
            this.textBoxClientPort.Size = new System.Drawing.Size(108, 26);
            this.textBoxClientPort.TabIndex = 5;
            // 
            // textBoxClientQueue
            // 
            this.textBoxClientQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClientQueue.Location = new System.Drawing.Point(140, 49);
            this.textBoxClientQueue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxClientQueue.Name = "textBoxClientQueue";
            this.textBoxClientQueue.Size = new System.Drawing.Size(457, 26);
            this.textBoxClientQueue.TabIndex = 4;
            this.textBoxClientQueue.Text = ".\\private$\\test";
            // 
            // textBoxClientFolder
            // 
            this.textBoxClientFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClientFolder.Location = new System.Drawing.Point(140, 27);
            this.textBoxClientFolder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxClientFolder.Name = "textBoxClientFolder";
            this.textBoxClientFolder.Size = new System.Drawing.Size(457, 26);
            this.textBoxClientFolder.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Queue:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 28);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Folder Path:";
            // 
            // radioButtonClientMLLP
            // 
            this.radioButtonClientMLLP.AutoSize = true;
            this.radioButtonClientMLLP.Location = new System.Drawing.Point(19, 66);
            this.radioButtonClientMLLP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonClientMLLP.Name = "radioButtonClientMLLP";
            this.radioButtonClientMLLP.Size = new System.Drawing.Size(68, 24);
            this.radioButtonClientMLLP.TabIndex = 2;
            this.radioButtonClientMLLP.Text = "MLLP";
            this.radioButtonClientMLLP.UseVisualStyleBackColor = true;
            this.radioButtonClientMLLP.CheckedChanged += new System.EventHandler(this.radioButtonClientMLLP_CheckedChanged);
            // 
            // radioButtonClientMSMQ
            // 
            this.radioButtonClientMSMQ.AutoSize = true;
            this.radioButtonClientMSMQ.Checked = true;
            this.radioButtonClientMSMQ.Location = new System.Drawing.Point(19, 47);
            this.radioButtonClientMSMQ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonClientMSMQ.Name = "radioButtonClientMSMQ";
            this.radioButtonClientMSMQ.Size = new System.Drawing.Size(76, 24);
            this.radioButtonClientMSMQ.TabIndex = 1;
            this.radioButtonClientMSMQ.TabStop = true;
            this.radioButtonClientMSMQ.Text = "MSMQ";
            this.radioButtonClientMSMQ.UseVisualStyleBackColor = true;
            this.radioButtonClientMSMQ.CheckedChanged += new System.EventHandler(this.radioButtonClientMSMQ_CheckedChanged);
            // 
            // radioButtonClientFiles
            // 
            this.radioButtonClientFiles.AutoSize = true;
            this.radioButtonClientFiles.Location = new System.Drawing.Point(19, 27);
            this.radioButtonClientFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonClientFiles.Name = "radioButtonClientFiles";
            this.radioButtonClientFiles.Size = new System.Drawing.Size(52, 24);
            this.radioButtonClientFiles.TabIndex = 0;
            this.radioButtonClientFiles.Text = "File";
            this.radioButtonClientFiles.UseVisualStyleBackColor = true;
            this.radioButtonClientFiles.CheckedChanged += new System.EventHandler(this.radioButtonClientFiles_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnOpenDialog);
            this.groupBox3.Controls.Add(this.textBoxSourcePath);
            this.groupBox3.Location = new System.Drawing.Point(12, 93);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(591, 47);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Source";
            // 
            // btnOpenDialog
            // 
            this.btnOpenDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDialog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnOpenDialog.BorderRadius = 10;
            this.btnOpenDialog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDialog.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOpenDialog.ForeColor = System.Drawing.Color.White;
            this.btnOpenDialog.Location = new System.Drawing.Point(509, 19);
            this.btnOpenDialog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenDialog.Name = "btnOpenDialog";
            this.btnOpenDialog.Size = new System.Drawing.Size(73, 24);
            this.btnOpenDialog.TabIndex = 11;
            this.btnOpenDialog.Text = "Select";
            this.btnOpenDialog.UseVisualStyleBackColor = true;
            this.btnOpenDialog.Click += new System.EventHandler(this.btnOpenDialog_Click);
            // 
            // textBoxSourcePath
            // 
            this.textBoxSourcePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSourcePath.Location = new System.Drawing.Point(9, 22);
            this.textBoxSourcePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxSourcePath.Name = "textBoxSourcePath";
            this.textBoxSourcePath.Size = new System.Drawing.Size(493, 26);
            this.textBoxSourcePath.TabIndex = 10;
            // 
            // btnColumns
            // 
            this.btnColumns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnColumns.BorderRadius = 10;
            this.btnColumns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnColumns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColumns.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnColumns.ForeColor = System.Drawing.Color.White;
            this.btnColumns.Location = new System.Drawing.Point(4, 255);
            this.btnColumns.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnColumns.Name = "btnColumns";
            this.btnColumns.Size = new System.Drawing.Size(85, 24);
            this.btnColumns.TabIndex = 19;
            this.btnColumns.Text = "Columns";
            this.btnColumns.UseVisualStyleBackColor = true;
            this.btnColumns.Click += new System.EventHandler(this.btnColumns_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(635, 435);
            this.Controls.Add(this.btnColumns);
            this.Controls.Add(this.dataGridViewMT);
            this.Controls.Add(this.tabControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "BizTester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStripMT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMT)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBoxServerControls.ResumeLayout(false);
            this.groupBoxServerControls.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientCount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMT;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.ToolStripMenuItem exportLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportReportToolStripMenuItem;
        private RoundedButton btnColumns;
        private System.Windows.Forms.DataGridView dataGridViewMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBoxServerControls;
        private System.Windows.Forms.ProgressBar progressBarServer;
        private System.Windows.Forms.ComboBox comboBoxAckCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxServerAck;
        private RoundedButton btnStart;
        private System.Windows.Forms.TextBox textBoxServerPort;
        private System.Windows.Forms.TextBox textBoxServerQueue;
        private System.Windows.Forms.TextBox textBoxServerPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonServerMLLP;
        private System.Windows.Forms.RadioButton radioButtonServerMSMQ;
        private System.Windows.Forms.RadioButton radioButtonServerFolder;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ToolStripMenuItem viewDataToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown clientDelay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown clientCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBarClient;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxClientIP;
        private RoundedButton btnTransformation;
        private RoundedButton btnSend;
        private System.Windows.Forms.TextBox textBoxClientPort;
        private System.Windows.Forms.TextBox textBoxClientQueue;
        private System.Windows.Forms.TextBox textBoxClientFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButtonClientMLLP;
        private System.Windows.Forms.RadioButton radioButtonClientMSMQ;
        private System.Windows.Forms.RadioButton radioButtonClientFiles;
        private System.Windows.Forms.GroupBox groupBox3;
        private RoundedButton btnOpenDialog;
        private System.Windows.Forms.TextBox textBoxSourcePath;
        private System.Windows.Forms.ToolStripMenuItem viewReportToolStripMenuItem;
    }
}

