using System;
using System.Collections.Generic;

class Graph
{
    private int _vertices;
    private List<int>[] _adjacencyList;

    public Graph(int vertices)
    {
        _vertices = vertices;
        _adjacencyList = new List<int>[vertices];
        for (int i = 0; i < vertices; ++i)
            _adjacencyList[i] = new List<int>();
    }

    public void AddEdge(int v, int w)
    {
        _adjacencyList[v].Add(w);
    }

    public void DFS(int v)
    {
        bool[] visited = new bool[_vertices];
        DFSUtil(v, visited);
    }

    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write(v + " ");

        List<int> vList = _adjacencyList[v];
        foreach (var n in vList)
        {
            if (!visited[n])
                DFSUtil(n, visited);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[,] adjacencyMatrix = new int[4, 4] {
    {0, 1, 1, 0},
    {1, 0, 1, 0},
    {1, 1, 0, 1},
    {0, 0, 1 ,0}
};

        for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
            {
                Console.Write(adjacencyMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}