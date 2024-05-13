using BizTester.lib;
using MSMQ.Messaging;

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
        public override void Start()
        {
            using (var tx = new MessageQueueTransaction())
            {
                tx.Begin();
                using (MessageQueue queue = new MessageQueue(QueueName))
                {
                    queue.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
                    string msg = Simulator.GetHL7Message();
                    queue.Send(msg, tx);
                }
                tx.Commit();
                logger.Info("Message sent to Queue.");
            }
        }

    }
}
