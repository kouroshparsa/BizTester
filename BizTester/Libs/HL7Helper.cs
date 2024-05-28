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
    }
}
