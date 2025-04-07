namespace BizTester
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxServerPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxServerQueue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonServerMLLP = new System.Windows.Forms.RadioButton();
            this.radioButtonServerMSMQ = new System.Windows.Forms.RadioButton();
            this.radioButtonServerFolder = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.checkBoxAck = new System.Windows.Forms.CheckBox();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.textBoxClientFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxClientQueue = new System.Windows.Forms.TextBox();
            this.textBoxClientPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonClientMSMQ = new System.Windows.Forms.RadioButton();
            this.radioButtonClientMLLP = new System.Windows.Forms.RadioButton();
            this.radioButtonClientFiles = new System.Windows.Forms.RadioButton();
            this.Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxServerPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxServerQueue);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radioButtonServerMLLP);
            this.groupBox1.Controls.Add(this.radioButtonServerMSMQ);
            this.groupBox1.Controls.Add(this.radioButtonServerFolder);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.checkBoxAck);
            this.groupBox1.Controls.Add(this.textBoxServerPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 326);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server (Consumer)";
            // 
            // textBoxServerPath
            // 
            this.textBoxServerPath.Location = new System.Drawing.Point(281, 50);
            this.textBoxServerPath.Name = "textBoxServerPath";
            this.textBoxServerPath.Size = new System.Drawing.Size(464, 39);
            this.textBoxServerPath.TabIndex = 10;
            this.textBoxServerPath.Text = "C:\\temp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Path:";
            // 
            // textBoxServerQueue
            // 
            this.textBoxServerQueue.Location = new System.Drawing.Point(281, 110);
            this.textBoxServerQueue.Name = "textBoxServerQueue";
            this.textBoxServerQueue.Size = new System.Drawing.Size(464, 39);
            this.textBoxServerQueue.TabIndex = 8;
            this.textBoxServerQueue.Text = ".\\private$\\test";
            this.textBoxServerQueue.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "Queue:";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // radioButtonServerMLLP
            // 
            this.radioButtonServerMLLP.AutoSize = true;
            this.radioButtonServerMLLP.Location = new System.Drawing.Point(30, 170);
            this.radioButtonServerMLLP.Name = "radioButtonServerMLLP";
            this.radioButtonServerMLLP.Size = new System.Drawing.Size(102, 36);
            this.radioButtonServerMLLP.TabIndex = 6;
            this.radioButtonServerMLLP.Text = "MLLP";
            this.radioButtonServerMLLP.UseVisualStyleBackColor = true;
            // 
            // radioButtonServerMSMQ
            // 
            this.radioButtonServerMSMQ.AutoSize = true;
            this.radioButtonServerMSMQ.Checked = true;
            this.radioButtonServerMSMQ.Location = new System.Drawing.Point(30, 110);
            this.radioButtonServerMSMQ.Name = "radioButtonServerMSMQ";
            this.radioButtonServerMSMQ.Size = new System.Drawing.Size(120, 36);
            this.radioButtonServerMSMQ.TabIndex = 5;
            this.radioButtonServerMSMQ.TabStop = true;
            this.radioButtonServerMSMQ.Text = "MSMQ";
            this.radioButtonServerMSMQ.UseVisualStyleBackColor = true;
            // 
            // radioButtonServerFolder
            // 
            this.radioButtonServerFolder.AutoSize = true;
            this.radioButtonServerFolder.Location = new System.Drawing.Point(30, 50);
            this.radioButtonServerFolder.Name = "radioButtonServerFolder";
            this.radioButtonServerFolder.Size = new System.Drawing.Size(112, 36);
            this.radioButtonServerFolder.TabIndex = 4;
            this.radioButtonServerFolder.Text = "Folder";
            this.radioButtonServerFolder.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(0, 274);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(228, 46);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start Listening";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // checkBoxAck
            // 
            this.checkBoxAck.AutoSize = true;
            this.checkBoxAck.Checked = true;
            this.checkBoxAck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAck.Location = new System.Drawing.Point(30, 221);
            this.checkBoxAck.Name = "checkBoxAck";
            this.checkBoxAck.Size = new System.Drawing.Size(189, 36);
            this.checkBoxAck.TabIndex = 2;
            this.checkBoxAck.Text = "Acknowledge";
            this.checkBoxAck.UseVisualStyleBackColor = true;
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(281, 171);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(133, 39);
            this.textBoxServerPort.TabIndex = 1;
            this.textBoxServerPort.Text = "1199";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Timestamp,
            this.Type,
            this.Data});
            this.dataGridView1.Location = new System.Drawing.Point(12, 344);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 41;
            this.dataGridView1.Size = new System.Drawing.Size(1608, 647);
            this.dataGridView1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.textBoxClientFolder);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxClientQueue);
            this.groupBox2.Controls.Add(this.textBoxClientPort);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.radioButtonClientMSMQ);
            this.groupBox2.Controls.Add(this.radioButtonClientMLLP);
            this.groupBox2.Controls.Add(this.radioButtonClientFiles);
            this.groupBox2.Location = new System.Drawing.Point(794, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(813, 311);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client (Generator)";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(327, 230);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(150, 46);
            this.btnSend.TabIndex = 14;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // textBoxClientFolder
            // 
            this.textBoxClientFolder.Location = new System.Drawing.Point(327, 45);
            this.textBoxClientFolder.Name = "textBoxClientFolder";
            this.textBoxClientFolder.Size = new System.Drawing.Size(464, 39);
            this.textBoxClientFolder.TabIndex = 13;
            this.textBoxClientFolder.Text = "C:\\temp";
            this.textBoxClientFolder.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "Queue:";
            // 
            // textBoxClientQueue
            // 
            this.textBoxClientQueue.Location = new System.Drawing.Point(327, 105);
            this.textBoxClientQueue.Name = "textBoxClientQueue";
            this.textBoxClientQueue.Size = new System.Drawing.Size(464, 39);
            this.textBoxClientQueue.TabIndex = 12;
            this.textBoxClientQueue.Text = ".\\private$\\test";
            // 
            // textBoxClientPort
            // 
            this.textBoxClientPort.Location = new System.Drawing.Point(327, 166);
            this.textBoxClientPort.Name = "textBoxClientPort";
            this.textBoxClientPort.Size = new System.Drawing.Size(133, 39);
            this.textBoxClientPort.TabIndex = 11;
            this.textBoxClientPort.Text = "1199";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Folder Path:";
            // 
            // radioButtonClientMSMQ
            // 
            this.radioButtonClientMSMQ.AutoSize = true;
            this.radioButtonClientMSMQ.Checked = true;
            this.radioButtonClientMSMQ.Location = new System.Drawing.Point(53, 110);
            this.radioButtonClientMSMQ.Name = "radioButtonClientMSMQ";
            this.radioButtonClientMSMQ.Size = new System.Drawing.Size(120, 36);
            this.radioButtonClientMSMQ.TabIndex = 2;
            this.radioButtonClientMSMQ.TabStop = true;
            this.radioButtonClientMSMQ.Text = "MSMQ";
            this.radioButtonClientMSMQ.UseVisualStyleBackColor = true;
            // 
            // radioButtonClientMLLP
            // 
            this.radioButtonClientMLLP.AutoSize = true;
            this.radioButtonClientMLLP.Location = new System.Drawing.Point(53, 171);
            this.radioButtonClientMLLP.Name = "radioButtonClientMLLP";
            this.radioButtonClientMLLP.Size = new System.Drawing.Size(102, 36);
            this.radioButtonClientMLLP.TabIndex = 1;
            this.radioButtonClientMLLP.Text = "MLLP";
            this.radioButtonClientMLLP.UseVisualStyleBackColor = true;
            // 
            // radioButtonClientFiles
            // 
            this.radioButtonClientFiles.AutoSize = true;
            this.radioButtonClientFiles.Location = new System.Drawing.Point(53, 45);
            this.radioButtonClientFiles.Name = "radioButtonClientFiles";
            this.radioButtonClientFiles.Size = new System.Drawing.Size(82, 36);
            this.radioButtonClientFiles.TabIndex = 0;
            this.radioButtonClientFiles.Text = "File";
            this.radioButtonClientFiles.UseVisualStyleBackColor = true;
            // 
            // Timestamp
            // 
            this.Timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Timestamp.FillWeight = 279.2101F;
            this.Timestamp.HeaderText = "Timestamp";
            this.Timestamp.MaxInputLength = 20;
            this.Timestamp.MinimumWidth = 10;
            this.Timestamp.Name = "Timestamp";
            this.Timestamp.ReadOnly = true;
            this.Timestamp.Width = 177;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Type.FillWeight = 19.23077F;
            this.Type.HeaderText = "Type";
            this.Type.MaxInputLength = 20;
            this.Type.MinimumWidth = 10;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 110;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Data.FillWeight = 1.559211F;
            this.Data.HeaderText = "Data";
            this.Data.MinimumWidth = 10;
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1632, 1012);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "BizTester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox checkBoxAck;
        private TextBox textBoxServerPort;
        private Label label1;
        private Button btnStart;
        private DataGridView dataGridView1;
        private TextBox textBoxServerQueue;
        private Label label2;
        private RadioButton radioButtonServerMLLP;
        private RadioButton radioButtonServerMSMQ;
        private RadioButton radioButtonServerFolder;
        private GroupBox groupBox2;
        private TextBox textBoxServerPath;
        private Label label3;
        private Label label6;
        private Label label5;
        private RadioButton radioButtonClientMSMQ;
        private RadioButton radioButtonClientMLLP;
        private TextBox textBoxClientQueue;
        private TextBox textBoxClientPort;
        private Button btnSend;
        private TextBox textBoxClientFolder;
        private Label label4;
        private RadioButton radioButtonClientFiles;
        private DataGridViewTextBoxColumn Timestamp;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Data;
    }
}