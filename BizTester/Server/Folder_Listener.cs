using BizTester.Helpers;
using HL7.Tea.Core;
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
            this.label = "the folder";
            if (logger == null)
                logger = new CustomLogger();
            this.logger = logger;
            if (!Directory.Exists(path))
                throw new Exception($"Invalid folder {path}");
            this.path = path;
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
                            string content = File.ReadAllText(file);
                            logger.Info($"Detected data file: {filename}", content);
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

