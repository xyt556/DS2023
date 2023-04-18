// 引用命名空间
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree // 定义命名空间 tree
{
    public class TreeNode<T> // 定义泛型类 TreeNode<T>，T表示节点保存的数据类型
    {
        public T Data { get; set; } // 节点保存的数据，使用自动属性
        public List<TreeNode<T>> Children { get; set; } // 子节点列表，使用 List<T> 类

        
        public TreeNode(T data) // 构造函数，传入节点保存的数据
        {
            Data = data;
            Children = new List<TreeNode<T>>(); // 初始化子节点列表
        }

        public void AddChild(TreeNode<T> child) // 添加子节点
        {
            Children.Add(child); // 将子节点加入子节点列表
        }

        public void RemoveChild(TreeNode<T> child) // 删除子节点
        {
            Children.Remove(child); // 从子节点列表中删除子节点
        }
    }

}