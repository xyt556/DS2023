/*
 * 该程序使用了邻接矩阵来表示图，然后使用Dijkstra算法计算从源节点到其他节点的最短距离，
 * 并打印邻接矩阵和最短路径信息。
 */

using System;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = {
                { 0, 10, 0, 5, 0 },
                { 0, 0, 1, 2, 0 },
                { 0, 0, 0, 0, 4 },
                { 0, 3, 9, 0, 2 },
                { 7, 0, 6, 0, 0 }
            };
            PrintGraph(graph);

            int[] shortestDistances = Dijkstra(graph, 1);
            PrintShortestDistances(shortestDistances);
        }

        static int[] Dijkstra(int[,] graph, int source)
        {
            int numVertices = graph.GetLength(0);
            int[] shortestDistances = new int[numVertices];
            bool[] visited = new bool[numVertices];

            for (int i = 0; i < numVertices; i++)
            {
                shortestDistances[i] = int.MaxValue;
                visited[i] = false;
            }

            shortestDistances[source] = 0;

            for (int i = 0; i < numVertices - 1; i++)
            {
                int minDistance = int.MaxValue;
                int minVertex = -1;

                for (int j = 0; j < numVertices; j++)
                {
                    if (!visited[j] && shortestDistances[j] < minDistance)
                    {
                        minDistance = shortestDistances[j];
                        minVertex = j;
                    }
                }

                visited[minVertex] = true;

                for (int j = 0; j < numVertices; j++)
                {
                    int edgeDistance = graph[minVertex, j];

                    if (edgeDistance > 0 && (shortestDistances[minVertex] + edgeDistance < shortestDistances[j]))
                    {
                        shortestDistances[j] = shortestDistances[minVertex] + edgeDistance;
                    }
                }
            }

            return shortestDistances;
        }

        static void PrintGraph(int[,] graph)
        {
            int numRows = graph.GetLength(0);
            int numCols = graph.GetLength(1);

            Console.WriteLine("邻接矩阵：");
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    Console.Write(graph[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintShortestDistances(int[] shortestDistances)
        {
            Console.WriteLine("从源节点到其他节点的最短距离：");
            for (int i = 0; i < shortestDistances.Length; i++)
            {
                Console.WriteLine(i + ": " + shortestDistances[i]);
            }
            Console.WriteLine();
        }
    }
}
