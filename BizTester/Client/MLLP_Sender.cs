using BizTester.Libs;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace BizTester.Client
{
    internal class MLLP_Sender : Sender
    {
        public int port { get; }
        public string ip { get; }

        public MLLP_Sender(CustomLogger logger, int port, string ip)
        {
            this.logger = logger;
            this.port = port;
            this.ip = ip;
        }
        public MLLP_Sender(CustomLogger logger, string port_text, string ip)
        {
            this.logger = logger;
            this.ip = ip;
            int p;
            bool success = int.TryParse(port_text, out p);
            if (success)
            {
                if (p < 1)
                    throw new Exception("Invalid port");
                this.port = p;
            }
            else
            {
                throw new Exception("Invalid port");
            }

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

            var tcpClient = new TcpClient();
            try
            {
                IPAddress ipAddress = IPAddress.Loopback;
                if (this.ip.Contains("."))
                {
                   ipAddress = IPAddress.Parse(this.ip);
                }
                tcpClient.Connect(new IPEndPoint(ipAddress, port));
            }
            catch (Exception ex)
            {
                logger.Error($"Failed to connect to the tcp port likely because the server is not running. {ex.Message}");
                return;
            }

            logger.Info("Connected to server.");


            // Get the IO stream on this connection to write to
            using (var stream = tcpClient.GetStream())
            {
                // TODO: put this timeout in settings
                stream.ReadTimeout = 4000;// you must set the timeout otherwise the Read operation keeps the thread running forever.

                if (!data.StartsWith(HL7Helper.BEGIN_MSG))
                    data = $"{HL7Helper.BEGIN_MSG}{data}";

                if (!data.EndsWith(HL7Helper.END_MSG))
                    data = $"{data}{HL7Helper.END_MSG}";

                StreamHelper.WriteToStream(stream, data);
                logger.Info("Data was sent to server successfully.", data.Trim());

                if (!HL7Helper.MessageRequiresAcknolwdgement(data))
                {
                    logger.Info("The HL7 message does not require an ACK.");
                    return;
                }
                   
                try
                {
                    string res = StreamHelper.ReadStream(stream);
                    logger.Info("Received acknowledgement.", res);
                }
                catch (TimeoutException)
                {
                    logger.Info($"Did not receive acknowledgement.");
                }
                catch (Exception ex)
                {
                    logger.Error($"Client failed to read Ack: {ex.Message}");
                }
            }

        }
    }
}
