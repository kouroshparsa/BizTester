﻿using BizTester.Libs;
using System;
using System.IO;

namespace BizTester.Client
{
    internal class File_Sender : Sender
    {
        public string folder { get; }

        public File_Sender(CustomLogger logger, string folder)
        {
            this.logger = logger;
            if (!Directory.Exists(folder))
            {
                throw new Exception($"Invalid folder {folder}");
            }
            this.folder = folder;
        }

        public override void Start(string data)
        {
            string filename = $"{Guid.NewGuid()}.hl7v2";
            string path = Path.Combine(folder, filename);
            while (File.Exists(path))
            {
                filename = $"{Guid.NewGuid()}.hl7v2";
                path = Path.Combine(folder, filename);
            }

            try
            {
                File.WriteAllText(path, data);
                logger.Info($"Created file {filename}", data);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
