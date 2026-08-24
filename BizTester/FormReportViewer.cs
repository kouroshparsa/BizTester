using BizTester.Helpers;
using BizTester.Models;
using BizTester.UIHelpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BizTester
{
    public partial class FormReportViewer : Form
    {
        private Report report;
        public FormReportViewer(DataGridView dgv)
        {
            InitializeComponent();
            Theme.ApplyContextMenuTheme(contextMenuStripReportView);
            report = ReportController.CreateReport(dgv);
            foreach(KeyValuePair<string, ReportMsg>kv in report.messages)
            {
                dataGridView1.Rows.Add(kv.Key, kv.Value.ackedOn == null ? "No" : "Yes", kv.Value.receivedOn == null ? "No" : "Yes", kv.Value.ackedOn, kv.Value.receivedOn);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 1,
                RestoreDirectory = true,
                DefaultExt = "xlsx",
                AddExtension = true
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                ReportController.ExportReport(report, saveFileDialog.FileName);
                MessageBox.Show(
                "Data Exported Successfully!",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to export data: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
