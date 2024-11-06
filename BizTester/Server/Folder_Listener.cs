using BizTester.Libs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace BizTester.Server
{
    internal class Folder_Listener : Listener
    {
        public string path { get; }
        private static HashSet<string> failedFileNames = new HashSet<string>();
        public Folder_Listener(string path, CustomLogger logger=null)
        {
            if (logger == null)
                logger = new CustomLogger();
            this.logger = logger;
            if (!Directory.Exists(path))
                throw new Exception($"Invalid folder {path}");
            this.path = path;
        }

        private string ReadHL7File(string path)
        {
            string content = File.ReadAllText(path);
            var msg = new HL7.Dotnetcore.Message(content);
            msg.ParseMessage();
            return msg.SerializeMessage(true);
        }
        private void ListenForFiles()
        {
            while (isListening)
            {
                string[] files = Directory.GetFiles(this.path);
                foreach (string file in files)
                {
                    var filename = Path.GetFileName(file);
                    try
                    {
                        if (!failedFileNames.Contains(filename))
                        {
                            string content = ReadHL7File(file);
                            logger.Info($"Detected {filename} data.", content);
                            File.Delete(file);
                            logger.Info($"Deleted file {filename}");
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error($"{filename} {ex.Message}");
                        failedFileNames.Add(filename);
                    }

                }
                Thread.Sleep(1000);
            }
        }
        public override void Start()
        {
            try
            {
                listenThread = new Thread(new ThreadStart(ListenForFiles));
                listenThread.Start();
                logger.Info("Started to collect messages from the folder.");
            }
            catch (Exception ex)
            {
                logger.Error($"Failed to start listener: {ex.Message}");
            }
        }
    }
}

