namespace BizTester
{
    partial class FormReportViewer
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MessageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Received = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AckedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripReportView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStripReportView.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MessageID,
            this.Acked,
            this.Received,
            this.AckedOn,
            this.ReceivedOn});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStripReportView;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1200, 692);
            this.dataGridView1.TabIndex = 0;
            // 
            // MessageID
            // 
            this.MessageID.HeaderText = "Message ID";
            this.MessageID.Name = "MessageID";
            this.MessageID.ReadOnly = true;
            // 
            // Acked
            // 
            this.Acked.HeaderText = "Acked";
            this.Acked.Name = "Acked";
            this.Acked.ReadOnly = true;
            // 
            // Received
            // 
            this.Received.HeaderText = "Received";
            this.Received.Name = "Received";
            this.Received.ReadOnly = true;
            // 
            // AckedOn
            // 
            this.AckedOn.HeaderText = "Acked On";
            this.AckedOn.Name = "AckedOn";
            this.AckedOn.ReadOnly = true;
            // 
            // ReceivedOn
            // 
            this.ReceivedOn.HeaderText = "ReceivedOn";
            this.ReceivedOn.Name = "ReceivedOn";
            this.ReceivedOn.ReadOnly = true;
            // 
            // contextMenuStripReportView
            // 
            this.contextMenuStripReportView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.contextMenuStripReportView.Name = "contextMenuStripReportView";
            this.contextMenuStripReportView.Size = new System.Drawing.Size(108, 26);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // FormReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "FormReportViewer";
            this.ShowIcon = false;
            this.Text = "Report Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStripReportView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripReportView;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acked;
        private System.Windows.Forms.DataGridViewTextBoxColumn Received;
        private System.Windows.Forms.DataGridViewTextBoxColumn AckedOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedOn;
    }
}