using System;
using System.Collections.Specialized;
using System.Collections;

namespace ListDictionary_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDictionary listDictionary = new ListDictionary();
            // 添加键值对
            listDictionary.Add("apple", 1);
            listDictionary.Add("banana", 2);
            listDictionary.Add("cherry", 3);
            // 通过键获取值
            Console.WriteLine(listDictionary["apple"]);
            Console.WriteLine(listDictionary["banana"]);
            Console.WriteLine(listDictionary["cherry"]);
            // 判断是否包含某个键
            Console.WriteLine(listDictionary.Contains("apple"));
            Console.WriteLine(listDictionary.Contains("durian"));
            // 移除某个键值对
            listDictionary.Remove("cherry");
            // 遍历所有键值对
            foreach (DictionaryEntry item in listDictionary)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            Console.ReadLine();
        }
    }
}
