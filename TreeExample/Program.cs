using System;
using System.Collections.Generic;

namespace TreeExample
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public TreeNode<T> Parent { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode(T data)
        {
            Data = data;
            Parent = null;
            Children = new List<TreeNode<T>>();
        }

        public void AddChild(TreeNode<T> child)
        {
            Children.Add(child);
            child.Parent = this;
        }

        public void RemoveChild(TreeNode<T> child)
        {
            Children.Remove(child);
            child.Parent = null;
        }

        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        public int GetDepth()
        {
            int depth = 0;
            TreeNode<T> node = this;
            while (node.Parent != null)
            {
                depth++;
                node = node.Parent;
            }
            return depth;
        }

        public void Traverse(Action<TreeNode<T>> action)
        {
            action(this);
            foreach (var child in Children)
            {
                child.Traverse(action);
            }
        }

        public void Print()
        {
            Traverse(node => Console.WriteLine($"{new string('-', node.GetDepth() * 2)}{node.Data}"));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TreeNode<string> root = new TreeNode<string>("Root");

            TreeNode<string> node1 = new TreeNode<string>("Node1");
            TreeNode<string> node2 = new TreeNode<string>("Node2");
            TreeNode<string> node3 = new TreeNode<string>("Node3");
            TreeNode<string> node4 = new TreeNode<string>("Node4");
            TreeNode<string> node5 = new TreeNode<string>("Node5");
            TreeNode<string> node6 = new TreeNode<string>("Node6");
            root.AddChild(node1);
            root.AddChild(node2);

            node1.AddChild(node3);
            node1.AddChild(node4);
            node1.AddChild(node6);

            node2.AddChild(node5);

            root.Print();
            Console.WriteLine(node5.GetDepth());
            Console.WriteLine(node2.GetDepth());
        }
    }
}
