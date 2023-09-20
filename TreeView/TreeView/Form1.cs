using System.IO;

namespace TreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateTreeView(@"F:\", null);
        }

        private void PopulateTreeView(string path, TreeNode parentNode)
        {
            string[] directories = System.IO.Directory.GetDirectories(path);

            foreach (string directory in directories)
            {
                TreeNode directoryNode = new TreeNode(System.IO.Path.GetFileName(directory));
                if (parentNode != null)
                {
                    parentNode.Nodes.Add(directoryNode);
                }
                else
                {
                    treeViewDirectories.Nodes.Add(directoryNode);
                }
                PopulateTreeView(directory, directoryNode);
            }
        }

        private void treeViewDirectories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedPath = GetFullPath(e.Node);
            MessageBox.Show("Выбранный путь: " + selectedPath);
        }

        private string GetFullPath(TreeNode node)
        {
            if (node.Parent == null)
            {
                return node.Text;
            }
            else
            {
                return GetFullPath(node.Parent) + "\\" + node.Text;
            }
        }
    }
}