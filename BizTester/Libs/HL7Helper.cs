using System;
using System.IO;
using System.Text;

namespace BizTester.Libs
{
    class HL7Helper
    {
        public const string BEGIN_MSG = "\v";
        public const string END_MSG = "\u001c\r";

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

        public static string GetMessageFromFile(string path)
        {
            string content = File.ReadAllText(path, Encoding.GetEncoding("UTF-8"));
            return content;
        }
    }
}
