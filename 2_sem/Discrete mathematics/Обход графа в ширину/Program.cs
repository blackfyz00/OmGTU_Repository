
using System.Collections;
using System.Collections.Generic;

class Program
{
    const int o = 200;
    static void Main()
    {
        int vertexes = 10;
        int[,] graph = { { 0,o,o,1,o,1,o,o,o,o},
                         { o,0,1,1,o,1,1,1,o,o},
                         { o,1,0,1,o,o,o,o,1,o},
                         { 1,1,1,0,o,1,o,o,1,o},
                         { o,o,o,o,0,o,o,1,o,o},
                         { 1,1,o,1,o,0,1,o,o,1},
                         { o,1,o,o,o,1,0,o,o,o},
                         { o,1,o,o,1,o,o,0,o,1},
                         { o,o,1,1,o,o,o,o,0,o},
                         { o,o,o,o,o,1,o,1,o,0},
                       };

        Queue<int> queue = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();
        int start = 0; int sum = 1;
        int[] distances = new int[vertexes]; int[] parents = new int[vertexes];

        distances[start] = 0; parents[start] = 0;

        queue.Enqueue(start);

        while(queue.Count > 0 || visited.Count != vertexes)
        {
            start = queue.Dequeue(); visited.Add(start);
            for (int i=0;i<vertexes; i++)
            {
                if (graph[start, i] != 0 && graph[start, i] != o && !visited.Contains(i) && !queue.Contains(i))
                {
                    queue.Enqueue(i);
                    distances[i] = sum;
                    parents[i] = start;
                }
            }
            sum++;
            
        }


        Console.WriteLine();
    }

}

    

