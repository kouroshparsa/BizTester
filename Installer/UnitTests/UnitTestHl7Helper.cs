using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BizTester.Helpers;

namespace UnitTests
{
    [TestClass]
    public class UnitTestHL7Helper
    {
        private string msg = @"MSH|^~\&|DT_Kiosk_Sandar|RCH|DT_self_registration||202602261050||ADT^A05|202603191050-1|D|2.4|||AL|NE
EVN|A05|202603191050|202603191050|||||Y
PID|||E1-.U0027641^^^MTAA^PI||DFDKIOSKTEST^BOXING^^^^^L||19950715|U|||||(569)123-4587^^CELL~(555)111-7777^^HOME||||||9872092774
PV1|1||RC.ER||||Z.ERGP^.ER Physician^Generic|||||||||||ER|||||||||||||||||||||RCH||PRE|||202603191050||||||||
PV2|1||Sex ZFH|||||||||||||||||||||||||||||||||||K1
OBX|1|CE|REG.SOURCEOFID^Source of ID:||BCSWP||||||F
IN1|1|MSP||Medical Services Plan|^^Victoria^BC|||||||20260226|||||||||||||||||20260226|||||||9872092774|||||||||Verified
IN1|2|SP||Self Pay||||||||20260226
ZFH|||^U";

        [TestMethod]
        public void TestGetHl7Value_NonExistant()
        {
            
            var res = HL7Helper.GetHl7Value(msg, "ABC-1");
            Assert.AreEqual(null, res);
        }

        [TestMethod]
        public void TestGetHl7Value_Field()
        {

            var res = HL7Helper.GetHl7Value(msg, "PV1-1");
            Assert.AreEqual("1", res);
        }

        [TestMethod]
        public void TestGetHl7Value_SubField()
        {

            var res = HL7Helper.GetHl7Value(msg, "ZFH-3.2");
            Assert.AreEqual("U", res);
        }

        [TestMethod]
        public void TestGetHl7Value_GetFields()
        {

            var res = HL7Helper.GetFields(msg, new List<string> { "IN1-2", "IN1-5.3" });
            CollectionAssert.AreEqual(new List<string> { "MSP", "Victoria" }, res);

        }
    }
}
