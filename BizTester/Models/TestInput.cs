using System;

namespace BizTester.Models
{
    public class TestInput
    {
        public TestInput() { }// to be able to use Newtonsoft to deserialize

        public TestInput(string protocol, int port, string queue, string path, string ip)
        {
            if (protocol == "MLLP")
            {
                if (port <= 0)
                    throw new Exception("Invalid port number.");
            }
            else if (protocol == "Queue")
                this.queue = queue;
            else// file
                this.path = path;
        }

        public TestInput(string protocol, int port, string data_file, string ip)
        {
            this.protocol = protocol;
            this.data_file = data_file;
            if (protocol == Protocol.MLLP)
            {
                if (port <= 0)
                    throw new Exception("Invalid port number.");
            }
            else if (protocol == Protocol.MSMQ)
                this.queue = queue;
            else// file
                this.path = path;
        }
        public TestInput(string protocol, string value, string data_file)
        {
            this.protocol = protocol;
            this.data_file = data_file;
            if (protocol == Protocol.MLLP)
            {
                port = int.Parse(value);
                if (port <= 0)
                    throw new Exception("Invalid port number.");
            }
            else if (protocol == Protocol.MSMQ)
                queue = value;
            else// file
                path = value;
        }
        public string protocol { get; set; }
        public int port { get; set; }

        public string ip { get; set; }
        public string queue { get; set; }
        public string path { get; set; }
        public string data_file { get; set; }
        internal object GetValue()
        {
            if (protocol == Protocol.MLLP)
                return port;
            else if (protocol == Protocol.MSMQ)
                return queue;
            else// file
                return path;
        }
    }
}
