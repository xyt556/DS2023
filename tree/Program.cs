using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 命名空间 tree
namespace tree
{
    // 程序入口类
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一棵树
            TreeNode<string> root = new TreeNode<string>("root"); // 创建根节点
            TreeNode<string> child1 = new TreeNode<string>("child1"); // 创建子节点1
            TreeNode<string> child2 = new TreeNode<string>("child2"); // 创建子节点2
            root.AddChild(child1); // 将子节点1添加为根节点的子节点
            root.AddChild(child2); // 将子节点2添加为根节点的子节点
            TreeNode<string> grandchild1 = new TreeNode<string>("grandchild1"); // 创建孙子节点1
            child1.AddChild(grandchild1); // 将孙子节点1添加为子节点1的子节点
                                          // 遍历树
            Traverse(root); // 从根节点开始遍历
        }

        // 遍历树的方法
        static void Traverse(TreeNode<string> node)
        {
            Console.WriteLine(node.Data); // 输出当前节点的值
            foreach (TreeNode<string> child in node.Children) // 遍历当前节点的子节点
            {
                Traverse(child); // 递归遍历子节点
            }
        }
    }

}