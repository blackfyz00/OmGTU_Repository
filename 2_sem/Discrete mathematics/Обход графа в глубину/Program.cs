
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

        int start = 0; int komponents = 1;
        Stack<int> stack = new Stack<int> (); 
        HashSet<int> visited = new HashSet<int> (); List<int> unvisited = new List<int>();
        int[] parents = new int[10];
        for (int i = 0; i < vertexes; i++)
        {
            parents[i] = 10;
            unvisited.Add(i);
        }

        parents[start] = start;
        stack.Push(start);
        while (stack.Count > 0)
        {
            while (stack.Count > 0)
            {
                int subvertex = stack.Pop();
                visited.Add(subvertex); unvisited.Remove(subvertex);
                for (int i = 0; i < vertexes; i++)
                {
                    if (graph[subvertex, i] == 1 && !visited.Contains(i))
                    {
                        parents[i] = subvertex;
                        if (stack.Contains(i))
                        {
                            stack.Push(i);
                            stack.Pop();
                            continue;
                        }
                        stack.Push(i);
                    }
                }
            }

            if (visited.Count < vertexes)
                stack.Push(unvisited[0]);
        }
        Console.WriteLine("Количество компонент связанности = "+ komponents);
    }

}



