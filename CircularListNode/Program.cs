using System;

// 定义循环单链表的节点类
public class CircularListNode<T>
{
    public T Value { get; set; }  // 节点存储的值
    public CircularListNode<T> Next { get; set; }  // 指向下一个节点的指针

    // 节点类的构造函数
    public CircularListNode(T value)
    {
        Value = value;
        Next = null;
    }
}

// 定义循环单链表类
public class CircularLinkedList<T>
{
    private CircularListNode<T> head;  // 头节点

    // 循环单链表类的构造函数
    public CircularLinkedList()
    {
        head = null;
    }

    // 向循环单链表中添加一个节点
    public void Add(T value)
    {
        CircularListNode<T> newNode = new CircularListNode<T>(value);

        // 如果链表为空，则将新节点作为头节点
        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
        }
        // 如果链表不为空，则将新节点插入到链表末尾
        else
        {
            CircularListNode<T> current = head;
            while (current.Next != head)
            {
                current = current.Next;
            }
            current.Next = newNode;
            newNode.Next = head;
        }
    }

    // 从循环单链表中删除一个节点
    public void Remove(T value)
    {
        // 如果链表为空，则直接返回
        if (head == null)
        {
            return;
        }

        CircularListNode<T> current = head;
        CircularListNode<T> previous = null;

        // 在链表中查找要删除的节点
        do
        {
            if (current.Value.Equals(value))
            {
                if (previous == null)
                {
                    // 如果要删除的是头节点，则将头节点指向下一个节点
                    head = head.Next;
                }
                else
                {
                    // 如果要删除的是非头节点，则将前一个节点指向下一个节点
                    previous.Next = current.Next;
                }
                break;
            }
            previous = current;
            current = current.Next;
        } while (current != head);
    }

    // 遍历循环单链表并输出节点的值
    public void Print()
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        Console.Write(head.Value);
        CircularListNode<T> current = head.Next;
        while (current != head)
        {
            Console.Write(" -> " + current.Value);
            current = current.Next;
        }
        Console.WriteLine();
    }
}

public class Program
{
    static void Main(string[] args)
    {
        CircularLinkedList<int> list = new CircularLinkedList<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);

        Console.WriteLine("Initial List:");
        list.Print();

        list.Remove(2);

        Console.WriteLine("List after removing 2:");
        list.Print();

        list.Remove(1);

        Console.WriteLine("List after removing 1:");
        list.Print();

        list.Remove(3);

        Console.WriteLine("List after removing 3:");
        list.Print();

        Console.ReadLine();
    }
}
