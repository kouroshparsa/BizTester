namespace BizTester
{
    partial class SimulationSettingsHelpForm
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
            this.dataGridViewHelp = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHelp
            // 
            this.dataGridViewHelp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHelp.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewHelp.Name = "dataGridViewHelp";
            this.dataGridViewHelp.Size = new System.Drawing.Size(426, 354);
            this.dataGridViewHelp.TabIndex = 1;
            // 
            // SimulationSettingsHelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 354);
            this.Controls.Add(this.dataGridViewHelp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimulationSettingsHelpForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Overwrite Settings Guide";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewHelp;
    }
}