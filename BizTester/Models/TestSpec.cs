using System.Collections.Generic;
using System.Windows.Forms;

namespace BizTester.Models
{
    public class TestSpec
    {
        public Dictionary<string, TestBase> tests { get; set; }
        
        public TestSpec()
        {
            this.tests = new Dictionary<string, TestBase>();
        }
        
    }
}
