using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Queue printQueue = new Queue();
        printQueue.Enqueue("Print Job 1");
        printQueue.Enqueue("Print Job 2");
        printQueue.Enqueue("Print Job 3");

        while (printQueue.Count > 0)
        {
            string nextPrintJob = (string)printQueue.Dequeue();
            Console.WriteLine("Printing: " + nextPrintJob);
            // 模拟打印时间
            System.Threading.Thread.Sleep(5000);
        }

        Console.WriteLine("All print jobs completed.");
    }
}
