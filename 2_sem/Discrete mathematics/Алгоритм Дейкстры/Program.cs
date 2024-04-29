using System;
using System.Collections;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        const int o = 200;
        int[,] graph = {  { 0,5,4,o,o },
                          { 5,0,3,6,o },
                          { 4,3,0,3,o },
                          { o,6,3,0,8 },
                          { o,o,o,8,o } };

        int start = 2; int end = 5;

        int thisvert = start - 1; int[] min = { 100, 0 };
        int[] mark = new int[5]; mark[thisvert] = 0;
        for (int i = 0; i < graph.Length / 5; i++)
            if (i != thisvert) mark[i] = 200;

        bool[] constmark = new bool[5]; constmark[thisvert] = true; int constmarker = 0;

        Stack<int> parent = new Stack<int>();

        /*int[] parent = new int[5]; parent[thisvert] = 0;
        for (int i = 0; i < graph.Length / 5; i++)
            if (i != thisvert) parent[i] = 200;*/



        while (constmarker != graph.Length / 5)
        {
            for (int i = 0; i < graph.Length / 5; i++)
                if (mark[i] > mark[thisvert] + graph[thisvert, i])
                { 
                    mark[i] = mark[thisvert] + graph[thisvert, i]; 
                    if(!parent.Contains(thisvert + 1)) parent.Push(thisvert + 1); 
                }

            for (int i = 0; i < graph.Length / 5; i++)
                if (mark[i] < min[0] && constmark[i] == false)
                { min[0] = mark[i]; min[1] = i; }

            constmark[min[1]] = true; constmarker++;          
            thisvert = min[1];
            min[0] = 200; min[1] = 0;
        }

        Console.WriteLine($"Минимальное расстояние по алгоритму Дейкстры от вершины {start} " +
            $"до вершины {end} = {mark[end - 1]}");
        Console.Write($"Восстановление пути: {end} - ");
        foreach (var vertex in parent)
            Console.Write($"{vertex} - ");
    }
}