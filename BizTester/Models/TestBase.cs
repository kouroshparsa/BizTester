using System.Collections.Generic;

namespace BizTester.Models
{
    public class TestBase
    {
        public List<TestInput> inputs { get; set; }
        public Dictionary<string, TestOutput> outputs { get; set; }// the keys are uids of TestOutput

        public const string InputDataType = "Input";
        public const string OutputDataType = "Output";

        public TestBase()
        {
            inputs = new List<TestInput>();
            outputs = new Dictionary<string, TestOutput>();
        }
    }
}
