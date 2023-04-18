using System;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    public class Graph
    {
        private int V;  // 顶点个数
        private int[,] graph;  // 图的邻接矩阵表示

        public Graph(int v)
        {
            V = v;
            graph = new int[V, V];

            // 初始化邻接矩阵
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    graph[i, j] = int.MaxValue;
                }
            }
        }

        public void AddEdge(int u, int v, int w)
        {
            graph[u, v] = w;
            graph[v, u] = w;  // 无向图需要加上这行
        }

        public void Dijkstra(int source)
        {
            int[] dist = new int[V];  // 存储源节点到各个节点的最短距离
            bool[] visited = new bool[V];  // 标记各个节点是否被访问过

            // 初始化 dist 和 visited 数组
            for (int i = 0; i < V; i++)
            {
                dist[i] = int.MaxValue;
                visited[i] = false;
            }

            dist[source] = 0;  // 源节点到自身的距离为 0

            // 计算最短路径
            for (int count = 0; count < V - 1; count++)
            {
                int u = GetMinimumDistanceVertex(dist, visited);
                visited[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (!visited[v] && graph[u, v] != int.MaxValue && dist[u] != int.MaxValue
                        && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                    }
                }
            }

            // 输出最短距离
            Console.WriteLine("Vertex   Distance from Source");
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine(i + " \t\t " + dist[i]);
            }
        }

        private int GetMinimumDistanceVertex(int[] dist, bool[] visited)
        {
            int minDist = int.MaxValue;
            int minVertex = 0;

            for (int v = 0; v < V; v++)
            {
                if (!visited[v] && dist[v] <= minDist)
                {
                    minDist = dist[v];
                    minVertex = v;
                }
            }

            return minVertex;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(6);

            graph.AddEdge(0, 1, 2);
            graph.AddEdge(0, 2, 4);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(1, 3, 7);
            graph.AddEdge(2, 4, 3);
            graph.AddEdge(3, 4, 1);
            graph.AddEdge(3, 5, 5);
            graph.AddEdge(4, 5, 2);

            graph.Dijkstra(0);
        }
    }
}
