using BizTester.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BizTester.Libs
{
    class TreeNodeHelper
    {
        private static void GetNodes(TreeView tv, out TreeNode inOutNode, out TreeNode protocolNode, out TreeNode testNode)
        {
            int level = tv.SelectedNode.Level;
            if (level == 1)
            {
                testNode = tv.SelectedNode.Parent;
                inOutNode = tv.SelectedNode;
                protocolNode = null;
            }
            else if (level == 2)
            {
                testNode = tv.SelectedNode.Parent.Parent;
                inOutNode = tv.SelectedNode.Parent;
                protocolNode = tv.SelectedNode;
            }
            else if (level == 3)
            {
                testNode = tv.SelectedNode.Parent.Parent.Parent;
                inOutNode = tv.SelectedNode.Parent.Parent;
                protocolNode = tv.SelectedNode.Parent;
            }else // level==0
            {
                testNode = tv.SelectedNode;
                inOutNode = null;
                protocolNode = null;
            }

        }
        public static void Delete(TreeView treeView1, TestSpec testSpec)
        {
            if (treeView1.SelectedNode == null)
                return;
              
            int level = treeView1.SelectedNode.Level;
            if (level >= 2)// delete one input or output
            {
                TreeNode inOutNode, protocolNode, testNode;
                GetNodes(treeView1, out inOutNode, out protocolNode, out testNode);

                string type = inOutNode.Text.ToLower().Substring(0, inOutNode.Text.Length - 1);
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete the selected {type}?",
                    "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    treeView1.Nodes.Remove(protocolNode);
                }
            }
            else if (level == 1)
                MessageBox.Show("Either select an input/output to delete or select the whole test.");
            else if (level == 0)
            {
                string testName = treeView1.SelectedNode.Text;
                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete {testName}?",
                    "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    testSpec.tests.Remove(testName);
                    treeView1.Nodes.Remove(treeView1.SelectedNode);
                }
            }
        }

        public static void Add(TreeView treeView1, TestSpec testSpec)
        {
            if (treeView1.SelectedNode == null)
            {
                if(treeView1.Nodes.Count == 0)
                {
                    var form = new TestEditorForm(null, testSpec);
                    form.ShowDialog();
                    DrawTree(treeView1, testSpec.tests);
                }
                return;
            }

            int level = treeView1.SelectedNode.Level;
            TreeNode inOutNode, protocolNode, testNode;
            GetNodes(treeView1, out inOutNode, out protocolNode, out testNode);

            if (level == 0)// add a new test:
            {               
                var form = new TestEditorForm(null, testSpec);
                form.ShowDialog();
                DrawTree(treeView1, testSpec.tests);
            }
            else {
                Modify(treeView1, testSpec);
            }
        }

        internal static void Modify(TreeView treeView1, TestSpec testSpec)
        {
            if (treeView1.SelectedNode == null)
                return;

            TreeNode inOutNode, protocolNode, testNode;
            GetNodes(treeView1, out inOutNode, out protocolNode, out testNode);
            var form = new TestEditorForm(testNode.Text, testSpec);
            form.ShowDialog();
            DrawTree(treeView1, testSpec.tests);
        }
        
        public static void DrawTree(TreeView treeView1, Dictionary<string, TestBase> tests)
        {
            treeView1.Nodes.Clear();
            foreach (KeyValuePair<string, TestBase> entry in tests)
            {
                TreeNode testNode = new TreeNode(entry.Key);
                treeView1.Nodes.Add(testNode);
                TestBase test = entry.Value;

                var inputs_root = testNode.Nodes.Add("inputs");
                foreach (TestInput input in test.inputs)
                {
                    var pro = inputs_root.Nodes.Add(input.protocol);
                    if (input.port > 0)// null int becomes 0
                        pro.Nodes.Add(new TreeNode($"Port: {input.port}"));
                    else if (input.queue != null)
                        pro.Nodes.Add(new TreeNode($"Queue: {input.queue}"));
                    else
                        pro.Nodes.Add(new TreeNode($"Path: {input.path}"));
                }

                var outputs_root = testNode.Nodes.Add("outputs");
                foreach (KeyValuePair<string, TestOutput> outputEntry in test.outputs)
                {
                    TestOutput output = outputEntry.Value;
                    var pro = outputs_root.Nodes.Add(output.protocol);
                    if (output.port > 0)// null int becomes 0
                        pro.Nodes.Add(new TreeNode($"Port: {output.port}"));
                    else if (output.queue != null)
                        pro.Nodes.Add(new TreeNode($"Queue: {output.queue}"));
                    else
                        pro.Nodes.Add(new TreeNode($"Path: {output.path}"));
                }
            }
        }
        
    }
}
