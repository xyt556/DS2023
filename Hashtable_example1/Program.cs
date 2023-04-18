using System;
using System.Collections;
namespace Hashtable_example1
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public string Gender { get; set; }
        public Student(string name, int age, string major, string gender)
        {
            Name = name;
            Age = age;
            Major = major;
            Gender = gender;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Hashtable students = new Hashtable();

            // 添加学生信息到哈希表中
            Student s1 = new Student("John", 21, "Computer Science", "Male");
            students.Add(1, s1);

            Student s2 = new Student("Mary", 20, "Mathematics", "Female");
            students.Add(2, s2);

            Student s3 = new Student("Bob", 22, "History", "Male");
            students.Add(3, s3);

            // 通过学生编号获取学生信息
            Console.WriteLine("Student 1's name is {0}", ((Student)students[1]).Name);
            Console.WriteLine("Student 2's major is {0}", ((Student)students[2]).Major);

            // 修改学生信息
            ((Student)students[3]).Age = 23;

            // 遍历哈希表中的所有学生信息
            foreach (DictionaryEntry entry in students)
            {
                int id = (int)entry.Key;
                Student student = (Student)entry.Value;
                Console.WriteLine("Student {0} - Name: {1}, Age: {2}, Major: {3}, Gender: {4}",
                    id, student.Name, student.Age, student.Major, student.Gender);
            }

            // 检查哈希表是否包含某个学生信息
            if (students.ContainsValue(s1))
            {
                Console.WriteLine("Student 1's information is in the hash table");
            }
            else
            {
                Console.WriteLine("Student 1's information is not in the hash table");
            }
        }
    }

}
