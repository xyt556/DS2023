using System;
using System.Collections.Generic;

namespace LinkedListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            // 添加元素
            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            list.AddFirst(0);
            Console.WriteLine("初始化链表：");
            // 遍历链表
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
            // 在指定节点前插入元素
            LinkedListNode<int> node = list.Find(3);
            list.AddBefore(node, 6);
            // 在指定节点后插入元素
            node = list.Find(4);
            list.AddAfter(node, 7);
            Console.WriteLine("执行插入后的链表：");
            // 遍历链表
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
            // 删除指定元素
            list.Remove(5);
            // 删除指定节点
            node = list.Find(3);
            list.Remove(node);
            Console.WriteLine("执行删除后的链表：");
            // 遍历链表
            foreach (int item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}

