using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTester.Models
{
    class HelperAssemblyInfo
    {
        public string Assembly { get; set; }
        public string Class { get; set; }
        public string Namespace { get; set; }
        public string AssemblyPath { get; set; }
        public HelperAssemblyInfo(string className, string ns, string dllFolder)
        {
            this.Class = className;
            this.Namespace = ns;
            this.Assembly = className.Substring(0, className.LastIndexOf("."));
            this.AssemblyPath = Path.Combine(dllFolder, this.Assembly + ".dll");
            if (!File.Exists(this.AssemblyPath))
                throw new Exception($"You are missing the assembly {this.Assembly}.dll in the folder: {dllFolder}");
        }


    }
}
