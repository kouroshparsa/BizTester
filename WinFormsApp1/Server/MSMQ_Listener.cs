using BizTester.Libs;
using MSMQ.Messaging;

namespace BizTester.Server
{
    internal class MSMQ_Listener : Listener
    {
        public string QueueName { get; }

        public MSMQ_Listener(CustomLogger logger, string queue)
        {
            this.logger = logger;
            if (!MessageQueue.Exists(queue))
            {
                throw new Exception($"Invalid queue {queue}");
            }
            this.QueueName = queue;
        }

        private void ListenForQueuedItems()
        {
            while (isListening)
            {
                var queue = new MessageQueue(QueueName);
                try
                {
                    var msg = queue.Receive(TimeSpan.FromSeconds(1));
                    if (msg != null)
                    {
                        msg.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
                        logger.Info($"Received message: {msg.Body.ToString()}");
                    }
                }
                catch (MessageQueueException mqEx)
                {
                    if (!mqEx.MessageQueueErrorCode.Equals(MessageQueueErrorCode.IOTimeout))
                        logger.Error($"MessageQueueException: {mqEx.Message}");
                }
                catch (Exception ex)
                {
                    logger.Error($"Exception: {ex.Message}");
                }
            }
        }
        public override void Start()
        {
            try
            {
                listenThread = new Thread(new ThreadStart(ListenForQueuedItems));
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting listener: {ex.Message}");
            }
        }
    }
}
