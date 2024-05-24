using BizTester.Client;
using BizTester.Libs;
using HL7.Dotnetcore;
using System;
using System.Linq;
using System.Xml.Linq;

namespace Biztalk.Libs
{

    public class Acknowledgement
    {
        public static bool RequiresAcknowledgement(string msg, CustomLogger logger)
        {
            const string HL7V3_ACK = "<MSH.15_AcceptAcknowledgmentType>";
            if (msg.Contains(HL7V3_ACK))// HL7 v3
            {
                int ind = msg.IndexOf(HL7V3_ACK);
                return !msg.Substring(ind + HL7V3_ACK.Length, 1).Equals("<");

            }else // HL7 v2
            {
                try
                {
                    var message = new Message(msg);
                    message.ParseMessage();
                    var acceptAcknowledgeType = message.GetValue("MSH.15");
                    return acceptAcknowledgeType.Length > 0;
                }
                catch(Exception ex)
                {
                    logger.Error($"Failed to parse response message so will assume no acknowledgement is needed. {ex.Message}", msg);
                }
            }
            return false;
        }

        private static string Get_HL7v3_AcknowledgementMessage(string msg)
        {
            XDocument doc = XDocument.Parse(msg);
            XElement root = doc.Root;
            var elementsToRemove = root.Elements().Where(e => e.Name != "MSH").ToList();
            foreach(var element in elementsToRemove)
            {
                element.Remove();
            }

            XElement sendingFacility = root.Element("MSH")?.Element("MSH.4_SendingFacility")?.Element("HD.0_NamespaceId");
            XElement receivingFacility = root.Element("MSH")?.Element("MSH.6_ReceivingFacility")?.Element("HD.0_NamespaceId");
            string temp = sendingFacility.Value;
            sendingFacility.Value = receivingFacility.Value;
            receivingFacility.Value = temp;

            var datetime = root.Element("MSH")?.Element("MSH.7_DateTimeOfMessage");
            datetime.Value = DateTime.Now.ToString("yyyyMMddHHmmss.FFFF");

            XElement sendingApp = root.Element("MSH")?.Element("MSH.3_SendingApplication")?.Element("HD.0_NamespaceId");
            XElement receivingApp = root.Element("MSH")?.Element("MSH.5_ReceivingApplication")?.Element("HD.0_NamespaceId");
            temp = sendingApp.Value;
            sendingApp.Value = receivingApp.Value;
            receivingApp.Value = temp;

            // set message type MSH.9 to ACK:
            XElement messageType = root.Element("MSH")?.Element("MSH.9_MessageType");
            var subMsgType = new XElement("CM_MSG.0_MessageType");
            subMsgType.Value = "ACK";
            messageType.Add(subMsgType);

            // set sequence number MSH.13 to AA:
            XElement sequenceNum = root.Element("MSH")?.Element("MSH.13_SequenceNumber");
            sequenceNum.Value = "AA";

            // set continuation pointer MSH.14 to message control ID MSH.10:
            XElement continuation = root.Element("MSH")?.Element("MSH.14_ContinuationPointer");
            sequenceNum.Value = root.Element("MSH")?.Element("MSH.10_MessageControlId").Value;

            // set accept acknowledge to blank
            var ack = root.Element("MSH")?.Element("MSH.15_AcceptAcknowledgmentType");
            ack.Value = "";
            msg = doc.ToString(SaveOptions.DisableFormatting);
            return msg;
        }
        public static string GetAcknowledgementMessage(string incomingHl7Message)
        {
            if (string.IsNullOrEmpty(incomingHl7Message))
                throw new ApplicationException("Invalid HL7 message for parsing operation. Please check your inputs");

            if (incomingHl7Message.Contains("<MSH.3_SendingApplication>"))// HL7 V3
            {
                return Get_HL7v3_AcknowledgementMessage(incomingHl7Message);
            }
            var message = new Message(incomingHl7Message);
            message.ParseMessage();
            var messageControlId = message.GetValue("MSH.10");
            var ack = message.GetACK();
            string msg = ack.SerializeMessage(false);
            return msg;
        }
    }
}
