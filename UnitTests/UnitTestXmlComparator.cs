using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biztalk.Helpers;
using System.Xml;
using BizTester.Helpers;

namespace UnitTests
{
    [TestClass]
    public class UnitTestXmlComparator
    {

        [TestMethod]
        public void TestXmlClosing()
        {
            string input1 = @"<ns1:ADT_APP_25_GLO_DEF xmlns:ns1=""http://microsoft.com/HealthCare/HL7/2X"">
<MSH><MSH.13_SequenceNumber></MSH.13_SequenceNumber></MSH>
</ns1:ADT_APP_25_GLO_DEF>";
            string input2 = @"<ns1:ADT_APP_25_GLO_DEF xmlns:ns1=""http://microsoft.com/HealthCare/HL7/2X"">
<MSH><MSH.13_SequenceNumber/></MSH>
</ns1:ADT_APP_25_GLO_DEF>";
            var doc1 = new XmlDocument();
            var doc2 = new XmlDocument();
            doc1.LoadXml(input1);
            doc2.LoadXml(input2);
            var res = XmlComparator.CompareXmls(doc1, doc2);
            Assert.AreEqual(res.Count, 0);
        }

        [TestMethod]
        public void TestXmlDifferences()
        {
            string input1 = @"<ns1:ADT_APP_25_GLO_DEF xmlns:ns1=""http://microsoft.com/HealthCare/HL7/2X"">
	<OBX_ObservationResult>
		<OBX_5_ObservationValue>
			<CE_0_Identifier>
				<CE_1_Text>1NA</CE_1_Text>
			</CE_0_Identifier>
			<CE_0_Identifier>
				<CE_1_Text>MET</CE_1_Text>
			</CE_0_Identifier>
			<CE_0_Identifier>
				<CE_1_Text>INU</CE_1_Text>
			</CE_0_Identifier>
			<CE_0_Identifier>
				<CE_1_Text>OTH</CE_1_Text>
			</CE_0_Identifier>
		</OBX_5_ObservationValue>
	</OBX_ObservationResult>
</ns1:ADT_APP_25_GLO_DEF>";
            string input2 = @"<ns1:ADT_APP_25_GLO_DEF xmlns:ns1=""http://microsoft.com/HealthCare/HL7/2X"">
	<OBX_ObservationResult>
		<OBX_5_ObservationValue>
			<CE_0_Identifier>
				<CE_1_Text>YES</CE_1_Text>
			</CE_0_Identifier>
			<CE_0_Identifier>
				<CE_1_Text>BLANK</CE_1_Text>
			</CE_0_Identifier>
			<CE_0_Identifier>
				<CE_1_Text>INU</CE_1_Text>
			</CE_0_Identifier>
			<CE_0_Identifier>
				<CE_1_Text>OTH</CE_1_Text>
			</CE_0_Identifier>
		</OBX_5_ObservationValue>
	</OBX_ObservationResult>
</ns1:ADT_APP_25_GLO_DEF>";
            var doc1 = new XmlDocument();
            var doc2 = new XmlDocument();
            doc1.LoadXml(input1);
            doc2.LoadXml(input2);
            var res = XmlComparator.CompareXmls(doc1, doc2);
            Assert.AreEqual(res.Count, 2);
        }
    }
}
