using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BizTester.Helpers
{
    public class CustomLogger
    {
        internal DataGridView dataGridView;
        internal HashSet<string> columns;
        private enum LogTypes
        {
            INFO,
            WARN,
            ERROR
        }
        public CustomLogger(DataGridView view, HashSet<string> columns)
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

                dataGridView.Rows.Add(parameters.ToArray());
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
