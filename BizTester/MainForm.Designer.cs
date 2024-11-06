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
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewMT = new System.Windows.Forms.DataGridView();
            this.Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBoxServerControls = new System.Windows.Forms.GroupBox();
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
            this.btnOpenFileDialog = new System.Windows.Forms.Button();
            this.textBoxSourceFilePath = new System.Windows.Forms.TextBox();
            this.radioButtonGenFromFile = new System.Windows.Forms.RadioButton();
            this.radioButtonSimulate = new System.Windows.Forms.RadioButton();
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
            this.SuspendLayout();
            // 
            // contextMenuStripMT
            // 
            this.contextMenuStripMT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCopy,
            this.exportToolStripMenuItem,
            this.toolStripMenuItemClear});
            this.contextMenuStripMT.Name = "contextMenuStrip1";
            this.contextMenuStripMT.Size = new System.Drawing.Size(142, 70);
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItemCopy.Text = "Copy Data";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(141, 22);
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
            this.tabControl1.Location = new System.Drawing.Point(0, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(585, 464);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewMT);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(577, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manual Testing";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.dataGridViewMT.Location = new System.Drawing.Point(6, 213);
            this.dataGridViewMT.Name = "dataGridViewMT";
            this.dataGridViewMT.Size = new System.Drawing.Size(568, 218);
            this.dataGridViewMT.TabIndex = 4;
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
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(3, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(568, 205);
            this.tabControl2.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBoxServerControls);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(560, 179);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Server";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBoxServerControls
            // 
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
            this.groupBoxServerControls.Size = new System.Drawing.Size(543, 171);
            this.groupBoxServerControls.TabIndex = 1;
            this.groupBoxServerControls.TabStop = false;
            this.groupBoxServerControls.Text = "Server (Consumer)";
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
            this.comboBoxAckCode.TabIndex = 13;
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
            this.checkBoxServerAck.TabIndex = 11;
            this.checkBoxServerAck.Text = "Send acknowledgement";
            this.checkBoxServerAck.UseVisualStyleBackColor = true;
            this.checkBoxServerAck.CheckedChanged += new System.EventHandler(this.checkBoxServerAck_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 137);
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
            this.textBoxServerQueue.Size = new System.Drawing.Size(402, 20);
            this.textBoxServerQueue.TabIndex = 7;
            this.textBoxServerQueue.Text = ".\\private$\\test";
            // 
            // textBoxServerPath
            // 
            this.textBoxServerPath.Location = new System.Drawing.Point(135, 20);
            this.textBoxServerPath.Name = "textBoxServerPath";
            this.textBoxServerPath.Size = new System.Drawing.Size(402, 20);
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
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(560, 179);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Client";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
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
            this.groupBox2.Size = new System.Drawing.Size(543, 171);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client (Generator)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(169, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Count:";
            // 
            // textBoxClientCount
            // 
            this.textBoxClientCount.Location = new System.Drawing.Point(210, 143);
            this.textBoxClientCount.Name = "textBoxClientCount";
            this.textBoxClientCount.Size = new System.Drawing.Size(64, 20);
            this.textBoxClientCount.TabIndex = 20;
            this.textBoxClientCount.Text = "1";
            // 
            // textBoxClientIP
            // 
            this.textBoxClientIP.Location = new System.Drawing.Point(236, 64);
            this.textBoxClientIP.Name = "textBoxClientIP";
            this.textBoxClientIP.Size = new System.Drawing.Size(136, 20);
            this.textBoxClientIP.TabIndex = 19;
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
            this.btnSimSettings.Location = new System.Drawing.Point(7, 136);
            this.btnSimSettings.Name = "btnSimSettings";
            this.btnSimSettings.Size = new System.Drawing.Size(109, 27);
            this.btnSimSettings.TabIndex = 17;
            this.btnSimSettings.Text = "Simulation Settings";
            this.btnSimSettings.UseVisualStyleBackColor = true;
            this.btnSimSettings.Click += new System.EventHandler(this.btnSimSettings_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(281, 137);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 28);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // textBoxClientPort
            // 
            this.textBoxClientPort.Location = new System.Drawing.Point(138, 64);
            this.textBoxClientPort.Name = "textBoxClientPort";
            this.textBoxClientPort.Size = new System.Drawing.Size(73, 20);
            this.textBoxClientPort.TabIndex = 14;
            // 
            // textBoxClientQueue
            // 
            this.textBoxClientQueue.Location = new System.Drawing.Point(138, 40);
            this.textBoxClientQueue.Name = "textBoxClientQueue";
            this.textBoxClientQueue.Size = new System.Drawing.Size(399, 20);
            this.textBoxClientQueue.TabIndex = 13;
            this.textBoxClientQueue.Text = ".\\private$\\test";
            // 
            // textBoxClientFolder
            // 
            this.textBoxClientFolder.Location = new System.Drawing.Point(138, 16);
            this.textBoxClientFolder.Name = "textBoxClientFolder";
            this.textBoxClientFolder.Size = new System.Drawing.Size(399, 20);
            this.textBoxClientFolder.TabIndex = 12;
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
            this.groupBox3.Size = new System.Drawing.Size(530, 45);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Source";
            // 
            // btnOpenFileDialog
            // 
            this.btnOpenFileDialog.Enabled = false;
            this.btnOpenFileDialog.Location = new System.Drawing.Point(489, 15);
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
            this.textBoxSourceFilePath.Size = new System.Drawing.Size(316, 20);
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
            this.tabPage2.Size = new System.Drawing.Size(577, 438);
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
            this.dataGridViewATLogs.Size = new System.Drawing.Size(568, 186);
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
            this.btnRunTests.Location = new System.Drawing.Point(496, 27);
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
            this.textBoxTestSpecPath.Size = new System.Drawing.Size(484, 20);
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
            this.treeView1.Size = new System.Drawing.Size(565, 184);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenuStripTreeNodeOptions
            // 
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
            this.menuStripTestToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStripTestToolbar.Location = new System.Drawing.Point(3, 3);
            this.menuStripTestToolbar.Name = "menuStripTestToolbar";
            this.menuStripTestToolbar.Size = new System.Drawing.Size(571, 24);
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
            this.ClientSize = new System.Drawing.Size(588, 472);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripTestToolbar;
            this.Name = "MainForm";
            this.Text = "BizTester 3.0.0";
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMT;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
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
        private System.Windows.Forms.Button btnOpenFileDialog;
        private System.Windows.Forms.TextBox textBoxSourceFilePath;
        private System.Windows.Forms.RadioButton radioButtonGenFromFile;
        private System.Windows.Forms.RadioButton radioButtonSimulate;
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
    }
}

