
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Graph G = new Graph(6);

        G.FindMinRoad(1,6);

    }


}

public class Graph
{
    List<Edge> edges = new List<Edge>();
    int vertexes { get; set; }

    public Graph(int vertexes)
    {
        this.vertexes = vertexes;
        edges.Add(new Edge(1, 2, 7));
        edges.Add(new Edge(1, 3, 9));
        edges.Add(new Edge(2, 4, -1));
        edges.Add(new Edge(2, 5, -2));
        edges.Add(new Edge(3, 2, -3));
        edges.Add(new Edge(3, 5, 2));
        edges.Add(new Edge(4, 5, 1));
        edges.Add(new Edge(4, 6, 3));
        edges.Add(new Edge(5, 6, 3));
        
    }

    public void FindMinRoad(int begin, int end)
    {
        int[,] marks = new int[vertexes,2]; int beginvertex = begin; int endvertex = end;

        for (int i = 0; i < vertexes; i++)
            if (i != beginvertex - 1) { marks[i,0] = 200; marks[i, 1] = 200; }

        foreach (var edge in edges)
            if (edge.From == beginvertex)
            { marks[edge.To - 1,0] = edge.Weight; marks[edge.To - 1, 1] = beginvertex; }

        for (int i = 0; i < vertexes - 1; i++)
            foreach (var edge in edges)
            {
                if (marks[edge.To - 1,0] > marks[edge.From - 1,0] + edge.Weight)
                { 
                    marks[edge.To - 1,0] = marks[edge.From - 1,0] + edge.Weight;
                    marks[edge.To - 1, 1] = edge.From;
                }
            }

        Console.WriteLine($"Минимальное расстояние по алгоритму Форда-Белмана от вершины {beginvertex} " +
            $"до вершины {endvertex} = {marks[endvertex - 1,0]}");
        Console.Write($"Восстановление пути: {endvertex} - ");

        while (beginvertex != endvertex)
        { 
            Console.Write($"{marks[endvertex - 1, 1]} - ");
            endvertex = marks[endvertex - 1, 1];
        }
        
        Console.WriteLine();
    }

    public class Edge
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }

        public Edge(int from, int to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }
}

