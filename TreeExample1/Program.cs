/*
 * 该程序的实现过程如下：
 * 定义了一个 FileTreeNode 类表示文件树的节点，其中包含节点名称和子节点列表。
 * 在 Main 方法中创建了一个根节点，调用 TraverseDirectory 方法来遍历目录并构建文件树。
 * TraverseDirectory 方法递归遍历指定目录中的所有子目录和文件，对于每个子目录和文件，
 * 创建一个节点并将其添加为父节点的子节点。
 * 最后调用根节点的 PrintTree 方法，打印整个文件树。
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace TreeExample
{
    public class FileTreeNode
    {
        public string Name { get; private set; }
        public List<FileTreeNode> Children { get; private set; }

        public FileTreeNode(string name)
        {
            Name = name;
            Children = new List<FileTreeNode>();
        }

        public void AddChild(FileTreeNode child)
        {
            Children.Add(child);
        }

        public void PrintTree(string indent = "")
        {
            Console.WriteLine(indent + Name);

            foreach (FileTreeNode child in Children)
            {
                child.PrintTree(indent + "    ");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = @"D:\dist";

            FileTreeNode root = new FileTreeNode(rootPath);
            TraverseDirectory(root, rootPath);

            root.PrintTree();
        }

        static void TraverseDirectory(FileTreeNode parentNode, string path)
        {
            try
            {
                foreach (string directory in Directory.GetDirectories(path))
                {
                    FileTreeNode node = new FileTreeNode(Path.GetFileName(directory));
                    parentNode.AddChild(node);
                    TraverseDirectory(node, directory);
                }

                foreach (string file in Directory.GetFiles(path))
                {
                    FileTreeNode node = new FileTreeNode(Path.GetFileName(file));
                    parentNode.AddChild(node);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Access to {path} was denied: {e.Message}");
            }
        }
    }
}
