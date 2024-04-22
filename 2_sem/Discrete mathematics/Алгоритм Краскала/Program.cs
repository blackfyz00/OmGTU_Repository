
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Graph G = new Graph();

        G.FindMST();

    }

    
}

public class Graph
{
    List<Edge> edges = new List<Edge>();
    List<HashSet<int>> vertexes = new List<HashSet<int>>();

    int vertexescount = 6;

    public Graph()
    {
        edges.Add(new Edge(1, 2, 6));
        edges.Add(new Edge(1, 4, 5));
        edges.Add(new Edge(1, 3, 1));
        edges.Add(new Edge(2, 3, 5));
        edges.Add(new Edge(2, 5, 3));
        edges.Add(new Edge(4, 3, 5));
        edges.Add(new Edge(4, 6, 2));
        edges.Add(new Edge(6, 3, 4));
        edges.Add(new Edge(5, 3, 6));
        
        for (int i =1; i < vertexescount; i++)
        vertexes.Add(new HashSet<int>());

        int j = 1;

        foreach (var vertex in vertexes)
        { vertex.Add(j); j++; }
    }

    public void FindMST()
    {
        int sum = 0;
        List<Edge> mst = new List<Edge>();
        edges = edges.OrderBy(e => e.Weight).ToList();

        while (vertexes.Count != 1)
        {
            foreach(var edge in edges)
            {
                for (int i = 0; i < vertexes.Count; i++)
                {
                    if (vertexes[i].Contains(edge.To) && vertexes[i].Contains(edge.From))
                    {edge.otm = true; continue; }

                    if ((!vertexes[i].Contains(edge.To) || !vertexes[i].Contains(edge.From)) && edge.otm == false)
                    {
                        if ((vertexes[i].Contains(edge.To) && !vertexes[i].Contains(edge.From)) || 
                            (vertexes[i].Contains(edge.From) && !vertexes[i].Contains(edge.To)))
                        {
                            mst.Add(edge); sum += edge.Weight;
                            edge.otm = true;
                            vertexes[i].Add(edge.From); vertexes[i].Add(edge.To);

                            foreach (var vertex in vertexes)
                            {
                                if ((vertex.Contains(edge.From) || vertex.Contains(edge.To)) && vertex.Count < vertexes[i].Count)
                                {
                                  foreach(var vertexnumber in vertex)
                                        vertexes[i].Add(vertexnumber);                   
                                    
                                    vertexes.Remove(vertex); break; 
                                }
                            }
                            i = -1;
                            continue;
                        }
                    }
                }
            }
        }

       
       



       Console.WriteLine($"Остовное дерево весом {sum}:\nОткуда -  Куда -  Вес");

        foreach (var edge in mst)
        {
            Console.WriteLine(edge.From + " " + edge.To + " " + edge.Weight);
        }
        

    }

    public static int[] Compare(HashSet<int> a) => a.ToArray();
    

    public class Edge
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }

        public bool otm = false;

        public Edge(int from, int to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }
}

