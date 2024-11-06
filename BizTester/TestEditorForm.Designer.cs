namespace BizTester
{
    partial class TestEditorForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestEditorForm));
            this.dataGridViewTest = new System.Windows.Forms.DataGridView();
            this.btnSaveTest = new System.Windows.Forms.Button();
            this.btnCancelTest = new System.Windows.Forms.Button();
            this.textBoxTestName = new System.Windows.Forms.TextBox();
            this.DataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Protocol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidationSet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTest)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTest
            // 
            this.dataGridViewTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataType,
            this.Protocol,
            this.Value,
            this.DataFile,
            this.ValidationSet,
            this.Delete});
            this.dataGridViewTest.Location = new System.Drawing.Point(-4, 32);
            this.dataGridViewTest.Name = "dataGridViewTest";
            this.dataGridViewTest.Size = new System.Drawing.Size(632, 189);
            this.dataGridViewTest.TabIndex = 2;
            this.dataGridViewTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTest_CellClick);
            this.dataGridViewTest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTest_CellContentClick);
            this.dataGridViewTest.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTest_CellEndEdit);
            // 
            // btnSaveTest
            // 
            this.btnSaveTest.Location = new System.Drawing.Point(195, 3);
            this.btnSaveTest.Name = "btnSaveTest";
            this.btnSaveTest.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTest.TabIndex = 3;
            this.btnSaveTest.Text = "Save";
            this.btnSaveTest.UseVisualStyleBackColor = true;
            this.btnSaveTest.Click += new System.EventHandler(this.btnSaveTest_Click);
            // 
            // btnCancelTest
            // 
            this.btnCancelTest.Location = new System.Drawing.Point(276, 3);
            this.btnCancelTest.Name = "btnCancelTest";
            this.btnCancelTest.Size = new System.Drawing.Size(75, 23);
            this.btnCancelTest.TabIndex = 4;
            this.btnCancelTest.Text = "Cancel";
            this.btnCancelTest.UseVisualStyleBackColor = true;
            this.btnCancelTest.Click += new System.EventHandler(this.btnCancelTest_Click);
            // 
            // textBoxTestName
            // 
            this.textBoxTestName.Location = new System.Drawing.Point(2, 6);
            this.textBoxTestName.Name = "textBoxTestName";
            this.textBoxTestName.Size = new System.Drawing.Size(187, 20);
            this.textBoxTestName.TabIndex = 5;
            this.textBoxTestName.Text = "test1";
            // 
            // DataType
            // 
            this.DataType.HeaderText = "DataType";
            this.DataType.Items.AddRange(new object[] {
            "Input",
            "Output"});
            this.DataType.Name = "DataType";
            // 
            // Protocol
            // 
            this.Protocol.HeaderText = "Protocol";
            this.Protocol.Items.AddRange(new object[] {
            "File",
            "MLLP",
            "MSMQ"});
            this.Protocol.Name = "Protocol";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // DataFile
            // 
            this.DataFile.HeaderText = "Data File";
            this.DataFile.Name = "DataFile";
            this.DataFile.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ValidationSet
            // 
            this.ValidationSet.HeaderText = "ValidationSet";
            this.ValidationSet.Name = "ValidationSet";
            this.ValidationSet.ReadOnly = true;
            // 
            // Delete
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.NullValue = "🗑";
            this.Delete.DefaultCellStyle = dataGridViewCellStyle1;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Delete.ToolTipText = "Delete the row";
            // 
            // TestEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 225);
            this.Controls.Add(this.textBoxTestName);
            this.Controls.Add(this.btnCancelTest);
            this.Controls.Add(this.btnSaveTest);
            this.Controls.Add(this.dataGridViewTest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestEditorForm";
            this.Text = "Test Editor";
            this.Load += new System.EventHandler(this.TestSpecForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTest;
        private System.Windows.Forms.Button btnSaveTest;
        private System.Windows.Forms.Button btnCancelTest;
        private System.Windows.Forms.TextBox textBoxTestName;
        private System.Windows.Forms.DataGridViewComboBoxColumn DataType;
        private System.Windows.Forms.DataGridViewComboBoxColumn Protocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidationSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delete;
    }
}