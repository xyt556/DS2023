using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd
{
    
    class Floyd
    {
        static void Main(string[] args)
        {
            //邻接矩阵
            int[,] graph = { { 0, 5, int.MaxValue, 10 },
                         { int.MaxValue, 0, 3, int.MaxValue },
                         { int.MaxValue, int.MaxValue, 0, 1 },
                         { int.MaxValue, int.MaxValue, int.MaxValue, 0 } };

            //求解最短路径
            int[,] shortestPaths = FloydAlgorithm(graph);

            //输出最短路径
            Console.WriteLine("最短路径为：");
            for (int i = 0; i < shortestPaths.GetLength(0); i++)
            {
                for (int j = 0; j < shortestPaths.GetLength(1); j++)
                {
                    Console.Write(shortestPaths[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        // Floyd算法
        static int[,] FloydAlgorithm(int[,] graph)
        {
            int n = graph.GetLength(0);
            int[,] shortestPaths = (int[,])graph.Clone();

            // 对于每个中间节点，遍历每个顶点对
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        // 如果从i到k再到j的路径比已知路径短，更新路径
                        if (shortestPaths[i, k] != int.MaxValue &&
                            shortestPaths[k, j] != int.MaxValue &&
                            shortestPaths[i, k] + shortestPaths[k, j] < shortestPaths[i, j])
                        {
                            shortestPaths[i, j] = shortestPaths[i, k] + shortestPaths[k, j];
                        }
                    }
                }
            }

            return shortestPaths;
        }
    }

}