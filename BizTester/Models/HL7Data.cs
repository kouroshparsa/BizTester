using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace BizTester.Models
{
    class HL7Data
    {
        public string fileName { get; set; }
        public string content { get; set; }

        public HL7Data(string _fileName, string _content)
        {
            this.fileName = _fileName;
            this.content = _content;
        }

        public static string GetMessageControlID(string path)
        {
            try
            {
                foreach (var line in File.ReadLines(path))
                {
                    string[] parts = line.Split('|');
                    if (parts[0].Trim().Equals("MSH"))
                        return parts[9];
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
        public static Dictionary<string, string> GetFolderData(string folderPath,
            IProgress<string> progress, string statusPrefix, CancellationToken token)
        {
            var data = new ConcurrentDictionary<string, string>();
            string[]files = Directory.GetFiles(folderPath);
            int count = 0;
            Parallel.ForEach(files,
                new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount, CancellationToken = token },
                file =>
                {
                    string id = GetMessageControlID(file);
                    if(id != null)
                    {
                        data.TryAdd(id, Path.GetFileName(file));
                        Interlocked.Increment(ref count);
                        if (count % 100 == 0)
                            progress.Report($"{statusPrefix}: %{Math.Round(100.0*count/files.Length)}");
                    }

                });
            
            return new Dictionary<string, string>(data);
        }
    }
}
