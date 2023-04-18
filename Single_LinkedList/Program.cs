using System;

// 定义链表节点类
public class ListNode<T>
{
    public T Value { get; set; }
    public ListNode<T> Next { get; set; }

    public ListNode(T value)
    {
        Value = value;
        Next = null;
    }
}

// 定义链表类
public class LinkedList<T>
{
    private ListNode<T> head;

    public LinkedList()
    {
        head = null;
    }

    // 在链表尾部添加一个节点
    public void Add(T value)
    {
        ListNode<T> newNode = new ListNode<T>(value);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            ListNode<T> currentNode = head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = newNode;
        }
    }

    // 在指定位置插入一个节点
    public void Insert(int index, T value)
    {
        if (index < 0 || index > GetCount())
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        ListNode<T> newNode = new ListNode<T>(value);
        if (index == 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            ListNode<T> currentNode = head;
            for (int i = 0; i < index - 1; i++)
            {
                currentNode = currentNode.Next;
            }
            newNode.Next = currentNode.Next;
            currentNode.Next = newNode;
        }
    }

    // 删除指定位置的节点
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= GetCount())
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (index == 0)
        {
            head = head.Next;
        }
        else
        {
            ListNode<T> currentNode = head;
            for (int i = 0; i < index - 1; i++)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = currentNode.Next.Next;
        }
    }

    // 获取链表中节点的数量
    public int GetCount()
    {
        int count = 0;
        ListNode<T> currentNode = head;
        while (currentNode != null)
        {
            count++;
            currentNode = currentNode.Next;
        }
        return count;
    }

    // 输出链表中的所有节点的值
    public void Print()
    {
        ListNode<T> currentNode = head;
        while (currentNode != null)
        {
            Console.Write(currentNode.Value + " ");
            currentNode = currentNode.Next;
        }
        Console.WriteLine();
    }
}

// 测试代码
class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> list = new LinkedList<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);

        list.Print(); // 输出 1 2 3

        list.Insert(1, 4);

        list.Print(); // 输出 1 4 2 3

        list.RemoveAt(2);

        list.Print(); // 输出 1 4 3

        Console.WriteLine("Node count: " + list.GetCount()); // 输出 Node count: 3
    }
}
