using System.Collections.Generic;
using System;
public class CircularLinkedList<T>
{
    private LinkedList<T> list = new LinkedList<T>();
    public void Add(T value)
    {
        list.AddLast(value);
    }
    public void Remove(T value)
    {
        list.Remove(value);
    }
    public bool Contains(T value)
    {
        return list.Contains(value);
    }
    public void Print()
    {
        // 判断链表是否为空
        if (list.Count == 0)
        {
            return;
        }
        // 定义当前节点为链表的第一个节点
        var currentNode = list.First;
        do
        {
            // 输出当前节点的值
            Console.Write(currentNode.Value + " ");
            // 将当前节点指向下一个节点，如果下一个节点为空，就将当前节点指向链表的第一个节点
            currentNode = currentNode.Next ?? list.First;
        } while (currentNode != list.First); // 当当前节点不等于链表的第一个节点时，循环继续
        Console.WriteLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        CircularLinkedList<int> list = new CircularLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Print();
        list.Remove(2);
        list.Remove(5);
        list.Print();
        Console.WriteLine(list.Contains(3));
        Console.WriteLine(list.Contains(5));
        Console.ReadLine();
    }
}
