using BizTester.Simulation;
using System.IO;
using System.Text;

namespace BizTester.Libs
{
    class HL7Helper
    {
        public const string BEGIN_MSG = "\v";
        public const string END_MSG = "\u001c\r";
        public const int BEGIN_MSG_INT = 0x0B;
        public const int END_MSG_INT = 0x1C;
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

        public static string GetMessageFromFile(string path, SimulationSpec simSpec=null)
        {
            string content = File.ReadAllText(path, Encoding.GetEncoding("UTF-8"));
            if(simSpec != null && simSpec.records.Count > 0)
            {
                content = Simulator.GetHL7Message_WithSample(simSpec.records, content);
            }
            return content;
        }
    }
}
