﻿using System;
using System.Windows.Forms;

namespace BizTester.Libs
{
    internal class CustomLogger
    {
        internal DataGridView dataGridView;
        private enum LogTypes
        {
            INFO,
            ERROR
        }
        public CustomLogger(DataGridView view)
        {
            this.dataGridView = view;
        }

        private void UpdateDataGridView(string type, string msg, string data)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action<string, string, string>(UpdateDataGridView), type, msg, data);
            }
            else
            {
                string timestamp = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.fff");
                dataGridView.Rows.Add(timestamp, type, msg, data);
            }
        }

        public void Info(string message, string data=null)
        {
            UpdateDataGridView(Enum.GetName(typeof(LogTypes), LogTypes.INFO), message, data);
        }

        public void Error(string message, string data=null)
        {
            UpdateDataGridView(Enum.GetName(typeof(LogTypes), LogTypes.ERROR), message, data);
        }
    }
}
