using System;
using System.Collections;

namespace Hashtable_example
{
    

    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hash = new Hashtable();

            // 添加键值对到哈希表中
            hash.Add("John", 25);
            hash.Add("Mary", 30);
            hash.Add("Bob", 35);

            // 通过键获取值
            Console.WriteLine("John's age is {0}", hash["John"]);
            Console.WriteLine("Mary's age is {0}", hash["Mary"]);

            // 修改值
            hash["Bob"] = 40;

            // 遍历哈希表中的键值对
            foreach (DictionaryEntry entry in hash)
            {
                Console.WriteLine("Key = {0}, Value = {1}", entry.Key, entry.Value);
            }

            // 检查是否包含某个键
            if (hash.ContainsKey("Alice"))
            {
                Console.WriteLine("Alice's age is {0}", hash["Alice"]);
            }
            else
            {
                Console.WriteLine("Alice is not in the hash table");
            }
        }
    }

}
