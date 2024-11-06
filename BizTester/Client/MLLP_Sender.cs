using BizTester.Libs;
using BizTester.Server;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BizTester.Simulation;
using System.IO;
using System.Threading;

namespace BizTester.Client
{
    internal class MLLP_Sender : Sender
    {
        public int port { get; }
        public string ip { get; }
        public SimulationSpec simSpec;

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

        public override void Start(string data)
        {
            Task task = SendAsync(this.port, data);
            task.Wait(4000);
        }
        public async Task SendAsync(int port, string data)
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

            
            //get the IO stream on this connection to write to
            var stream = tcpClient.GetStream();

            if (!data.StartsWith(HL7Helper.BEGIN_MSG))
                data = $"{HL7Helper.BEGIN_MSG}{data}";

            if (!data.EndsWith(HL7Helper.END_MSG))
                data = $"{data}{HL7Helper.END_MSG}";

            StreamHelper.WriteToStream(stream, data);          
            logger.Info("Data was sent to server successfully.", data);

            if (!HL7Helper.MessageRequiresAcknolwdgement(data))
                return;

            const int TIMEOUT = 4000;// milli-seconds
            try
            {
                Task<string> task = StreamHelper.AsyncReadStream(stream, TIMEOUT);
                await task;
                logger.Info("Receive acknowledgement.", task.Result);
            }
            catch (TimeoutException)
            {
                logger.Info($"Did not receive acknowledgement after {TIMEOUT} milliseconds.");
            }catch(Exception ex)
            {
                logger.Error($"Client failed to read Ack: {ex.Message}");
            }
        }
    }
}
