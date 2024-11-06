using System;
using System.Collections.Generic;
namespace BizTester.Models
{
    public class TestOutput
    {
        public TestOutput() { }// to be able to use Newtonsoft to deserialize

        public TestOutput(string protocol, int port, string queue, string path)
        {
            this.uid = Guid.NewGuid().ToString();
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

        public TestOutput(string protocol, int port, List<Validation> validations)
        {
            this.uid = Guid.NewGuid().ToString();
            this.protocol = protocol;
            this.validations = validations;
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
        public TestOutput(string protocol, string value, List<Validation> validations)
        {
            this.uid = Guid.NewGuid().ToString();
            this.protocol = protocol;
            this.validations = validations;
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
        public string queue { get; set; }
        public string path { get; set; }
        public string uid { get; set; }

        public List<Validation> validations { get; set; }

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
