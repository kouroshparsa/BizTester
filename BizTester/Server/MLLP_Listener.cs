using BizTester.Libs;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BizTester.Server
{
    internal class MLLP_Listener : Listener
    {
        private TcpListener tcpListener;

        public int port { get; }
        public bool sendAck { get; }

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

        private void ListenForClients()
        {
            try
            {
                tcpListener.Start();
                logger.Info("Server started. Waiting for connections...");

                while (isListening)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    logger.Info("Connected to a client");
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        public override void Stop()
        {
            tcpListener.Stop();
            base.Stop();
        }


        public override void Start()
        {
            tcpListener = new TcpListener(IPAddress.Any, this.port);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
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
