using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace BizTester.Simulation
{
    public class SimulationSpec
    {

        public string settingsPath = Path.GetFullPath("./simulation_data.csv");

        public List<Record> records = new List<Record>();

        public class Record
        {
            public string Field { get; set; }
            public string Value { get; set; }
            public string Description { get; set; }

            public Record(string field, string val, string description)
            {
                this.Field = field;
                this.Value = val;
                this.Description = description;
            }
            public Record(string[] parts)
            {
                this.Field = parts[0];
                this.Value = parts[1];

                if (parts.Length > 2)
                {
                    this.Description = parts[2];
                }
                else
                    this.Description = "";
            }
        }

        public void LoadSettingsFromFile()
        {
            records = new List<Record>();
            using (StreamReader sr = File.OpenText(settingsPath))
            {
                string s;
                bool isHeader = true;
                while ((s = sr.ReadLine()) != null)
                {
                    if (isHeader)
                        isHeader = false;
                    else
                    {
                        string[] parts = s.Split(',');
                        if (parts.Length >= 2 &&
                            parts[0].Trim().Length > 0 &&
                            parts[1].Trim().Length > 0)
                        {
                            records.Add(new Record(parts));
                        }
                    } 
                    
                }
            }
        }
    }
}
