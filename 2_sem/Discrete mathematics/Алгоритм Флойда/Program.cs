
using System.Collections;
using System.Collections.Generic;

class Program
{
    const int o = 200;
    static void Main()
    {
        int vertexes = 4;
        int[,] graph = { { 0,o,-2,o},
                         { 4,0,3,o},
                         { o,o,0,2},
                         { o,-1,o,0},
                       };

        FindMinRoad(graph, vertexes);

    }

    public static void FindMinRoad(int[,] graph, int vertexes)
    {
        int n = vertexes; Stack<int[,]> iterations = new Stack<int[,]>();
        int[,] thisgraph = new int[vertexes,vertexes];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                thisgraph[i,j] = graph[i,j];

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    if (thisgraph[i, j] > thisgraph[i, k] + thisgraph[k, j] && thisgraph[k, j] != o && thisgraph[i, k] !=o)
                    {
                        int[,] iteration = new int[n,n];
                        for (int l = 0; l < n; l++)
                            for (int m = 0; m < n; m++)
                                iteration[l, m] = thisgraph[l, m];

                        iterations.Push(iteration); 
                        
                        thisgraph[i, j] = thisgraph[i, k] + thisgraph[k, j]; 
                    }
            }
        }

        foreach (var iteration in iterations)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(iteration[i, j] + "  ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

    

