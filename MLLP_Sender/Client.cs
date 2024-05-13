using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MLLP_Sender
{
    internal class Client
    {
        private static char END_OF_BLOCK = '\u001c';
        private static char START_OF_BLOCK = '\u000b';
        private static char CARRIAGE_RETURN = (char)13;

        private string GetData(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception($"Invalid path: {path}");
            }
            return File.ReadAllText(path);
        }

        public async Task SendAsync(int port, string dataPath)
        {
            var messageToTransmit = GetData(dataPath);
            //string ackMessage = Acknowledgement.GetAcknowledgementMessage(messageToTransmit);
            var tcpClient = new TcpClient();

            tcpClient.Connect(new IPEndPoint(IPAddress.Loopback, port));

            Console.WriteLine("Connected to server....");

            //get the IO stream on this connection to write to
            var stream = tcpClient.GetStream();

            //use UTF-8 and either 8-bit encoding due to MLLP-related recommendations
            var byteBuffer = Encoding.UTF8.GetBytes(messageToTransmit);

            //send a message through this connection using the IO stream
            stream.Write(byteBuffer, 0, byteBuffer.Length);

            Console.WriteLine("Data was sent to server successfully....");

            NetworkStreamReader reader = new NetworkStreamReader();

            try
            {
                string result = await reader.ReadStringWithTimeout(stream, 2000); // Read with a timeout of 2 seconds
                Console.WriteLine("Receive acknowledgement.");
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine("Did not receive acknowledgement.");
            }
        }
    }
}
