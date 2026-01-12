using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace BizTester.Models
{
    public class ReportMsg{
        public HL7.Dotnetcore.Message msg { get; set; }
        public DateTime? sentOn { get; set; } = null;
        public DateTime? ackedOn { get; set; } = null;
        public DateTime? receivedOn { get; set; } = null;
    }
    public class Report
    {
        public string error { get; set; }
        internal Dictionary<string, ReportMsg> messages{ get; set; } // key: message control id, value: ?

        public Report(DataGridView dataGridViewMT)
        {
            const string format = "yyyy-MM-dd HH:mm:ss.fff";
            messages = new Dictionary<string, ReportMsg>();
            var errors = new StringBuilder();
            for (int i = 0; i < dataGridViewMT.Rows.Count; i++)
            {
                DataGridViewCell timestamp_cell = dataGridViewMT.Rows[i].Cells[0];
                DataGridViewCell type_cell = dataGridViewMT.Rows[i].Cells[1];
                DataGridViewCell description_cell = dataGridViewMT.Rows[i].Cells[2];
                DataGridViewCell data_cell = dataGridViewMT.Rows[i].Cells[3];
                
                if (type_cell.Value?.ToString() == "INFO")
                {
                    DateTime dt = DateTime.ParseExact(timestamp_cell.Value.ToString(), format, CultureInfo.InvariantCulture);
                    if (data_cell.Value != null && data_cell.Value.ToString().Trim().StartsWith("MSH"))
                    {
                        string hl7 = data_cell.Value.ToString().Replace("\r\n\u001c\r\n", "\u001c\r");
                        hl7 = hl7
                            .Trim('\u000b') // VT
                            .Trim('\u001c') // FS
                            .Trim('\r', '\n');
                        hl7 = hl7.Replace(@"\T\\R\", @"\R\");

                        var msg = new HL7.Dotnetcore.Message(hl7);
                        try
                        {
                            msg.ParseMessage();
                        }catch(Exception ex)
                        {
                            errors.Append($"Failed to parse {hl7}. {ex.Message}");
                            continue;
                        }
                        string msgControlId = msg.Segments("MSH")[0].Fields(10).Value.ToString();
                        ReportMsg m = new ReportMsg();
                        m.msg = msg;

                        string description = description_cell.Value.ToString();
                        if (description.StartsWith("Received MLLP message") ||
                            description.StartsWith("Received message from Q") ||
                            description.StartsWith("Detected data file"))
                        {
                            if (messages.ContainsKey(msgControlId))
                            {
                                messages[msgControlId].receivedOn = dt;
                            }else
                            {
                                m.receivedOn = dt;
                                messages.Add(msgControlId, m);
                            }
                        }else if ((description.StartsWith("Data was sent to server successfully") ||
                            description.StartsWith("Data was sent to Queue successfully")) && !messages.ContainsKey(msgControlId))
                        {
                            m.sentOn = dt;
                            messages.Add(msgControlId, m);
                        }else if(description.StartsWith("Received acknowledgement"))
                        {
                            string ackMsgId = msg.Segments("MSA")[0].Fields(2).Value.ToString();
                            if (messages.ContainsKey(ackMsgId))
                            {
                                messages[ackMsgId].ackedOn = dt;
                            }
                            else
                            {
                                m.ackedOn = dt;
                                messages.Add(ackMsgId, m);
                            }
                        }



                    }
                }
            }
            this.error = errors.ToString();
        }
    }
}
