using System;

public class DoublyListNode<T>
{
    public T Value { get; set; }
    public DoublyListNode<T> Next { get; set; }
    public DoublyListNode<T> Prev { get; set; }

    public DoublyListNode(T value)
    {
        Value = value;
        Next = null;
        Prev = null;
    }
}

public class DoublyLinkedList<T>
{
    private DoublyListNode<T> head;

    public DoublyLinkedList()
    {
        head = null;
    }

    public void AddFirst(T value)
    {
        DoublyListNode<T> newNode = new DoublyListNode<T>(value);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
    }

    public void AddLast(T value)
    {
        DoublyListNode<T> newNode = new DoublyListNode<T>(value);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            DoublyListNode<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            newNode.Prev = current;
        }
    }

    public void Remove(T value)
    {
        if (head == null)
        {
            return;
        }

        DoublyListNode<T> current = head;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                if (current.Prev == null)
                {
                    head = current.Next;
                    if (head != null)
                    {
                        head.Prev = null;
                    }
                }
                else if (current.Next == null)
                {
                    current.Prev.Next = null;
                }
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                }
                break;
            }
            current = current.Next;
        }
    }

    public void Print()
    {
        if (head == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        Console.Write("null <-> " + head.Value);
        DoublyListNode<T> current = head.Next;
        while (current != null)
        {
            Console.Write(" <-> " + current.Value);
            current = current.Next;
        }
        Console.WriteLine(" <-> null");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList<int> list = new DoublyLinkedList<int>();

        list.AddFirst(2);
        list.AddFirst(1);
        list.AddLast(3);

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
