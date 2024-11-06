namespace BizTester
{
    partial class ValidationEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidationEditorForm));
            this.dataGridViewValidations = new System.Windows.Forms.DataGridView();
            this.btnSaveTest = new System.Windows.Forms.Button();
            this.btnCancelTest = new System.Windows.Forms.Button();
            this.DataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewValidations)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewValidations
            // 
            this.dataGridViewValidations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewValidations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewValidations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataType,
            this.Path,
            this.Value,
            this.Delete});
            this.dataGridViewValidations.Location = new System.Drawing.Point(-4, 32);
            this.dataGridViewValidations.Name = "dataGridViewValidations";
            this.dataGridViewValidations.Size = new System.Drawing.Size(549, 189);
            this.dataGridViewValidations.TabIndex = 2;
            this.dataGridViewValidations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTest_CellClick);
            this.dataGridViewValidations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTest_CellContentClick);
            // 
            // btnSaveTest
            // 
            this.btnSaveTest.Location = new System.Drawing.Point(12, 3);
            this.btnSaveTest.Name = "btnSaveTest";
            this.btnSaveTest.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTest.TabIndex = 3;
            this.btnSaveTest.Text = "Save";
            this.btnSaveTest.UseVisualStyleBackColor = true;
            this.btnSaveTest.Click += new System.EventHandler(this.btnSaveTest_Click);
            // 
            // btnCancelTest
            // 
            this.btnCancelTest.Location = new System.Drawing.Point(103, 3);
            this.btnCancelTest.Name = "btnCancelTest";
            this.btnCancelTest.Size = new System.Drawing.Size(75, 23);
            this.btnCancelTest.TabIndex = 4;
            this.btnCancelTest.Text = "Cancel";
            this.btnCancelTest.UseVisualStyleBackColor = true;
            this.btnCancelTest.Click += new System.EventHandler(this.btnCancelTest_Click);
            // 
            // DataType
            // 
            this.DataType.HeaderText = "DataType";
            this.DataType.Items.AddRange(new object[] {
            "XML",
            "Json",
            "HL7V2"});
            this.DataType.Name = "DataType";
            // 
            // Path
            // 
            this.Path.HeaderText = "Path";
            this.Path.Name = "Path";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // ValidationEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 225);
            this.Controls.Add(this.btnCancelTest);
            this.Controls.Add(this.btnSaveTest);
            this.Controls.Add(this.dataGridViewValidations);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValidationEditorForm";
            this.Text = "Validation Editor";
            this.Load += new System.EventHandler(this.TestSpecForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewValidations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewValidations;
        private System.Windows.Forms.Button btnSaveTest;
        private System.Windows.Forms.Button btnCancelTest;
        private System.Windows.Forms.DataGridViewComboBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delete;
    }
}