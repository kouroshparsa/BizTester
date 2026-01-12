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
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnColumns = new System.Windows.Forms.Button();
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBarClient = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxClientCount = new System.Windows.Forms.TextBox();
            this.textBoxClientIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSimSettings = new System.Windows.Forms.Button();
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
            this.btnOpenDialog = new System.Windows.Forms.Button();
            this.textBoxSourcePath = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridViewATLogs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripATLogs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRunTests = new System.Windows.Forms.Button();
            this.textBoxTestSpecPath = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStripTreeNodeOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expandAllNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripTestToolbar = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnGenerateExpOutputs = new System.Windows.Forms.Button();
            this.comboBoxDllFolder = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBrowseBTMFile = new System.Windows.Forms.Button();
            this.textBoxMapFolder = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGridViewMapTestResult = new System.Windows.Forms.DataGridView();
            this.TestStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestMap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestInput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestExpOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestObsOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripMapTest = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.compareSideBySideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRunMapTests = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.progressBarReport = new System.Windows.Forms.ProgressBar();
            this.btnEditRegRepIgnoreList = new System.Windows.Forms.Button();
            this.textBoxRegressionReportStatus = new System.Windows.Forms.TextBox();
            this.listBoxRegressionReportIgnoreList = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnNewFolderOpenDialog = new System.Windows.Forms.Button();
            this.btnOldFolderOpenDialog = new System.Windows.Forms.Button();
            this.textBoxNewFolder = new System.Windows.Forms.TextBox();
            this.textBoxOldFolder = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.openTestSuiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripMT.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMT)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBoxServerControls.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewATLogs)).BeginInit();
            this.contextMenuStripATLogs.SuspendLayout();
            this.contextMenuStripTreeNodeOptions.SuspendLayout();
            this.menuStripTestToolbar.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMapTestResult)).BeginInit();
            this.contextMenuStripMapTest.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripMT
            // 
            this.contextMenuStripMT.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripMT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCopy,
            this.exportToolStripMenuItem,
            this.createReportToolStripMenuItem,
            this.toolStripMenuItemClear});
            this.contextMenuStripMT.Name = "contextMenuStrip1";
            this.contextMenuStripMT.Size = new System.Drawing.Size(147, 92);
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemCopy.Text = "Copy Data";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exportToolStripMenuItem.Text = "Export Data";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // createReportToolStripMenuItem
            // 
            this.createReportToolStripMenuItem.Name = "createReportToolStripMenuItem";
            this.createReportToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.createReportToolStripMenuItem.Text = "Create Report";
            this.createReportToolStripMenuItem.Click += new System.EventHandler(this.createReportToolStripMenuItem_Click);
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItemClear.Text = "Clear all logs";
            this.toolStripMenuItemClear.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(0, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(676, 464);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnColumns);
            this.tabPage1.Controls.Add(this.dataGridViewMT);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(668, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manual Testing";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnColumns
            // 
            this.btnColumns.Location = new System.Drawing.Point(6, 219);
            this.btnColumns.Name = "btnColumns";
            this.btnColumns.Size = new System.Drawing.Size(75, 23);
            this.btnColumns.TabIndex = 16;
            this.btnColumns.Text = "Columns";
            this.btnColumns.UseVisualStyleBackColor = true;
            this.btnColumns.Click += new System.EventHandler(this.btnColumns_Click);
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
            this.dataGridViewMT.Location = new System.Drawing.Point(6, 248);
            this.dataGridViewMT.Name = "dataGridViewMT";
            this.dataGridViewMT.Size = new System.Drawing.Size(656, 183);
            this.dataGridViewMT.TabIndex = 15;
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
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(3, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(660, 211);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBoxServerControls);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(652, 185);
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
            this.groupBoxServerControls.Location = new System.Drawing.Point(11, 4);
            this.groupBoxServerControls.Name = "groupBoxServerControls";
            this.groupBoxServerControls.Size = new System.Drawing.Size(636, 171);
            this.groupBoxServerControls.TabIndex = 1;
            this.groupBoxServerControls.TabStop = false;
            this.groupBoxServerControls.Text = "Server (Consumer)";
            // 
            // progressBarServer
            // 
            this.progressBarServer.Location = new System.Drawing.Point(127, 137);
            this.progressBarServer.Name = "progressBarServer";
            this.progressBarServer.Size = new System.Drawing.Size(178, 26);
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
            this.comboBoxAckCode.Location = new System.Drawing.Point(246, 98);
            this.comboBoxAckCode.Name = "comboBoxAckCode";
            this.comboBoxAckCode.Size = new System.Drawing.Size(77, 21);
            this.comboBoxAckCode.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(181, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "ACK Code:";
            // 
            // checkBoxServerAck
            // 
            this.checkBoxServerAck.AutoSize = true;
            this.checkBoxServerAck.Checked = true;
            this.checkBoxServerAck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxServerAck.Location = new System.Drawing.Point(13, 102);
            this.checkBoxServerAck.Name = "checkBoxServerAck";
            this.checkBoxServerAck.Size = new System.Drawing.Size(141, 17);
            this.checkBoxServerAck.TabIndex = 6;
            this.checkBoxServerAck.Text = "Send acknowledgement";
            this.checkBoxServerAck.UseVisualStyleBackColor = true;
            this.checkBoxServerAck.CheckedChanged += new System.EventHandler(this.checkBoxServerAck_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 137);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 27);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start Listening";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(135, 69);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(79, 20);
            this.textBoxServerPort.TabIndex = 5;
            // 
            // textBoxServerQueue
            // 
            this.textBoxServerQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerQueue.Location = new System.Drawing.Point(135, 44);
            this.textBoxServerQueue.Name = "textBoxServerQueue";
            this.textBoxServerQueue.Size = new System.Drawing.Size(495, 20);
            this.textBoxServerQueue.TabIndex = 4;
            this.textBoxServerQueue.Text = ".\\private$\\test";
            // 
            // textBoxServerPath
            // 
            this.textBoxServerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerPath.Location = new System.Drawing.Point(135, 20);
            this.textBoxServerPath.Name = "textBoxServerPath";
            this.textBoxServerPath.Size = new System.Drawing.Size(495, 20);
            this.textBoxServerPath.TabIndex = 3;
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
            this.radioButtonServerMLLP.CheckedChanged += new System.EventHandler(this.radioButtonServerMLLP_CheckedChanged);
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
            this.radioButtonServerMSMQ.CheckedChanged += new System.EventHandler(this.radioButtonServerMSMQ_CheckedChanged);
            // 
            // radioButtonServerFolder
            // 
            this.radioButtonServerFolder.AutoSize = true;
            this.radioButtonServerFolder.Location = new System.Drawing.Point(13, 20);
            this.radioButtonServerFolder.Name = "radioButtonServerFolder";
            this.radioButtonServerFolder.Size = new System.Drawing.Size(54, 17);
            this.radioButtonServerFolder.TabIndex = 2;
            this.radioButtonServerFolder.Text = "Folder";
            this.radioButtonServerFolder.UseVisualStyleBackColor = true;
            this.radioButtonServerFolder.CheckedChanged += new System.EventHandler(this.radioButtonServerFolder_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(652, 185);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Client";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.progressBarClient);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxClientCount);
            this.groupBox2.Controls.Add(this.textBoxClientIP);
            this.groupBox2.Controls.Add(this.label7);
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
            this.groupBox2.Location = new System.Drawing.Point(11, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(636, 172);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client (Generator)";
            // 
            // progressBarClient
            // 
            this.progressBarClient.Location = new System.Drawing.Point(378, 139);
            this.progressBarClient.Name = "progressBarClient";
            this.progressBarClient.Size = new System.Drawing.Size(178, 26);
            this.progressBarClient.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(135, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Count:";
            // 
            // textBoxClientCount
            // 
            this.textBoxClientCount.Location = new System.Drawing.Point(173, 142);
            this.textBoxClientCount.Name = "textBoxClientCount";
            this.textBoxClientCount.Size = new System.Drawing.Size(64, 20);
            this.textBoxClientCount.TabIndex = 13;
            this.textBoxClientCount.Text = "1";
            // 
            // textBoxClientIP
            // 
            this.textBoxClientIP.Location = new System.Drawing.Point(236, 64);
            this.textBoxClientIP.Name = "textBoxClientIP";
            this.textBoxClientIP.Size = new System.Drawing.Size(136, 20);
            this.textBoxClientIP.TabIndex = 6;
            this.textBoxClientIP.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "IP:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnSimSettings
            // 
            this.btnSimSettings.Location = new System.Drawing.Point(6, 137);
            this.btnSimSettings.Name = "btnSimSettings";
            this.btnSimSettings.Size = new System.Drawing.Size(109, 27);
            this.btnSimSettings.TabIndex = 12;
            this.btnSimSettings.Text = "Data Overwrites";
            this.btnSimSettings.UseVisualStyleBackColor = true;
            this.btnSimSettings.Click += new System.EventHandler(this.btnSimSettings_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(562, 137);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(62, 28);
            this.btnSend.TabIndex = 14;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // textBoxClientPort
            // 
            this.textBoxClientPort.Location = new System.Drawing.Point(138, 64);
            this.textBoxClientPort.Name = "textBoxClientPort";
            this.textBoxClientPort.Size = new System.Drawing.Size(73, 20);
            this.textBoxClientPort.TabIndex = 5;
            // 
            // textBoxClientQueue
            // 
            this.textBoxClientQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClientQueue.Location = new System.Drawing.Point(138, 40);
            this.textBoxClientQueue.Name = "textBoxClientQueue";
            this.textBoxClientQueue.Size = new System.Drawing.Size(492, 20);
            this.textBoxClientQueue.TabIndex = 4;
            this.textBoxClientQueue.Text = ".\\private$\\test";
            // 
            // textBoxClientFolder
            // 
            this.textBoxClientFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClientFolder.Location = new System.Drawing.Point(138, 16);
            this.textBoxClientFolder.Name = "textBoxClientFolder";
            this.textBoxClientFolder.Size = new System.Drawing.Size(492, 20);
            this.textBoxClientFolder.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 64);
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
            this.radioButtonClientMLLP.CheckedChanged += new System.EventHandler(this.radioButtonClientMLLP_CheckedChanged);
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
            this.radioButtonClientMSMQ.CheckedChanged += new System.EventHandler(this.radioButtonClientMSMQ_CheckedChanged);
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
            this.radioButtonClientFiles.CheckedChanged += new System.EventHandler(this.radioButtonClientFiles_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnOpenDialog);
            this.groupBox3.Controls.Add(this.textBoxSourcePath);
            this.groupBox3.Location = new System.Drawing.Point(7, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(530, 45);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Source";
            // 
            // btnOpenDialog
            // 
            this.btnOpenDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDialog.Location = new System.Drawing.Point(462, 15);
            this.btnOpenDialog.Name = "btnOpenDialog";
            this.btnOpenDialog.Size = new System.Drawing.Size(62, 23);
            this.btnOpenDialog.TabIndex = 11;
            this.btnOpenDialog.Text = "Select";
            this.btnOpenDialog.UseVisualStyleBackColor = true;
            this.btnOpenDialog.Click += new System.EventHandler(this.btnOpenFileDialog_Click);
            // 
            // textBoxSourcePath
            // 
            this.textBoxSourcePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSourcePath.Location = new System.Drawing.Point(6, 16);
            this.textBoxSourcePath.Name = "textBoxSourcePath";
            this.textBoxSourcePath.Size = new System.Drawing.Size(450, 20);
            this.textBoxSourcePath.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridViewATLogs);
            this.tabPage2.Controls.Add(this.btnRunTests);
            this.tabPage2.Controls.Add(this.textBoxTestSpecPath);
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Controls.Add(this.menuStripTestToolbar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(668, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Automated Testing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewATLogs
            // 
            this.dataGridViewATLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewATLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewATLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewATLogs.ContextMenuStrip = this.contextMenuStripATLogs;
            this.dataGridViewATLogs.Location = new System.Drawing.Point(4, 246);
            this.dataGridViewATLogs.Name = "dataGridViewATLogs";
            this.dataGridViewATLogs.Size = new System.Drawing.Size(658, 186);
            this.dataGridViewATLogs.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Timestamp";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 81;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 54;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Message";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Data";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // contextMenuStripATLogs
            // 
            this.contextMenuStripATLogs.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripATLogs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.contextMenuStripATLogs.Name = "contextMenuStripATLogs";
            this.contextMenuStripATLogs.Size = new System.Drawing.Size(102, 26);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // btnRunTests
            // 
            this.btnRunTests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunTests.Location = new System.Drawing.Point(588, 28);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(75, 23);
            this.btnRunTests.TabIndex = 8;
            this.btnRunTests.Text = "Run Tests";
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // textBoxTestSpecPath
            // 
            this.textBoxTestSpecPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTestSpecPath.Location = new System.Drawing.Point(6, 30);
            this.textBoxTestSpecPath.Name = "textBoxTestSpecPath";
            this.textBoxTestSpecPath.Size = new System.Drawing.Size(576, 20);
            this.textBoxTestSpecPath.TabIndex = 7;
            this.textBoxTestSpecPath.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxTestSpecPath_MouseClick);
            this.textBoxTestSpecPath.TextChanged += new System.EventHandler(this.textBoxTestSpecPath_TextChanged);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.ContextMenuStrip = this.contextMenuStripTreeNodeOptions;
            this.treeView1.Location = new System.Drawing.Point(6, 56);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(656, 184);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenuStripTreeNodeOptions
            // 
            this.contextMenuStripTreeNodeOptions.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripTreeNodeOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.modifyToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.expandAllNodesToolStripMenuItem});
            this.contextMenuStripTreeNodeOptions.Name = "contextMenuStripTreeNodeOptions";
            this.contextMenuStripTreeNodeOptions.Size = new System.Drawing.Size(163, 92);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.modifyToolStripMenuItem.Text = "Modify";
            this.modifyToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // expandAllNodesToolStripMenuItem
            // 
            this.expandAllNodesToolStripMenuItem.Name = "expandAllNodesToolStripMenuItem";
            this.expandAllNodesToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.expandAllNodesToolStripMenuItem.Text = "Expand all nodes";
            this.expandAllNodesToolStripMenuItem.Click += new System.EventHandler(this.expandAllNodesToolStripMenuItem_Click);
            // 
            // menuStripTestToolbar
            // 
            this.menuStripTestToolbar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripTestToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStripTestToolbar.Location = new System.Drawing.Point(3, 3);
            this.menuStripTestToolbar.Name = "menuStripTestToolbar";
            this.menuStripTestToolbar.Size = new System.Drawing.Size(662, 24);
            this.menuStripTestToolbar.TabIndex = 0;
            this.menuStripTestToolbar.Text = "menuStrip1";
            this.menuStripTestToolbar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.newToolStripMenuItem,
            this.saveTestToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openTestToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newTestToolStripMenuItem_Click);
            // 
            // saveTestToolStripMenuItem
            // 
            this.saveTestToolStripMenuItem.Name = "saveTestToolStripMenuItem";
            this.saveTestToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveTestToolStripMenuItem.Text = "Save";
            this.saveTestToolStripMenuItem.Click += new System.EventHandler(this.saveTestToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnGenerateExpOutputs);
            this.tabPage5.Controls.Add(this.comboBoxDllFolder);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.btnBrowseBTMFile);
            this.tabPage5.Controls.Add(this.textBoxMapFolder);
            this.tabPage5.Controls.Add(this.label14);
            this.tabPage5.Controls.Add(this.dataGridViewMapTestResult);
            this.tabPage5.Controls.Add(this.btnRunMapTests);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(668, 438);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Map Testing";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnGenerateExpOutputs
            // 
            this.btnGenerateExpOutputs.Location = new System.Drawing.Point(231, 33);
            this.btnGenerateExpOutputs.Name = "btnGenerateExpOutputs";
            this.btnGenerateExpOutputs.Size = new System.Drawing.Size(177, 23);
            this.btnGenerateExpOutputs.TabIndex = 23;
            this.btnGenerateExpOutputs.Text = "Generate Expected outputs";
            this.btnGenerateExpOutputs.UseVisualStyleBackColor = true;
            this.btnGenerateExpOutputs.Click += new System.EventHandler(this.btnGenerateExpOutputs_Click);
            // 
            // comboBoxDllFolder
            // 
            this.comboBoxDllFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDllFolder.FormattingEnabled = true;
            this.comboBoxDllFolder.Items.AddRange(new object[] {
            "Debug",
            "Release"});
            this.comboBoxDllFolder.Location = new System.Drawing.Point(77, 30);
            this.comboBoxDllFolder.Name = "comboBoxDllFolder";
            this.comboBoxDllFolder.Size = new System.Drawing.Size(67, 21);
            this.comboBoxDllFolder.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Dll Folder:";
            // 
            // btnBrowseBTMFile
            // 
            this.btnBrowseBTMFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseBTMFile.Location = new System.Drawing.Point(587, 7);
            this.btnBrowseBTMFile.Name = "btnBrowseBTMFile";
            this.btnBrowseBTMFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseBTMFile.TabIndex = 19;
            this.btnBrowseBTMFile.Text = "Browse";
            this.btnBrowseBTMFile.UseVisualStyleBackColor = true;
            this.btnBrowseBTMFile.Click += new System.EventHandler(this.btnBrowseBTMFile_Click);
            // 
            // textBoxMapFolder
            // 
            this.textBoxMapFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMapFolder.Location = new System.Drawing.Point(77, 7);
            this.textBoxMapFolder.Name = "textBoxMapFolder";
            this.textBoxMapFolder.Size = new System.Drawing.Size(504, 20);
            this.textBoxMapFolder.TabIndex = 18;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 17;
            this.label14.Text = "Map Folder:";
            // 
            // dataGridViewMapTestResult
            // 
            this.dataGridViewMapTestResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMapTestResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMapTestResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestStatus,
            this.TestMsg,
            this.TestMap,
            this.TestInput,
            this.TestExpOutput,
            this.TestObsOutput});
            this.dataGridViewMapTestResult.ContextMenuStrip = this.contextMenuStripMapTest;
            this.dataGridViewMapTestResult.Location = new System.Drawing.Point(8, 62);
            this.dataGridViewMapTestResult.Name = "dataGridViewMapTestResult";
            this.dataGridViewMapTestResult.Size = new System.Drawing.Size(654, 373);
            this.dataGridViewMapTestResult.TabIndex = 16;
            // 
            // TestStatus
            // 
            this.TestStatus.HeaderText = "Status";
            this.TestStatus.Name = "TestStatus";
            this.TestStatus.ReadOnly = true;
            // 
            // TestMsg
            // 
            this.TestMsg.HeaderText = "Message";
            this.TestMsg.Name = "TestMsg";
            this.TestMsg.ReadOnly = true;
            // 
            // TestMap
            // 
            this.TestMap.HeaderText = "Map";
            this.TestMap.Name = "TestMap";
            this.TestMap.ReadOnly = true;
            // 
            // TestInput
            // 
            this.TestInput.HeaderText = "Input";
            this.TestInput.Name = "TestInput";
            this.TestInput.ReadOnly = true;
            // 
            // TestExpOutput
            // 
            this.TestExpOutput.HeaderText = "Expected Output";
            this.TestExpOutput.Name = "TestExpOutput";
            this.TestExpOutput.ReadOnly = true;
            // 
            // TestObsOutput
            // 
            this.TestObsOutput.HeaderText = "Observed Output";
            this.TestObsOutput.Name = "TestObsOutput";
            this.TestObsOutput.ReadOnly = true;
            // 
            // contextMenuStripMapTest
            // 
            this.contextMenuStripMapTest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareSideBySideToolStripMenuItem});
            this.contextMenuStripMapTest.Name = "contextMenuStripMapTest";
            this.contextMenuStripMapTest.Size = new System.Drawing.Size(188, 26);
            // 
            // compareSideBySideToolStripMenuItem
            // 
            this.compareSideBySideToolStripMenuItem.Name = "compareSideBySideToolStripMenuItem";
            this.compareSideBySideToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.compareSideBySideToolStripMenuItem.Text = "Compare side by side";
            this.compareSideBySideToolStripMenuItem.Click += new System.EventHandler(this.compareSideBySideToolStripMenuItem_Click);
            // 
            // btnRunMapTests
            // 
            this.btnRunMapTests.Location = new System.Drawing.Point(150, 33);
            this.btnRunMapTests.Name = "btnRunMapTests";
            this.btnRunMapTests.Size = new System.Drawing.Size(75, 23);
            this.btnRunMapTests.TabIndex = 15;
            this.btnRunMapTests.Text = "Run Tests";
            this.btnRunMapTests.UseVisualStyleBackColor = true;
            this.btnRunMapTests.Click += new System.EventHandler(this.btnRunMapTests_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.progressBarReport);
            this.tabPage6.Controls.Add(this.btnEditRegRepIgnoreList);
            this.tabPage6.Controls.Add(this.textBoxRegressionReportStatus);
            this.tabPage6.Controls.Add(this.listBoxRegressionReportIgnoreList);
            this.tabPage6.Controls.Add(this.label13);
            this.tabPage6.Controls.Add(this.btnNewFolderOpenDialog);
            this.tabPage6.Controls.Add(this.btnOldFolderOpenDialog);
            this.tabPage6.Controls.Add(this.textBoxNewFolder);
            this.tabPage6.Controls.Add(this.textBoxOldFolder);
            this.tabPage6.Controls.Add(this.label11);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Controls.Add(this.btnGenerateReport);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(668, 438);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Regression Report";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // progressBarReport
            // 
            this.progressBarReport.Location = new System.Drawing.Point(515, 73);
            this.progressBarReport.Name = "progressBarReport";
            this.progressBarReport.Size = new System.Drawing.Size(138, 20);
            this.progressBarReport.TabIndex = 19;
            // 
            // btnEditRegRepIgnoreList
            // 
            this.btnEditRegRepIgnoreList.Location = new System.Drawing.Point(12, 97);
            this.btnEditRegRepIgnoreList.Name = "btnEditRegRepIgnoreList";
            this.btnEditRegRepIgnoreList.Size = new System.Drawing.Size(58, 23);
            this.btnEditRegRepIgnoreList.TabIndex = 18;
            this.btnEditRegRepIgnoreList.Text = "Edit";
            this.btnEditRegRepIgnoreList.UseVisualStyleBackColor = true;
            this.btnEditRegRepIgnoreList.Click += new System.EventHandler(this.btnEditRegRepIgnoreList_Click);
            // 
            // textBoxRegressionReportStatus
            // 
            this.textBoxRegressionReportStatus.Location = new System.Drawing.Point(208, 73);
            this.textBoxRegressionReportStatus.Multiline = true;
            this.textBoxRegressionReportStatus.Name = "textBoxRegressionReportStatus";
            this.textBoxRegressionReportStatus.ReadOnly = true;
            this.textBoxRegressionReportStatus.Size = new System.Drawing.Size(301, 92);
            this.textBoxRegressionReportStatus.TabIndex = 17;
            // 
            // listBoxRegressionReportIgnoreList
            // 
            this.listBoxRegressionReportIgnoreList.FormattingEnabled = true;
            this.listBoxRegressionReportIgnoreList.Location = new System.Drawing.Point(76, 70);
            this.listBoxRegressionReportIgnoreList.Name = "listBoxRegressionReportIgnoreList";
            this.listBoxRegressionReportIgnoreList.Size = new System.Drawing.Size(120, 95);
            this.listBoxRegressionReportIgnoreList.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Ignore list:";
            // 
            // btnNewFolderOpenDialog
            // 
            this.btnNewFolderOpenDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewFolderOpenDialog.Location = new System.Drawing.Point(626, 47);
            this.btnNewFolderOpenDialog.Name = "btnNewFolderOpenDialog";
            this.btnNewFolderOpenDialog.Size = new System.Drawing.Size(28, 20);
            this.btnNewFolderOpenDialog.TabIndex = 14;
            this.btnNewFolderOpenDialog.Text = "...";
            this.btnNewFolderOpenDialog.UseVisualStyleBackColor = true;
            this.btnNewFolderOpenDialog.Click += new System.EventHandler(this.btnNewFolderOpenDialog_Click);
            // 
            // btnOldFolderOpenDialog
            // 
            this.btnOldFolderOpenDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOldFolderOpenDialog.Location = new System.Drawing.Point(626, 15);
            this.btnOldFolderOpenDialog.Name = "btnOldFolderOpenDialog";
            this.btnOldFolderOpenDialog.Size = new System.Drawing.Size(28, 20);
            this.btnOldFolderOpenDialog.TabIndex = 13;
            this.btnOldFolderOpenDialog.Text = "...";
            this.btnOldFolderOpenDialog.UseVisualStyleBackColor = true;
            this.btnOldFolderOpenDialog.Click += new System.EventHandler(this.btnOldFolderOpenDialog_Click);
            // 
            // textBoxNewFolder
            // 
            this.textBoxNewFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewFolder.Location = new System.Drawing.Point(76, 47);
            this.textBoxNewFolder.Name = "textBoxNewFolder";
            this.textBoxNewFolder.Size = new System.Drawing.Size(544, 20);
            this.textBoxNewFolder.TabIndex = 12;
            // 
            // textBoxOldFolder
            // 
            this.textBoxOldFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOldFolder.Location = new System.Drawing.Point(76, 16);
            this.textBoxOldFolder.Name = "textBoxOldFolder";
            this.textBoxOldFolder.Size = new System.Drawing.Size(544, 20);
            this.textBoxOldFolder.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "New folder:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Old folder:";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateReport.Location = new System.Drawing.Point(515, 97);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(139, 21);
            this.btnGenerateReport.TabIndex = 8;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // openTestSuiteToolStripMenuItem
            // 
            this.openTestSuiteToolStripMenuItem.Name = "openTestSuiteToolStripMenuItem";
            this.openTestSuiteToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.openTestSuiteToolStripMenuItem.Text = "File";
            // 
            // newTestToolStripMenuItem
            // 
            this.newTestToolStripMenuItem.Name = "newTestToolStripMenuItem";
            this.newTestToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newTestToolStripMenuItem.Text = "New";
            this.newTestToolStripMenuItem.Click += new System.EventHandler(this.newTestToolStripMenuItem_Click);
            // 
            // openTestToolStripMenuItem
            // 
            this.openTestToolStripMenuItem.Name = "openTestToolStripMenuItem";
            this.openTestToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openTestToolStripMenuItem.Text = "Open";
            this.openTestToolStripMenuItem.Click += new System.EventHandler(this.openTestToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 472);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripTestToolbar;
            this.Name = "MainForm";
            this.Text = "BizTester 5.1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.contextMenuStripMT.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMT)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBoxServerControls.ResumeLayout(false);
            this.groupBoxServerControls.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewATLogs)).EndInit();
            this.contextMenuStripATLogs.ResumeLayout(false);
            this.contextMenuStripTreeNodeOptions.ResumeLayout(false);
            this.menuStripTestToolbar.ResumeLayout(false);
            this.menuStripTestToolbar.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMapTestResult)).EndInit();
            this.contextMenuStripMapTest.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMT;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewMT;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBoxServerControls;
        private System.Windows.Forms.Button btnStart;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSimSettings;
        private System.Windows.Forms.Button btnSend;
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
        private System.Windows.Forms.Button btnOpenDialog;
        private System.Windows.Forms.TextBox textBoxSourcePath;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem openTestSuiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTestToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStripTestToolbar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTestToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTreeNodeOptions;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxTestSpecPath;
        private System.Windows.Forms.Button btnRunTests;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandAllNodesToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewATLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripATLogs;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxServerAck;
        private System.Windows.Forms.TextBox textBoxClientIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxClientCount;
        private System.Windows.Forms.ComboBox comboBoxAckCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createReportToolStripMenuItem;
        private System.Windows.Forms.Button btnColumns;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridViewMapTestResult;
        private System.Windows.Forms.Button btnBrowseBTMFile;
        private System.Windows.Forms.TextBox textBoxMapFolder;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnRunMapTests;
        private System.Windows.Forms.ComboBox comboBoxDllFolder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGenerateExpOutputs;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestExpOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestObsOutput;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMapTest;
        private System.Windows.Forms.ToolStripMenuItem compareSideBySideToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnEditRegRepIgnoreList;
        private System.Windows.Forms.TextBox textBoxRegressionReportStatus;
        private System.Windows.Forms.ListBox listBoxRegressionReportIgnoreList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnNewFolderOpenDialog;
        private System.Windows.Forms.Button btnOldFolderOpenDialog;
        private System.Windows.Forms.TextBox textBoxNewFolder;
        private System.Windows.Forms.TextBox textBoxOldFolder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.ProgressBar progressBarReport;
        private System.Windows.Forms.ProgressBar progressBarServer;
        private System.Windows.Forms.ProgressBar progressBarClient;
    }
}

