using System.Windows.Forms;
using System.Xml.Linq;

namespace BizTester
{
    public partial class FormXmlViewer : Form
    {

        public FormXmlViewer(string xml)
        {
            InitializeComponent();

            string prettyXml = XDocument.Parse(xml).ToString();
            this.richTextBox1.Text = prettyXml;
        }
    }
}
