using HL7.Dotnetcore;
using Newtonsoft.Json.Linq;
using System.Xml;

namespace BizTester.Models
{
    public class Validation
    {
        public const string XML = "XML";
        public const string JSON = "JSON";
        public const string HL7V2 = "HL7V2";

        public string data_type { get; set; }
        public string path { get; set; }
        public string expectedResult { get; set; }

        public Validation(string dataType, string path, string expectedResult)
        {
            this.data_type = dataType;
            this.path = path;
            this.expectedResult = expectedResult;
        }

        public class TestResult
        {
            public bool passed { get; set; }
            public string actualResult { get; set; }

            public TestResult(string actualResult, string expectedResult)
            {
                this.actualResult = actualResult;
                this.passed = actualResult == expectedResult;
            }
        }
        public TestResult Validate(string data)
        {
            if(data_type == XML)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);
                XmlNode node = doc.DocumentElement.SelectSingleNode(path);
                return new TestResult(node.InnerText, expectedResult);
            }
            else if(data_type == JSON)
            {
                JObject o = JObject.Parse(data);
                string _path = path;
                if (!path.StartsWith("$."))
                    _path = $"$.{path}";
                JToken t = o.SelectToken(_path);
                return new TestResult(t.ToString(), expectedResult);
            }
            else if(data_type == HL7V2)
            {
                var message = new Message(data);
                message.ParseMessage();
                return new TestResult(message.GetValue(path), expectedResult);
            }
            throw new System.Exception($"Invalid validation data_type {data_type}");
        }
    }
}
