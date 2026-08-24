using BizTester.Transformer;
using HL7.Tea.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BizTester.Helpers
{
    public class HL7Helper
    {
        public const string BEGIN_MSG = "\v";
        public const string END_MSG = "\u001c\r";
        public const int BEGIN_MSG_INT = 0x0B;
        public const int END_MSG_INT = 0x1C;
        private static int msg_count = 1;

        public static void ResetCounter()
        {
            msg_count = 1;
        }
        public static string CleanHL7(string msg)
        {
            return msg.Replace(BEGIN_MSG, "").Replace(END_MSG, "");
        }

        internal static bool MessageRequiresAcknolwdgement(string data)
        {
            string[] header = data.Trim().Split('\r')[0].Split('|');
            if (header.Length >= 14 && header[14].ToUpper().Equals("AL"))
                return true;
            return false;
        }

        public static string GetMessageFromFile(string path, TransformationSpec ts = null)
        {
            return File.ReadAllText(path, Encoding.GetEncoding("UTF-8"));
        }
        public static string Transform(string content, TransformationSpec ts)
        {
            Dictionary<string, string> specs = ts.records.ToDictionary(r => r.Field, r => r.Value.Replace("{count}", msg_count.ToString()));
            var msg = new HL7Message(content);
            msg.Transform(specs);
            msg_count++;
            return msg.Content;
        }

        public static string GetHl7Value(
            string hl7Message,
            string path)
        {
            // Example path: "PID-3.1.4"
            var pathParts = path.Split('-');
            string segmentName = pathParts[0];

            var indexParts = pathParts[1].Split('.');
            int fieldIndex = int.Parse(indexParts[0]);
            int componentIndex = indexParts.Length > 1 ? int.Parse(indexParts[1]) : 0;
            int subComponentIndex = indexParts.Length > 2 ? int.Parse(indexParts[2]) : 0;

            var lines = hl7Message.Replace("\n", "").Split('\r');
            var segment = lines.FirstOrDefault(l => l.StartsWith(segmentName + "|"));

            if (segment == null)
                return null;

            // HL7 delimiters
            char fieldSep = '|';
            char componentSep = '^';
            char subComponentSep = '&';

            var fields = segment.Substring(segmentName.Length + 1).Split(fieldSep);

            // Special case: MSH field indexing
            int fieldPos = segmentName == "MSH" ? fieldIndex - 2 : fieldIndex-1;

            if (fields.Length <= fieldPos)
                return null;

            var field = fields[fieldPos];

            // Handle repetition (first only)
            field = field.Split('~').FirstOrDefault();

            if (componentIndex > 0)
            {
                var comps = field.Split(componentSep);
                if (comps.Length < componentIndex)
                    return null;

                var comp = comps[componentIndex - 1];

                if (subComponentIndex > 0)
                {
                    var subs = comp.Split(subComponentSep);
                    if (subs.Length < subComponentIndex)
                        return null;

                    return subs[subComponentIndex - 1];
                }

                return comp;
            }

            return field;
        }

        public static string[] GetFields(string data, List<string> columns)
        {
            string[] result = new string[columns.Count];
            int ind = 0;
            foreach(string col in columns)
            {
                try
                {
                    result[ind] = GetHl7Value(data, col);
                }
                catch (Exception)
                {
                    result[ind] = "?";
                }
                ind++;
            }
            return result;
            
        }

        public static string SanitizeHl7(string hl7)
        {
            try
            {
                var message = new HL7Message(hl7);
            }catch(Exception ex)
            {
                return $"Error: {ex.Message}";
            }
            return null;
        }
    }
}
