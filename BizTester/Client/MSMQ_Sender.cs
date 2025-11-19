using BizTester.Libs;
using MSMQ.Messaging;
using System;
using System.IO;
using System.Text;
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

        public override void Send(string data)
        {
            Task.Run(() =>
            {
                SendMessage(data);
            });
        }
        private void SendMessage(string data)
        {
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
