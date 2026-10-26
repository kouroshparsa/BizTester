namespace BizTester
{
    partial class FormTransformerSettingsHelp
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
            this.dataGridViewHelp = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHelp
            // 
            this.dataGridViewHelp.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewHelp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewHelp.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHelp.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewHelp.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewHelp.Name = "dataGridViewHelp";
            this.dataGridViewHelp.RowHeadersWidth = 62;
            this.dataGridViewHelp.Size = new System.Drawing.Size(1260, 421);
            this.dataGridViewHelp.TabIndex = 1;
            // 
            // FormTransformerSettingsHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 421);
            this.Controls.Add(this.dataGridViewHelp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTransformerSettingsHelp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Transformation Guide";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewHelp;
    }
}