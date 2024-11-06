using Biztalk.Libs;
using BizTester.Libs;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BizTester.Server
{
    internal class MLLP_Listener : Listener
    {
        private TcpListener tcpListener;
        public Thread clientThread;

        public int port { get; }
        public bool sendAck { get; set; }

        public string ackCode { get; set; }
        public MLLP_Listener(int port, bool sendAck, string ackCode, CustomLogger logger = null)
        {
            if (logger == null)
                logger = new CustomLogger();
            this.logger = logger;
            if(port < 1)
                throw new Exception("Invalid port");
            this.port = port;
            this.sendAck = sendAck;
            this.ackCode = ackCode;
        }
        public MLLP_Listener(string port_text, bool sendAck, string ackCode, CustomLogger logger)
        {
            if (logger == null)
                logger = new CustomLogger();
            this.logger = logger;
            this.sendAck = sendAck;
            this.ackCode = ackCode;
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
            listenThread.Join(1000);
            tcpListener.Stop();
            base.Stop();
        }

        private void ListenForClients()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, this.port);
                tcpListener.Start();
                logger.Info("Server started. Waiting for connections...");

                while (isListening)
                {
                    if (tcpListener.Pending()) // Check if there are pending connection requests
                    {
                        TcpClient client = tcpListener.AcceptTcpClient();// blocks until someone connects to TCP port
                        logger.Info("Connected to a client");
                        this.clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
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
            listenThread.Priority = ThreadPriority.Highest;
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
                    string msg = HL7Helper.CleanHL7(messageData.ToString());
                    messageData.Clear();
                    logger.Info("Received MLLP message", msg);
                    if(this.messageQueue != null)
                    {
                        this.messageQueue.Enqueue(msg);
                    }
                    //if (Acknowledgement.RequiresAcknowledgement(msg, logger))
                    if(sendAck)
                    {
                        logger.Info("Message expects an acknowledgement.");
                        SendAck(msg, ref clientStream);
                    }

                    if (!msg.StartsWith("MSH"))
                    {
                        SendSoapResponse(ref clientStream);
                    }
                }
                
            }

            clientStream.Close();
            tcpClient.Close();
        }

        private void SendSoapResponse(ref NetworkStream clientStream)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\v3_HCIM_IN_FindCandidatesResponse.xml");
            string soapResponse = File.ReadAllText(filePath);

            byte[] responseBytes = Encoding.UTF8.GetBytes(soapResponse);
            clientStream.Write(responseBytes, 0, responseBytes.Length);
        }
        private void SendAck(string msg, ref NetworkStream clientStream)
        {
            string ackMessage;
            try
            {
                ackMessage = Acknowledgement.GetAcknowledgementMessage(msg, this.ackCode);
            }
            catch(Exception ex)
            {
                logger.Error($"Failed to create achnowledgement for the message. {ex.Message}", msg);
                return;
            }

            StreamHelper.WriteToStream(clientStream, ackMessage);
            logger.Info("Ack message was sent back to the client.", ackMessage.Trim());

        }

    }
}
