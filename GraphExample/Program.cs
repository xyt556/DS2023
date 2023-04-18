using System;
using System.Collections.Generic;

namespace GraphExample
{
    public class Graph
    {
        private List<Vertex> vertices;
        private int[,] adjMatrix;

        public Graph()
        {
            vertices = new List<Vertex>();
            adjMatrix = new int[10, 10];
        }

        public void AddVertex(string label)
        {
            vertices.Add(new Vertex(label));
        }

        public void AddEdge(int start, int end)
        {
            adjMatrix[start, end] = 1;
        }

        public void TopSort()
        {
            Stack<Vertex> stack = new Stack<Vertex>();

            while (vertices.Count > 0)
            {
                Vertex currentVertex = FindNoSuccessor();
                if (currentVertex == null)
                {
                    Console.WriteLine("Graph has cycles");
                    return;
                }
                stack.Push(currentVertex);
                DeleteVertex(currentVertex);
            }

            Console.Write("Topological Sort: ");
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop().Label + " ");
            }
            Console.WriteLine();
        }

        private Vertex FindNoSuccessor()
        {
            bool isEdge;

            for (int row = 0; row < adjMatrix.GetLength(0); row++)
            {
                isEdge = false;
                for (int col = 0; col < adjMatrix.GetLength(1); col++)
                {
                    if (adjMatrix[row, col] > 0)
                    {
                        isEdge = true;
                        break;
                    }
                }

                if (!isEdge)
                    return vertices[row];
            }

            return null;
        }

        private void DeleteVertex(Vertex vertex)
        {
            int index = vertices.IndexOf(vertex);
            vertices.Remove(vertex);

            for (int i = index; i < vertices.Count; i++)
            {
                for (int j = 0; j < adjMatrix.GetLength(1); j++)
                {
                    adjMatrix[i, j] = adjMatrix[i + 1, j];
                }
            }
            for (int i = index; i < vertices.Count; i++)
            {
                for (int j = 0; j < adjMatrix.GetLength(0); j++)
                {
                    adjMatrix[j, i] = adjMatrix[j, i + 1];
                }
            }

            adjMatrix = (int[,])ResizeArray(adjMatrix, vertices.Count, vertices.Count);
        }

        private static Array ResizeArray(Array arr, int newSizeX, int newSizeY)
        {
            int[,] newArray = new int[newSizeX, newSizeY];
            Array.Copy(arr, 0, newArray, 0, Math.Min(arr.Length, newSizeX * newSizeY));
            return newArray;
        }

    }

    public class Vertex
    {
        public string Label { get; private set; }

        public Vertex(string label)
        {
            Label = label;
        }
    }
    class Programe
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");

            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            graph.TopSort();
        }
    }
    
}
