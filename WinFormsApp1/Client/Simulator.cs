using RandomNameGeneratorLibrary;

namespace BizTester.Client
{
    internal class Simulator
    {
        const string sampleDataPath = "../../../../sample_data.hl7v2";
        private static int count = 0;
        private static HL7.Dotnetcore.Message? msg = null;
        public static String GetHL7Message()
        {
            count += 1;
            if (msg == null)
            {
                string content = File.ReadAllText(sampleDataPath);
                msg = new HL7.Dotnetcore.Message(content);
                msg.ParseMessage();
            }

            string messageControlID = $"MSGID{count}";
            msg.AddSegmentMSH("SendingApp", "Hospital1", "ReceivingApp", "Hospital2", "", "ORM^O01", messageControlID, "P", "2.3");
            msg.SetValue("PID.5.5", ""); // no prefix
            var gen = new PersonNameGenerator();
            msg.SetValue("PID.5.1", gen.GenerateRandomLastName()); // family name
            msg.SetValue("PID.5.2", gen.GenerateRandomFirstName()); // given name

            return msg.SerializeMessage(false);
        }


    }

}
