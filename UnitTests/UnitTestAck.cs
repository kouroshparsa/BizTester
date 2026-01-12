using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biztalk.Helpers;

namespace UnitTests
{
    [TestClass]
    public class UnitTestAck
    {
        [TestMethod]
        public void TestGetAcknowledgementMessage()
        {
            string msg = "MSH|^~\\&|DigitalTwin_Kiosk|RCH|DT_self_registration|RCH|20251231073235||ADT^A05|43e105fd-8120-40e1-81c1-1b21d086cc42|D|2.4|||AL|NE\r\nEVN|A05|20251231073235|20251231073235\r\nPID|||U0027564^^^MTAA^PI||DFDKIOSKTEST^PICKLEBALL^^^^^L||20050421|M|||||(888)555-6666~(888)555-6666||||||9872092688\r\nPV1|1||RC.ER||||Z.ERGP^.ER Physician^Generic|||||||||||ER|||||||||||||||||||||RCH||PRE|||20251231073235||||||||\r\nPV2|1||stomach pain|||||||||||||||||||||||||||||||||||K1\rOBX|1|CE|REG.SOURCEOFID^Source of ID:^ADM||BCSWP^BC Services with photo||||||F\rIN1|1|MSP||Medical Services Plan|^^Victoria^BC|||||||20251231|||||||||||||||||20251231|||||||9872092688|||||||||Verified\rIN1|2|SP||Self Pay||||||||20251231\r";
            string ackMessage = Acknowledgement.GetAcknowledgementMessage(msg, "AA");
            string exp = "\vMSH|^~\\&|DT_self_registration|RCH|DigitalTwin_Kiosk|RCH|{timestamp}||ACK|43e105fd-8120-40e1-81c1-1b21d086cc42|D|2.4\r\nMSA|AA|43e105fd-8120-40e1-81c1-1b21d086cc42\u001c\r";
            exp = exp.Replace("{timestamp}", ackMessage.Split('|')[6]);
            Assert.AreEqual(exp, ackMessage);
        }
    }
}
