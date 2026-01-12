using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTester.Models
{
    class Diff
    {
        public string oldContent { get; set; }
        public string newContent { get; set; }
        public string msgID { get; set; }
        public string oldFileName { get; set; }
        public string newFileName { get; set; }

        public Diff(string _oldContent, string _newContent, string _msgID, string _oldFileName, string _newFileName)
        {
            this.oldContent = _oldContent;
            this.newContent = _newContent;
            this.msgID = _msgID;
            this.oldFileName = _oldFileName;
            this.newFileName = _newFileName;
        }
    }
}
