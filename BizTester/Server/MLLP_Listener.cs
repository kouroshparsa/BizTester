using Biztalk.Libs;
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

        public MLLP_Listener(CustomLogger logger, string port_text)
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
            byte[] buffer = new byte[4096];
            StringBuilder messageData = new StringBuilder();
            while (isListening)
            {
                int bytesRead = 0;
                    do
                    {
                        try {
                            bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                        }
                        catch (Exception)// timeout
                        {
                            if(bytesRead > 0)
                        {
                            string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            messageData.Append(chunk);
                            break;// due to timeout, there is no more data so end listening in this thread
                        }
                        
                        }
                        if (bytesRead > 0)
                        {
                            string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            messageData.Append(chunk);
                        }
                    } while (bytesRead > 0 && isListening);

                if (messageData.Length > 0)
                {
                    string msg = messageData.ToString();
                    messageData.Clear();
                    logger.Info("MLLP Received message", msg);
                    if (Acknowledgement.RequiresAcknowledgement(msg))
                    {
                        logger.Info("Message expects an acknowledgement.");
                        SendAck(msg, clientStream);
                    }
                }
                
            }

            tcpClient.Close();
        }

        private void SendAck(string msg, NetworkStream clientStream)
        {
            string ackMessage;
            try
            {
                ackMessage = Acknowledgement.GetAcknowledgementMessage(msg);
            }
            catch(Exception ex)
            {
                logger.Error("Failed to create achnowledgement for the message.", msg);
                return;
            }
            
            var buffer = Encoding.UTF8.GetBytes(ackMessage);
            clientStream.Write(buffer, 0, buffer.Length);
            logger.Info("Ack message was sent back to the client.", ackMessage);

        }

    }
}
