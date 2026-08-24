using BizTester.Helpers;
using MSMQ.Messaging;
using System;
using System.Threading.Tasks;

namespace BizTester.Client
{
    internal class MSMQ_Sender : Sender
    {
        public string QueueName { get; }

        public MSMQ_Sender(CustomLogger logger, string queue)
        {
            this.logger = logger;
            this.QueueName = queue;
        }

        public override void Send(string data, string fileName)
        {
            SendMessage(data);
        }
        private void SendMessage(string data)
        {
            data = data.Replace(HL7Helper.BEGIN_MSG, "").Replace(HL7Helper.END_MSG, "");// When sending HL7 to a queue, Biztalk does not like the begining and ending characters of HL7 so trim them off.
            string res = HL7Helper.SanitizeHl7(data);
            if (!string.IsNullOrEmpty(res))
            {
                logger.Warn($"The HL7 message seems to be malformatted: {res}", data);
            }
            var messageToSend = new Message();
            try
            {
                StreamHelper.WriteToStream(messageToSend.BodyStream, data);
                using (MessageQueue queue = new MessageQueue(QueueName))
                {
                    queue.Send(messageToSend, "", MessageQueueTransactionType.Single);
                }
                logger.Info("Data was sent to Queue successfully.", data);
            }catch(Exception ex)
            {
                logger.Error($"Failed to send to the queue. {ex}");
            }
        }

    }
}
