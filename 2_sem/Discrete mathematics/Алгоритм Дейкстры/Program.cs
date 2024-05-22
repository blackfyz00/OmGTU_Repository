using System;
using System.Collections;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        const int o = 200000; const int countcities = 6;
        int[,] cities = {  {0,700,200,o,o,o },
                          { 700,0,300,200,o,400},
                          { 200,300,0,700,600,o},
                          { o,200,700,0,300,100},
                          { o,o,600,300,0,500},
                          { o,400,o,100,500,0}};

        int startcity = 2; int endcity = 5;

        int thiscity = startcity - 1; int[] min = { 100, 0 };
        int[] mark = new int[countcities]; mark[thiscity] = 0;
        for (int i = 0; i < countcities; i++)
            if (i != thiscity) mark[i] = o;

        bool[] constmark = new bool[countcities]; constmark[thiscity] = true; int constmarker = 0;

        int[] parent = new int[countcities]; parent[thiscity] = o;

        while (constmarker != countcities)
        {
            for (int i = 0; i < countcities; i++)
                if (mark[i] > mark[thiscity] + cities[thiscity, i] && constmark[i] != true)
                {
                    mark[i] = mark[thiscity] + cities[thiscity, i];
                    parent[i] = thiscity+1;
                }

            for (int i = 0; i < countcities; i++)
                if (mark[i] < min[0] && constmark[i] == false)
                { min[0] = mark[i]; min[1] = i; }

            constmark[min[1]] = true; constmarker++;
            thiscity = min[1];
            min[0] = o; min[1] = 0;
        }

        Console.WriteLine($"Минимальное расстояние по алгоритму Дейкстры от города {startcity} " +
            $"до города {endcity} = {mark[endcity - 1]}");
        Console.Write($"Восстановление пути: {endcity} - ");
        
        while(endcity!=startcity)
        {
            Console.Write(parent[endcity - 1] + " - ");
            endcity = parent[endcity - 1];
        }
    }
}