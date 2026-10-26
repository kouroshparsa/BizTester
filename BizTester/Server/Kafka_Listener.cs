using BizTester.Helpers;
using Confluent.Kafka;
using System;
using System.Threading;

namespace BizTester.Server
{
    internal class Kafka_Listener : Listener
    {
        private readonly string topicName;
        private readonly string bootstrapServers;
        private readonly string groupId;

        private IConsumer<Ignore, string> consumer;

        public Kafka_Listener(
            string topic,
            string ip,
            string port_text,
            CustomLogger logger = null)
        {
            int port;
            bool success = int.TryParse(port_text, out port);
            if (success)
            {
                if (port < 1)
                    throw new Exception("Invalid port");
            }
            else
            {
                throw new Exception("Invalid port");
            }

            this.logger = logger;
            this.topicName = topic;
            this.bootstrapServers = $"{ip}:{port}";

            // Give each BizTester listener its own consumer group.
            this.groupId = "BizTester-" + Guid.NewGuid().ToString("N");

            var config = new ConsumerConfig
            {
                BootstrapServers = this.bootstrapServers,
                GroupId = this.groupId,

                // Start from the beginning if this is a new consumer group.
                AutoOffsetReset = AutoOffsetReset.Earliest,

                // Automatically commit successfully consumed messages.
                EnableAutoCommit = true
            };

            this.consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        }

        private void ListenForTopicItems()
        {
            try
            {
                consumer.Subscribe(topicName);
                logger.Info($"Listening to Kafka topic '{topicName}' at {bootstrapServers}");

                while (isListening)
                {
                    try
                    {
                        ConsumeResult<Ignore, string> result =
                            consumer.Consume(TimeSpan.FromMilliseconds(500));

                        if (result == null)
                            continue;

                        string message = result.Message.Value;

                        logger.Info("Received message from Kafka topic. ", message);
                    }
                    catch (ConsumeException ex)
                    {
                        logger.Error($"Kafka consume error: {ex.Error.Reason}");
                    }
                    catch (Exception ex)
                    {
                        logger.Error($"Error processing Kafka message: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Kafka listener failed: {ex.Message}");
            }
            finally
            {
                try
                {
                    consumer.Close();
                }
                catch (Exception ex)
                {
                    logger.Error(
                        $"Error closing Kafka consumer: {ex.Message}");
                }
            }
        }

        public override void Start()
        {
            isListening = true;
            try
            {
                if (isListening)
                    return;

                isListening = true;

                logger.Info($"Started Kafka listener for topic '{topicName}'.");

                listenThread = new Thread(
                    new ThreadStart(ListenForTopicItems));

                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch (Exception ex)
            {
                logger.Error($"Failed to start Kafka listener: {ex.Message}");
            }
        }

        public override void Stop()
        {
            try
            {
                isListening = false;

                // Consume() has a 500ms timeout, so the thread
                // will exit quickly after isListening becomes false.

                if (listenThread != null &&
                    listenThread.IsAlive)
                {
                    listenThread.Join(2000);
                }

                if (consumer != null)
                {
                    consumer.Dispose();
                    consumer = null;
                }

                logger.Info($"Stopped Kafka listener for topic '{topicName}'.");
            }
            catch (Exception ex)
            {
                logger.Error($"Failed to stop Kafka listener: {ex.Message}");
            }
        }
    }
}