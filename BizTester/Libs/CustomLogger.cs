using System;
using System.Windows.Forms;

namespace BizTester.Libs
{
    public class CustomLogger
    {
        internal DataGridView dataGridView;
        private enum LogTypes
        {
            INFO,
            WARN,
            ERROR
        }
        public CustomLogger(DataGridView view)
        {
            this.dataGridView = view;
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
                    //Console.WriteLine(msg);
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                string timestamp = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.fff");
                dataGridView.Rows.Add(timestamp, type, msg, data);
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
