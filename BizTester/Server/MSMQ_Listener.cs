using BizTester.Libs;
using MSMQ.Messaging;
using System;
using System.Threading;

namespace BizTester.Server
{
    internal class MSMQ_Listener : Listener
    {
        public string QueueName { get; }

        public MSMQ_Listener(string queue, CustomLogger logger=null)
        {
            if (logger == null)
                logger = new CustomLogger();
            this.logger = logger;
            this.QueueName = queue;
        }
        
        private void ListenForQueuedItems()
        {
            bool showError = true;
            while (isListening)
            {
                var queue = new MessageQueue(QueueName);
                try
                {
                    var msg = queue.Receive(TimeSpan.FromSeconds(1));
                    showError = true;
                    if (msg != null)
                    {
                        string result = StreamHelper.ReadStream(msg.BodyStream);
                        if (this.messageQueue != null)
                        {
                            this.messageQueue.Enqueue(result);
                        }
                        logger.Info($"Received message from queue.", result);
                    }
                }
                catch (MessageQueueException mqEx)
                {
                    if (showError && !mqEx.MessageQueueErrorCode.Equals(MessageQueueErrorCode.IOTimeout))
                    {// timeout error is normal. It happens when there is no message
                        logger.Error($"MessageQueueException: {mqEx.Message}");
                        showError = false;
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    if (showError) {
                        logger.Error($"Error: {ex.Message}");
                        showError = false;
                        Thread.Sleep(1000);
                    }
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
