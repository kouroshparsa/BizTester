using HL7.Dotnetcore;
using System;

namespace BizTester.Libs
{

    public class Acknowledgement
    {
        public static string GetAcknowledgementMessage(string incomingHl7Message)
        {
            if (string.IsNullOrEmpty(incomingHl7Message))
                throw new ApplicationException("Invalid HL7 message for parsing operation. Please check your inputs");

            Message message = new Message(incomingHl7Message);
            message.ParseMessage();
            var messageControlId = message.GetValue("MSH.10");
            Console.WriteLine($"messageControlId={messageControlId}");
            Message ack = message.GetACK();
            return ack.SerializeMessage(false);
        }
    }
}
