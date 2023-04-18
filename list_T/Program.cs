using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);

        foreach (int item in list)
        {
            Console.Write(item + " -> ");
        }
        Console.WriteLine("null");

        list.Insert(1, 4);

        foreach (int item in list)
        {
            Console.Write(item + " -> ");
        }
        Console.WriteLine("null");

        list.RemoveAt(2);

        foreach (int item in list)
        {
            Console.Write(item + " -> ");
        }
        Console.WriteLine("null");

        Console.ReadKey();
    }
}