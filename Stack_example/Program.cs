//案例1
//using System;
//using System.Collections;

//class Program
//{
//    static void Main(string[] args)
//    {
//        string input = "(([])){}";
//        Stack stack = new Stack();

//        foreach (char c in input)
//        {
//            if (c == '(' || c == '[' || c == '{')
//            {
//                stack.Push(c);
//            }
//            else if (c == ')' || c == ']' || c == '}')
//            {
//                if (stack.Count == 0)
//                {
//                    Console.WriteLine("括号不匹配");
//                    return;
//                }

//                char top = (char)stack.Pop();
//                if ((c == ')' && top != '(') ||
//                    (c == ']' && top != '[') ||
//                    (c == '}' && top != '{'))
//                {
//                    Console.WriteLine("括号不匹配");
//                    return;
//                }
//            }
//        }

//        if (stack.Count == 0)
//        {
//            Console.WriteLine("括号匹配");
//        }
//        else
//        {
//            Console.WriteLine("括号不匹配");
//        }
//    }
//}


//案例2


//using System;
//using System.Collections;

//class Program
//{
//    static Stack history = new Stack();

//    static void Main(string[] args)
//    {
//        Visit("https://www.google.com/");
//        Visit("https://www.baidu.com/");
//        Visit("https://www.bing.com/");
//        Back();
//        Back();
//        Back();
//        Back();
//    }

//    static void Visit(string url)
//    {
//        Console.WriteLine("访问页面：" + url);
//        history.Push(url);
//    }

//    static void Back()
//    {
//        if (history.Count == 0)
//        {
//            Console.WriteLine("已经回到最开始的页面，无法后退");
//            return;
//        }

//        string url = (string)history.Pop();
//        Console.WriteLine("后退到页面：" + url);
//    }
//}


//案例3

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Fibonacci(6));
    }

    static int Fibonacci(int n)
    {
        if (n == 0)
        {
            return 0;
        }
        else if (n == 1)
        {
            return 1;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
