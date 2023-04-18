using System;
using System.Collections.Generic;

struct Person
{
    public string Name;
    public int Age;
    public string Gender;
}

class ComplexList
{
    private List<Person> list;

    public ComplexList()
    {
        list = new List<Person>();
    }

    public void Add(string name, int age, string gender)
    {
        Person person = new Person();
        person.Name = name;
        person.Age = age;
        person.Gender = gender;
        list.Add(person);
    }

    public void RemoveAt(int index)
    {
        list.RemoveAt(index);
    }

    public void Print()
    {
        Console.WriteLine("Index\tName\tAge\tGender");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"{i}\t{list[i].Name}\t{list[i].Age}\t{list[i].Gender}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ComplexList myList = new ComplexList();
        myList.Add("Alice", 25, "Female");
        myList.Add("Bob", 30, "Male");
        myList.Add("Charlie", 35, "Male");

        myList.Print();

        myList.RemoveAt(1);

        Console.WriteLine("After removing Bob:");
        myList.Print();
    }
}






