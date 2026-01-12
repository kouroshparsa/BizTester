using Biztalk.Helpers;
using BizTester.Helpers;
using BizTester.Helpers;
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
        const int IDLE_DELAY = 1000;

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
            // TODO: put this timeout in settings
            clientStream.ReadTimeout = 8000;// you must set the timeout otherwise the Read operation keeps the thread running forever.
            byte[] buffer = new byte[4096];
            MemoryStream messageBuffer = new MemoryStream();
            bool insideMessage = false;
            while (isListening)
            {
                int bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(buffer, 0, buffer.Length);
                }
                catch (IOException) // Handle timeout
                {
                    continue; // Just loop again if there's no data
                }

                if (bytesRead > 0)
                {
                    for (int i = 0; i < bytesRead; i++)
                    {
                        byte b = buffer[i];

                        if (b == HL7Helper.BEGIN_MSG_INT) // Start of message (VT)
                        {
                            messageBuffer.SetLength(0); // Clear buffer
                            insideMessage = true;
                            continue;
                        }

                        if (b == HL7Helper.END_MSG_INT) // End of message (FS)
                        {
                            insideMessage = false;
                            continue;
                        }

                        if (b == 0x0D && !insideMessage) // Ignore trailing CR after FS
                        {
                            string msg = Encoding.UTF8.GetString(messageBuffer.ToArray());
                            messageBuffer.SetLength(0); // Clear buffer after processing

                            msg = HL7Helper.CleanHL7(msg);
                            logger.Info($"Received MLLP message on port {port}", msg.Trim());

                            if (this.messageQueue != null)
                            {
                                this.messageQueue.Enqueue(msg);
                            }

                            if (sendAck)
                            {
                                logger.Info("Message expects an acknowledgement.");
                                SendAck(msg, ref clientStream);
                                Thread.Sleep(2000); // Allow client to read ACK
                            }

                            if (!msg.Trim().StartsWith("MSH"))
                            {
                                try
                                {
                                    SendSoapResponse(ref clientStream);
                                }catch(Exception ex)
                                {
                                    string stackTrace = ex.StackTrace;
                                    logger.Error($"The message does not seem to be a HL7v2 message. SendSoapResponse failed. {ex}. {stackTrace}", msg);
                                }
                            }
                        }
                        else if (insideMessage) // Add valid message content
                        {
                            messageBuffer.WriteByte(b);
                        }
                    }
                }else
                {
                    Thread.Sleep(IDLE_DELAY); // if you do not specify IDLE_DELAY, sometimes when it no longer receive messages it loops into the false part fast causing over-consumption of CPU
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
                logger.Error($"Failed to create acknowledgement for the message. {ex.Message}", msg);
                return;
            }

            try
            {
                StreamHelper.WriteToStream(clientStream, ackMessage);
                logger.Info("Server sent Ack.", ackMessage.Trim());
            }catch(Exception ex)
            {
                logger.Error("Failed to send ack message." + ex.Message, msg);
            }
        }

    }
}
