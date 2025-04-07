using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace BizTester
{
    public partial class SimulationSettingsHelpForm : Form
    {
        const string INFO = @"{now},Gets the current datetime,EVN.2
{random_last_name},Gets a random last name,EVN.5.2
{random_first_name},Gets a random first name,EVN.5.3
{random_num},Generates a random number,PID.1";
        public SimulationSettingsHelpForm()
        {
            InitializeComponent();
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            table.Columns.Add("Value", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Example", typeof(string));

            foreach(string r in INFO.Split('\n'))
            {
                string[] vals = r.Split(',');
                var row = table.NewRow();
                row["Value"] = vals[0];
                row["Description"] = vals[1];
                row["Example"] = vals[2].Trim();
                table.Rows.Add(row);
            }
            dataGridViewHelp.DataSource = table;
            dataGridViewHelp.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

        }
    }
}
