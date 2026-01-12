using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BizTester.Helpers
{
    public class CustomLogger
    {
        internal DataGridView dataGridView;
        internal List<string> columns;
        private enum LogTypes
        {
            INFO,
            WARN,
            ERROR
        }
        public CustomLogger(DataGridView view, List<string> columns)
        {
            this.dataGridView = view;
            this.columns = columns;
        }

        public CustomLogger()
        {
        }

        
        private void UpdateDataGridView(string type, string msg, string data)
        {
            if (dataGridView.InvokeRequired)
            {
                try
                {
                    dataGridView.Invoke(new Action<string, string, string>(UpdateDataGridView), type, msg, data);
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                string timestamp = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.fff");
                List<string> parameters = new List<string>() { timestamp, type, msg, data };
                try
                {
                    if (data != null && data.Trim().StartsWith("MSH"))
                    {
                        string[] fields = HL7Helper.GetFields(data, columns);
                        parameters.AddRange(fields);
                    }
                }
                catch (Exception) { }

                int rowIndex = dataGridView.Rows.Add(parameters.ToArray());
                try
                {
                    ColorColumns(type, rowIndex, data);
                }
                catch (Exception) { }
            }
        }

        private void ColorColumns(string type, int rowIndex, string data)
        {
            
            if (type.Equals("ERROR"))
            {
                dataGridView.Rows[rowIndex]
                    .Cells["Type"]
                    .Style.BackColor = Color.Red;
            }
            else if (type.Equals("WARN"))
            {
                dataGridView.Rows[rowIndex]
                    .Cells["Type"]
                    .Style.BackColor = Color.Orange;
            }

            // color colorable columns:
            if (!string.IsNullOrEmpty(data))
            {
                foreach (string col in new string[] { "MSH-10", "MSA-2" })
                {
                    if (columns.Contains(col))
                    {
                        Color color = ColorFromMessageId.FromMessageId(HL7Helper.GetHl7Value(data, col));
                        dataGridView.Rows[rowIndex]
                            .Cells[col]
                            .Style.BackColor = color;
                    }
                }
            }
            
        }
        public void Info(string message, string data=null)
        {
            if (this.dataGridView == null)
                Console.WriteLine(message);
            else
                UpdateDataGridView(Enum.GetName(typeof(LogTypes), LogTypes.INFO), message, data);
        }

        public void Warn(string message, string data = null)
        {
            if (this.dataGridView == null)
                Console.WriteLine(message);
            else
                UpdateDataGridView(Enum.GetName(typeof(LogTypes), LogTypes.WARN), message, data);
        }

        public void Error(string message, string data=null)
        {
            if (this.dataGridView == null)
                Console.WriteLine(message);
            else
                UpdateDataGridView(Enum.GetName(typeof(LogTypes), LogTypes.ERROR), message, data);
        }

        public void Flush()
        {
            if(this.dataGridView != null)
                this.dataGridView.Refresh();
        }
    }
}
