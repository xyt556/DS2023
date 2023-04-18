using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd
{
    class Program
    {
        static int inf = int.MaxValue;
        static void Main(string[] args)
        {
            Console.WriteLine("请输入节点个数：");
            int V = Int32.Parse(Console.ReadLine());
            int[,] graph = FillMatrix(V);
            Console.WriteLine("最初矩阵: ");
            Print(graph, V);
            var tmp = Floyd(graph, V, V - 1);
            Console.WriteLine("每一对顶点之间的最短距离: ");
            Print(tmp, V);
            Console.ReadLine();
        }

        public static int[,] Floyd(int[,] graph, int V, int c)
        {
            if (c == -1)
            {
                return graph;
            }
            var tmp = graph;
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (graph[i, c] != inf && graph[c, j] != inf && graph[i, j] > graph[i, c] + graph[c, j])
                    {
                        tmp[i, j] = graph[i, c] + graph[c, j];
                    }
                }
            }
            c--;
            return Floyd(tmp, V, c);
        }
        public static void Print(int[,] graph, int V)
        {
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (graph[i, j] == inf)
                    {
                        Console.Write("inf \t");
                    }
                    else
                    {
                        Console.Write(graph[i, j] + "\t");
                    }
                }
                Console.WriteLine();
            }
        }

        public static int[,] FillMatrix(int n)
        {
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(i + 1);
                    Console.Write(" | ");
                    Console.Write(j + 1);
                    Console.Write("\t");
                    int tmp;
                    if (!Int32.TryParse(Console.ReadLine(), out tmp))
                    {
                        tmp = inf;
                        matrix[i, j] = tmp;
                    }
                    matrix[i, j] = tmp;
                }
            }
            return matrix;
        }
    }
}