using System;
using System.Collections;

namespace ArrayList_test
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();

            list.Add("apple");
            list.Add("banana");
            list.Add("cherry");
            list.Add(1);
            list.Add(2.50);
            
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            //错误：对象类型不能用“+”
            //Console.WriteLine(list[3] + list[4]);
            Console.ReadLine();
        }
    }
}
