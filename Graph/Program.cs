using System;
using System.Collections.Generic;

public class Graph<T>
{
    private Dictionary<T, List<T>> adjList;

    public Graph()
    {
        adjList = new Dictionary<T, List<T>>();
    }

    public void AddVertex(T vertex)
    {
        if (!adjList.ContainsKey(vertex))
        {
            adjList[vertex] = new List<T>();
        }
    }

    public void AddEdge(T src, T dest)
    {
        if (!adjList.ContainsKey(src))
        {
            adjList[src] = new List<T>();
        }
        if (!adjList.ContainsKey(dest))
        {
            adjList[dest] = new List<T>();
        }
        adjList[src].Add(dest);
        adjList[dest].Add(src);
    }

    public void RemoveVertex(T vertex)
    {
        if (!adjList.ContainsKey(vertex))
        {
            return;
        }
        foreach (T v in adjList[vertex])
        {
            adjList[v].Remove(vertex);
        }
        adjList.Remove(vertex);
    }

    public void RemoveEdge(T src, T dest)
    {
        if (!adjList.ContainsKey(src) || !adjList.ContainsKey(dest))
        {
            return;
        }
        adjList[src].Remove(dest);
        adjList[dest].Remove(src);
    }

    public List<T> GetVertices()
    {
        return new List<T>(adjList.Keys);
    }

    public List<T> GetNeighbors(T vertex)
    {
        if (!adjList.ContainsKey(vertex))
        {
            return new List<T>();
        }
        return new List<T>(adjList[vertex]);
    }

    public void PrintGraph()
    {
        foreach (KeyValuePair<T, List<T>> kvp in adjList)
        {
            Console.Write(kvp.Key + ": ");
            foreach (T v in kvp.Value)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Graph<string> graph = new Graph<string>();
        graph.AddVertex("A");
        graph.AddVertex("B");
        graph.AddVertex("C");
        graph.AddVertex("D");
        graph.AddVertex("E");

        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");
        graph.AddEdge("C", "E");
        graph.AddEdge("D", "E");

        Console.WriteLine("Graph:");
        graph.PrintGraph();

        graph.RemoveVertex("C");
        graph.RemoveEdge("B", "D");

        Console.WriteLine("Graph after removing vertex C and edge B-D:");
        graph.PrintGraph();

        Console.ReadLine();
    }
}
