using System;

namespace FloydAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,] { { 0, 5, int.MaxValue, 10 },
                                        { int.MaxValue, 0, 3, int.MaxValue },
                                        { int.MaxValue, int.MaxValue, 0, 1 },
                                        { int.MaxValue, int.MaxValue, int.MaxValue, 0 } };
            Floyd(graph);
            PrintResult(graph);
        }

        public static void Floyd(int[,] graph)
        {
            int n = graph.GetLength(0);
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (graph[i, k] != int.MaxValue && graph[k, j] != int.MaxValue)
                        {
                            graph[i, j] = Math.Min(graph[i, j], graph[i, k] + graph[k, j]);
                        }
                    }
                }
            }
        }

        public static void PrintResult(int[,] graph)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                for (int j = 0; j < graph.GetLength(1); j++)
                {
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}