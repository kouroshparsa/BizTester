using BizTester.Helpers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BizTester.Client
{
    internal class File_Sender : Sender
    {
        public string Folder { get; }

        public File_Sender(CustomLogger logger, string folder)
        {
            this.logger = logger;
            if (!Directory.Exists(folder))
            {
                throw new Exception($"Invalid folder {folder}");
            }
            this.Folder = folder;
        }

        public override void Send(string data, string fileName)
        {
            SendMessage(data, fileName);
        }
        private void SendMessage(string data, string fileName)
        {
            string res = HL7Helper.SanitizeHl7(data);
            if (!string.IsNullOrEmpty(res))
            {
                logger.Warn($"The HL7 message seems to be malformatted: {res}", data);
            }
            string path = Path.Combine(Folder, fileName);
            while (File.Exists(path))
            {
                    fileName = $"{Guid.NewGuid()}.hl7v2";
                path = Path.Combine(Folder, fileName);
            }

            try
            {
                File.WriteAllText(path, data);
                logger.Info($"Created file {fileName}", data);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
