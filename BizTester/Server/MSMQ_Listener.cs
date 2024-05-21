using BizTester.Libs;
using MSMQ.Messaging;
using System;
using System.IO;
using System.Text;
using System.Threading;

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
                        string result;
                        using (var streamReader = new StreamReader(msg.BodyStream, Encoding.Unicode))
                        {
                            result = streamReader.ReadToEnd();
                        }
                        
                        logger.Info($"Received message from queue.", result);
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
                logger.Info("Started to collect messages from the queue.");
                listenThread = new Thread(new ThreadStart(ListenForQueuedItems));
                listenThread.Start();
            }
            catch (Exception ex)
            {
                logger.Error($"Failed to start listener: {ex.Message}");
            }
        }
    }
}
