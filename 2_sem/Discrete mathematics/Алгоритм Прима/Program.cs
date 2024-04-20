
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Graph G = new Graph(6);

        G.FindMST(1);

    }

    
}

public class Graph
{
    List<Edge> edges = new List<Edge>();
    HashSet<int> vertexes = new HashSet<int>();
    int Allvertex { get; set; }

    public Graph(int vertexes)
    {
        Allvertex = vertexes;
        edges.Add(new Edge(1, 2, 6));
        edges.Add(new Edge(1, 4, 5));
        edges.Add(new Edge(1, 3, 1));
        edges.Add(new Edge(2, 3, 5));
        edges.Add(new Edge(2, 5, 3));
        edges.Add(new Edge(4, 3, 5));
        edges.Add(new Edge(4, 6, 2));
        edges.Add(new Edge(6, 3, 4));
        edges.Add(new Edge(5, 3, 6));
        for (int i = 1; i < vertexes + 1; i++)
            this.vertexes.Add(i);
    }

    public void FindMST(int beginvertex)
    {
        int sum = 0;
        HashSet<int> unvisited = new HashSet<int>();
        HashSet<int> visited = new HashSet<int>();

        List<Edge> mst = new List<Edge>();

        for(int i =1; i< vertexes.Count + 1; i++)
        {
            unvisited.Add(i);
        }

        visited.Add(beginvertex);
        unvisited.Remove(beginvertex);

        while (true) 
        {
            List<Edge> edgesforcompare = new List<Edge> ();

            foreach (var edge in edges)
            {
                if ((visited.Contains(edge.To) && unvisited.Contains(edge.From) || 
                    (visited.Contains(edge.From) && unvisited.Contains(edge.To)))
                    && edge.otm == false)
                {           
                    edgesforcompare.Add(edge);
                }

            }

            var array = Edge.Compare(edgesforcompare);
            if (array == null) break;

            if (unvisited.Contains(array[0]))
            { visited.Add(array[0]); unvisited.Remove(array[0]); }

            if (unvisited.Contains(array[1]))
            { visited.Add(array[1]); unvisited.Remove(array[1]); }


            foreach (var edge in edges)
            {
                if (((edge.From == array[0] && edge.To == array[1]) || (edge.To == array[0] && edge.From == array[1])) &&
                    edge.Weight == array[2])

                {   
                    mst.Add(edge); edge.otm = true;
                    sum += edge.Weight;
                }             

            }


        }

        Console.WriteLine($"Остовное дерево весом {sum}:\nОткуда -  Куда -  Вес");

        foreach (var edge in mst)
        {
            Console.WriteLine(edge.From + " " + edge.To + " " + edge.Weight);
        }

        

    }

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

        public static int[] Compare(List<Edge> edgesforcompare)
        {
            int[] vertex = { 0, 0, 0};

            edgesforcompare = edgesforcompare.OrderBy(e => e.Weight).ToList();

            if (edgesforcompare.Count == 0) return vertex = null;

            vertex[0] = edgesforcompare[0].From;
            vertex[1] = edgesforcompare[0].To;
            vertex[2] = edgesforcompare[0].Weight;

            return vertex;
        }
    }
}

