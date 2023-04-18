using System;
using System.Collections.Specialized;

namespace ListDictionaryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new ListDictionary instance
            ListDictionary listDictionary = new ListDictionary();

            // Add some key/value pairs to the dictionary
            listDictionary.Add("key1", "value1");
            listDictionary.Add("key2", "value2");
            listDictionary.Add("key3", "value3");

            // Display the number of items in the dictionary
            Console.WriteLine("Count: {0}", listDictionary.Count);

            // Display the value associated with key2
            Console.WriteLine("Value for key2: {0}", listDictionary["key2"]);

            // Remove an item from the dictionary
            listDictionary.Remove("key2");

            // Display the number of items in the dictionary after removing an item
            Console.WriteLine("Count after removing an item: {0}", listDictionary.Count);

            // Iterate through the dictionary and display its key/value pairs
            foreach (var key in listDictionary.Keys)
            {
                Console.WriteLine("{0}: {1}", key, listDictionary[key]);
            }
        }
    }
}


