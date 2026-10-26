using BizTester.Helpers;
using Confluent.Kafka;
using HL7.Tea.Core;
using System;

namespace BizTester.Client
{
    internal class Kafka_Sender : Sender
    {
        private readonly string topicName;
        private readonly string ip;
        private readonly int port;

        private readonly IProducer<Null, string> producer;
        private readonly ProducerConfig config;

        public Kafka_Sender(CustomLogger logger,
            string topic,
            string port_text,
            string ip)
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

            this.port = port;
            this.logger = logger;
            this.topicName = topic;
            this.ip = ip;

            this.config = new ProducerConfig
            {
                BootstrapServers = $"{ip}:{port}",
                Acks = Acks.All
            };

            this.producer = new ProducerBuilder<Null, string>(config).Build();
        }


        public override void Send(string data, string fileName)
        {
            SendMessage(data);
        }

        private void SendMessage(string hl7Message)
        {
            // Remove MLLP-specific start/end characters
            hl7Message = hl7Message
                .Replace(HL7Helper.BEGIN_MSG, "")
                .Replace(HL7Helper.END_MSG, "");

            string res = HL7Helper.SanitizeHl7(hl7Message);

            if (!string.IsNullOrEmpty(res))
            {
                logger.Warn($"The HL7 message seems to be malformatted: {res}", hl7Message);
            }

            try
            {
                producer.Produce(
                    topicName,
                    new Message<Null, string>
                    {
                        Value = hl7Message
                    },
                    deliveryReport =>
                    {
                        if (deliveryReport.Error.IsError)
                        {
                            logger.Error($"Failed to send to the topic. {deliveryReport.Error.Reason}", hl7Message);
                        }
                        else
                        {
                            producer.Flush(TimeSpan.FromSeconds(1));
                            logger.Info("Data was sent to topic successfully.", hl7Message);
                        }
                    });
            }
            catch (Exception ex)
            {
                logger.Error($"Failed to send to the topic. {ex.Message}");
            }
        }

        public override void Close()
        {
            try
            {
                producer.Flush(TimeSpan.FromSeconds(1));
            }
            finally
            {
                producer.Dispose();
            }
        }
    }
}