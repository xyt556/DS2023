// 方法一：手动实现
using System;
using System.Collections.Generic;

public class StackExample
{
    private string[] items;
    private int top;

    public StackExample(int capacity)
    {
        items = new string[capacity];
        top = -1;
    }

    public void Push(string item)
    {
        if (top == items.Length - 1)
            throw new StackOverflowException();
        items[++top] = item;
    }

    public string Pop()
    {
        if (top == -1)
            throw new InvalidOperationException();
        return items[top--];
    }
}

class Program
{
    static void Main(string[] args)
    {
        StackExample stack = new StackExample(5);
        stack.Push("apple");
        stack.Push("banana");
        stack.Push("cherry");
        Console.WriteLine(stack.Pop()); // Output: cherry
        Console.WriteLine(stack.Pop()); // Output: banana
        Console.WriteLine(stack.Pop()); // Output: apple
    }
}
//方法二：内置数据结构
//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main()
//    {
//        // 创建一个整型栈
//        Stack<int> stack = new Stack<int>();

//        // 将元素压入栈中
//        stack.Push(1);
//        stack.Push(2);
//        stack.Push(3);

//        Console.WriteLine("栈中元素个数：{0}", stack.Count);

//        // 弹出栈顶元素
//        int topElement = stack.Pop();
//        Console.WriteLine("弹出栈顶元素：{0}", topElement);
//        Console.WriteLine("栈中元素个数：{0}", stack.Count);

//        // 获取但不弹出栈顶元素
//        int peekElement = stack.Peek();
//        Console.WriteLine("获取但不弹出栈顶元素：{0}", peekElement);
//        Console.WriteLine("栈中元素个数：{0}", stack.Count);

//        // 清空栈
//        stack.Clear();
//        Console.WriteLine("清空栈后，元素个数：{0}", stack.Count);

//        Console.ReadLine();
//    }
//}
