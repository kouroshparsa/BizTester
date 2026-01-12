using BizTester.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BizTester.Helpers
{
    class ReportController
    {

        public static void Create(DataGridView dataGridViewMT)
        {
            var report = new Report(dataGridViewMT);
            if (!string.IsNullOrEmpty(report.error))
            {
                MessageBox.Show(report.error, "Warning");
            }
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            Excel._Worksheet worksheet = excelApp.ActiveSheet;

            // Add report to Excel
            worksheet.Cells[1, 1] = "Message ID";
            worksheet.Cells[1, 2] = "Acked";
            worksheet.Cells[1, 3] = "Received";
            worksheet.Cells[1, 4] = "Duration (S)";

            int row = 2;
            foreach(KeyValuePair<string, ReportMsg> kv in report.messages)
            {
                worksheet.Cells[row, 1] = kv.Key;
                worksheet.Cells[row, 2] = kv.Value.ackedOn!=null ? "Yes" : "No";
                worksheet.Cells[row, 3] = kv.Value.receivedOn!=null ? "Yes" : "No";
                if (kv.Value.receivedOn != null && kv.Value.sentOn != null)
                {
                    worksheet.Cells[row, 4] = (kv.Value.receivedOn.Value - kv.Value.sentOn.Value).TotalSeconds;
                }
                row++;
            }

            // Save the Excel file
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try {
                    worksheet.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Report saved Successfully!", "Info");
                } catch(Exception ex)
                {
                    MessageBox.Show($"Failed to save: {ex.Message}");
                }
                excelApp.Quit();

            }
        }
    }
}
