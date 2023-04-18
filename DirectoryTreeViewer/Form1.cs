/*在C#中，TreeNode是一个内置的类，可以用于表示树形结构的节点。
 * 它被定义在System.Windows.Forms命名空间中，并且通常与Windows窗体应用程序中的TreeView控件一起使用，
 * 用于构建树形结构的用户界面。

一个TreeNode对象表示树中的一个节点，它包含了节点的文本内容、节点的子节点列表、父节点以及其他与节点相关的属性。
使用TreeView控件时，可以通过创建根节点，然后通过Nodes属性向树中添加子节点，形成树形结构。

在TreeNode对象中，常用的属性包括：

    Text：表示节点显示的文本内容。
    Nodes：表示当前节点的子节点集合。
    Parent：表示当前节点的父节点。
    ImageIndex：表示节点在TreeView中显示的图像的索引。
    SelectedImageIndex：表示节点在TreeView中被选中时显示的图像的索引。

通过TreeNode类，我们可以方便地在TreeView控件中创建树形结构，实现复杂的数据展示和交互。*/

using System;
using System.Windows.Forms;
using System.IO;


namespace DirectoryTreeViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadDirectory(string path, TreeNode parentNode)
        {
            try
            {
                string[] directories = Directory.GetDirectories(path);
                foreach (string directory in directories)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(directory);
                    TreeNode node = new TreeNode(dirInfo.Name);
                    parentNode.Nodes.Add(node);
                    LoadDirectory(directory, node);
                }

                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    TreeNode node = new TreeNode(fileInfo.Name);
                    parentNode.Nodes.Add(node);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // handle unauthorized access exceptions
            }
            catch (Exception)
            {
                // handle other exceptions
            }
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            string path = txtPath.Text;
            if (!Directory.Exists(path))
            {
                MessageBox.Show("目录不存在，请重新选择！");
                return;
            }

            treeView1.Nodes.Clear();
            TreeNode rootNode = new TreeNode(path);
            treeView1.Nodes.Add(rootNode);
            LoadDirectory(path, rootNode);
            rootNode.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 添加根节点
            TreeNode rootNode = new TreeNode("zuxian");
            treeView2.Nodes.Add(rootNode);

            // 添加子节点
            TreeNode node1 = new TreeNode("子节点1");
            rootNode.Nodes.Add(node1);

            TreeNode node2 = new TreeNode("子节点2");
            rootNode.Nodes.Add(node2);

            // 添加子节点的子节点
            TreeNode node3 = new TreeNode("子节点3");
            node1.Nodes.Add(node3);

            // 展开根节点
            rootNode.Expand();
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 显示选中的节点文本
            label1.Text = e.Node.Text;
        }
    }
}
