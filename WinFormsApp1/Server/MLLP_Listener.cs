using Biztalk.Libs;
using BizTester.Libs;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BizTester.Server
{
    internal class MLLP_Listener : Listener
    {
        private TcpListener tcpListener;

        public int port { get; }
        public bool sendAck { get; }
        private Thread listenThread;

        public MLLP_Listener(CustomLogger logger, string port_text, bool sendAck)
        {
            this.logger = logger;
            int p;
            bool success = int.TryParse(port_text, out p);
            if (success)
                this.port = p;
            else
                throw new Exception("Invalid port");

            if (p < 1)
                throw new Exception("Invalid port");
            this.sendAck = sendAck;
        }

        public override void Stop()
        {
            isListening = false;
            listenThread.Join();
            tcpListener.Stop();
            base.Stop();
        }

        private void ListenForClients()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, this.port);
                tcpListener.Start();
                tcpListener.Start();
                logger.Info("Server started. Waiting for connections...");

                while (isListening)
                {
                    if (tcpListener.Pending()) // Check if there are pending connection requests
                    {
                        TcpClient client = tcpListener.AcceptTcpClient();
                        logger.Info("Connected to a client");
                        Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                        clientThread.Start(client);
                    }
                    else
                    {
                        Thread.Sleep(100); // Wait for a short while to avoid busy waiting
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        public override void Start()
        {
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            clientStream.ReadTimeout = 500;// you must set the timeout otherwise the Read operation keeps the thread running forever.
            byte[] message = new byte[4096];
            int bytesRead;

            while (isListening)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                // Handle received message here

                string msg = Encoding.ASCII.GetString(message, 0, bytesRead);
                logger.Info($"MLLP Received: {msg}");
                if (this.sendAck)
                    SendAck(msg, clientStream);
            }

            tcpClient.Close();
        }

        private void SendAck(string msg, NetworkStream clientStream)
        {
            string ackMessage = Acknowledgement.GetAcknowledgementMessage(msg);
            var buffer = Encoding.UTF8.GetBytes(ackMessage);
            clientStream.Write(buffer, 0, buffer.Length);
            logger.Info("Ack message was sent back to the client...");

        }

    }
}
