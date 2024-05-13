namespace BizTester.Libs
{
    internal class CustomLogger
    {
        internal DataGridView dataGridView;
        public CustomLogger(DataGridView view)
        {
            this.dataGridView = view;
        }

        private void UpdateDataGridView(string data, string type)
        {
            if (dataGridView.InvokeRequired)
            {
                dataGridView.Invoke(new Action<string, string>(UpdateDataGridView), data, type);
            }
            else
            {
                string timestamp = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss.fff");
                dataGridView.Rows.Add(timestamp, type, data);
            }
        }

        public void Info(string data)
        {
            UpdateDataGridView(data, "INFO");
        }

        public void Error(string data)
        {
            UpdateDataGridView(data, "ERROR");
        }
    }
}
