using RandomNameGeneratorLibrary;
using System;
using System.IO;

namespace BizTester.Client
{
    internal class Simulator
    {
        private static int count = 0;
        private static HL7.Dotnetcore.Message msg = null;
        public static String GetHL7Message()
        {
            count += 1;
           
            if (msg == null)
            {
                string content = @"MSH|^~\\&|AcmeHIS|StJohn|CATH|StJohn|20061019172719||ORM^O01|MSGID12349876|P|2.3
PID|||20301||Durden^Tyler^^^Mr.||19700312|M|||88 Punchward Dr.^^Los Angeles^CA^11221^USA|||||||
PV1||O|OP^^||||4652^Paulson^Robert|||OP|||||||||9|||||||||||||||||||||||||20061019172717|20061019172718
ORC|NW|20061019172719
OBR|1|20061019172719||76770^Ultrasound: retroperitoneal^C4|||12349876";
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
