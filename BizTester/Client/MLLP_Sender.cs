using BizTester.Libs;
using BizTester.Server;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BizTester.Simulation;

namespace BizTester.Client
{
    internal class MLLP_Sender : Sender
    {
        public int port { get; }
        public SimulationSpec simSpec;

        public MLLP_Sender(CustomLogger logger, string port_text)
        {
            this.logger = logger;
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
            var task = SendAsync(this.port, data);
        }
        public async Task SendAsync(int port, string data)
        {
            var tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(new IPEndPoint(IPAddress.Loopback, port));
            }
            catch (Exception ex)
            {
                logger.Error($"Failed to connect to the tcp port likely because the server is not running. {ex.Message}");
                return;
            }

            logger.Info("Connected to server.");

            //get the IO stream on this connection to write to
            var stream = tcpClient.GetStream();

            //use UTF-8 and either 8-bit encoding due to MLLP-related recommendations
            var byteBuffer = Encoding.UTF8.GetBytes(data);

            //send a message through this connection using the IO stream
            stream.Write(byteBuffer, 0, byteBuffer.Length);

            logger.Info("Data was sent to server successfully.");

            NetworkStreamReader reader = new NetworkStreamReader();
            const int TIMEOUT = 4;// seconds
            try
            {
                string result = await reader.ReadStringWithTimeout(stream, TIMEOUT * 1000); // Read with a timeout of 2 seconds
                logger.Info("Receive acknowledgement.");
            }
            catch (TimeoutException)
            {
                logger.Info($"Did not receive acknowledgement after {TIMEOUT} seconds.");
            }catch(Exception ex)
            {
                logger.Error($"Client failed to read Ack: {ex.Message}");
            }
        }
    }
}
