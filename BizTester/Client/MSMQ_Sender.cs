using BizTester.Libs;
using MSMQ.Messaging;
using System;
using System.IO;
using System.Text;

namespace BizTester.Client
{
    internal class MSMQ_Sender : Sender
    {
        public string QueueName { get; }

        public MSMQ_Sender(CustomLogger logger, string queue)
        {
            this.logger = logger;
            if (!MessageQueue.Exists(queue))
            {
                throw new Exception($"Invalid queue {queue}");
            }
            this.QueueName = queue;
        }
        public override void Start(string data)
        {
            var messageToSend = new Message();
            StreamHelper.WriteToStream(messageToSend.BodyStream, data);
            using (MessageQueue queue = new MessageQueue(QueueName))
            {
                queue.Send(messageToSend, "", MessageQueueTransactionType.Single);
            }
            logger.Info("Message sent to Queue.", data);
            
        }

    }
}
