using System;
using System.Collections.Generic;
using System.IO;
using HL7.Dotnetcore;

namespace BizTester.Models
{
    class HL7Data
    {
        public string fileName { get; set; }
        public string content { get; set; }

        public HL7Data(string _fileName, string _content)
        {
            this.fileName = _fileName;
            this.content = _content;
        }

        public static Dictionary<string, HL7Data> GetFolderData(string folderPath, HashSet<string> ignoreList, HashSet<string>errors)
        {
            var data = new Dictionary<string, HL7Data>();
            foreach (string filePath in Directory.GetFiles(folderPath, "*"))
            {
                try
                {
                    string fileName = Path.GetFileName(filePath);
                    string content = File.ReadAllText(filePath);
                    var msg = new Message(content);
                    msg.ParseMessage();
                    string msgControlId = msg.Segments("MSH")[0].Fields(10).Value.ToString();
                    foreach(string field in ignoreList)
                    {
                        try
                        {
                            string[] parts = field.Split('-');
                            string segment = parts[0];
                            string field_ind_str = parts[1];
                            int field_ind;
                            int component_ind = -1;
                            if (field_ind_str.Contains("."))
                            {
                                parts = field_ind_str.Split('.');
                                field_ind = int.Parse(parts[0]);
                                component_ind = int.Parse(parts[0]);
                            }else
                            {
                                field_ind = int.Parse(field_ind_str);
                            }

                            foreach(var seg in msg.Segments(segment))
                            {
                                if (component_ind >= 0)
                                {
                                    seg.Fields(field_ind).Components(component_ind).Value = "***";
                                }
                                else
                                {
                                    seg.Fields(field_ind).Value = "***";
                                }
                                
                            }
                           
                        }
                        catch (Exception)
                        {
                            errors.Add($"Failed to mask {field}");
                        }
                        content = msg.SerializeMessage(false);
                    }
                    data.Add(msgControlId, new HL7Data(fileName, content));
                }
                catch (Exception ex)
                {
                    errors.Add($"Invalid HL7 file: {filePath}: {ex.Message}");
                }
            }
            return data;
        }
    }
}
