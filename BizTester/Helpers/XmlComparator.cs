using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace BizTester.Helpers
{
    class XmlComparator
    {
        public static void FilterOutIgnoreList(List<string>diffs, string ignoreListPath)
        {
            if (File.Exists(ignoreListPath))
            {
                HashSet<string> ignoreList = new HashSet<string>(File.ReadAllLines(ignoreListPath));
                for (int i=diffs.Count - 1; i>= 0; i--){
                    foreach(string val in ignoreList)
                    {
                        if (diffs[i].StartsWith(val))
                        {
                            diffs.RemoveAt(i);
                        }
                    }
                }
            }
        }
        private static List<XmlNode> GetChildNodes(XmlNode node)
        {
            var children = new List<XmlNode>();

            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Element)
                {
                    children.Add(child);
                }
            }

            return children;
        }
        
        private static void CompareNodes(XmlNode node1, XmlNode node2, string xpath, List<string> diffs)
        {
            if (node1 == null && node2 == null)
                return;

            if (node1 == null)
            {
                diffs.Add($"{xpath} missing in file1");
                return;
            }

            if (node2 == null)
            {
                diffs.Add($"{xpath} missing in file2");
                return;
            }

            // Compare attributes
            //CompareAttributes(node1, node2, xpath, diffs);

            // Compare text value (ignore whitespace)
            string value1 = node1.InnerText?.Trim();
            string value2 = node2.InnerText?.Trim();

            if (node1.ChildNodes.Count == 1 && node1.FirstChild is XmlText)
            {
                if (value1 != value2)
                {
                    diffs.Add($"{xpath} value differs: '{value1}' vs '{value2}'");
                }
            }

            // Group children by name + index
            var children1 = GetChildNodes(node1);
            var children2 = GetChildNodes(node2);

            int max = Math.Max(children1.Count, children2.Count);

            for (int i = 0; i < max; i++)
            {
                XmlNode c1 = i < children1.Count ? children1[i] : null;
                XmlNode c2 = i < children2.Count ? children2[i] : null;

                string childXPath = $"{xpath}/{(c1 ?? c2)?.Name}[{i + 1}]";
                CompareNodes(c1, c2, childXPath, diffs);
            }
        }

        private static void CompareAttributes(XmlNode node1, XmlNode node2, string xpath, List<string> diffs)
        {
            var attrs1 = node1.Attributes;
            var attrs2 = node2.Attributes;

            if (attrs1 != null)
            {
                foreach (XmlAttribute attr1 in attrs1)
                {
                    var attr2 = attrs2?[attr1.Name];
                    if (attr2 == null)
                    {
                        diffs.Add($"{xpath}/@{attr1.Name} missing in file2");
                    }
                    else if (attr1.Value != attr2.Value)
                    {
                        diffs.Add($"{xpath}/@{attr1.Name} differs: '{attr1.Value}' vs '{attr2.Value}'");
                    }
                }
            }

            if (attrs2 != null)
            {
                foreach (XmlAttribute attr2 in attrs2)
                {
                    if (attrs1?[attr2.Name] == null)
                    {
                        diffs.Add($"{xpath}/@{attr2.Name} missing in file1");
                    }
                }
            }
        }


        public static List<string> CompareXmlFiles(string file1, string file2)
        {
            var doc1 = new XmlDocument();
            var doc2 = new XmlDocument();

            doc1.Load(file1);
            doc2.Load(file2);

            var diffs = new List<string>();

            CompareNodes(doc1.DocumentElement, doc2.DocumentElement, "/" + doc1.DocumentElement.Name, diffs);
            return diffs;
        }

    }
}
