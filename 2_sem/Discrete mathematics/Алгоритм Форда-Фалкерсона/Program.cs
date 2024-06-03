
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static Program;

class Program
{
    static void Main()
    {
        List<Edge> edges = new List<Edge>()
        {
            new Edge(1,2,30),
            new Edge(1,4,20),
            new Edge(1,3,40),
            new Edge(2,3,50),
            new Edge(2,5,40),
            new Edge(3,4,20),
            new Edge(3,5,30),
            new Edge(4,5,30),
        };

        int start = 1, end = 5, maxfrom=0,maxend=0, sum =0;


        foreach (var edge in edges)
        {
            if (edge.From == start) maxfrom += edge.Free;
            if (edge.From == end) maxend += edge.Free;
        }

        List<Edge> edgesforcompare = new List<Edge>();
        List<Edge> edgeswithflow = new List<Edge>();
        List<int> minimal = new List<int>();

        bool possible = true;
        do
        {
            int nowstart = start, min = 0;
            do
            {
                while (nowstart != end)
                {
                    foreach (var edge in edges)
                    {
                        if (edge.From == nowstart)
                            edgesforcompare.Add(edge);
                    }
                    edgesforcompare = edgesforcompare.OrderByDescending(ed => ed.Free).ToList();
                    if (edgesforcompare[0].Free != 0) edgeswithflow.Add(edgesforcompare[0]);
                    else { possible = false; break; }
                    nowstart = edgesforcompare[0].To;
                    edgesforcompare.Clear();
                }

                if (possible == false) break;
                edgeswithflow = edgeswithflow.OrderByDescending(ed => ed.Free).ToList();
                min = edgeswithflow[edgeswithflow.Count - 1].Free;
                minimal.Add(min);

                foreach (var edge in edges)
                    if (edgeswithflow.Contains(edge))
                    {
                        edge.Free -= min;
                        edge.Load += min;
                        edgeswithflow.Remove(edge);
                    }
            } while (edgeswithflow.Count != 0);
        } while (possible);

        foreach (var m in minimal)
            sum += m;
        minimal.Clear();

        if (sum == maxend || sum == maxfrom)
            Console.WriteLine($"Максимальная мощность потока = {sum}");

        else
        {
            possible = true;
            while (possible)
            {
                int nowstart = start, min = 0;
                int j = 0;
                edgesforcompare.Clear();
                List<Edge> edgesforcompareto = new List<Edge>();
                Stack<bool> edgesforcomparetoo = new Stack<bool>();
                nowstart = start;

                foreach (var edge in edges)
                {
                    if (edge.From == nowstart)
                        edgesforcompare.Add(edge);
                }
                edgesforcompare = edgesforcompare.OrderByDescending(ed => ed.Free).ToList();
                if (edgesforcompare[0].Free == 0) { possible = false; break; }
                edgesforcompareto.Add(edgesforcompare[j]);
                edgesforcomparetoo.Push(true);
                nowstart = edgesforcompareto[0].To;
                edgesforcompare.Clear();

                do
                {
                    foreach (var edge in edges)
                    {
                        if (edge.From == nowstart || edge.To == nowstart)
                            if (!edgesforcompare.Contains(edge)) edgesforcompare.Add(edge);
                    }
                    edgesforcompare = edgesforcompare.OrderByDescending(ed => ed.Free).ToList();
                    if (edgesforcompare[j].Load != edgesforcompare[j].Free + edgesforcompare[j].Load && edgesforcompare[j].From == nowstart)
                    {
                        if (!edgesforcompareto.Contains(edgesforcompare[j]) && edgesforcompare[j].From != start)
                        {
                            edgesforcompareto.Add(edgesforcompare[j]);
                            edgesforcomparetoo.Push(true);
                        }
                        else
                        { j++; continue; }
                    }
                    else
                    {
                        edgesforcompare = edgesforcompare.OrderByDescending(ed => ed.Free).ToList();
                        if (!edgesforcompareto.Contains(edgesforcompare[j]) && edgesforcompare[j].From != start)
                        {
                            edgesforcompareto.Add(edgesforcompare[j]);
                            edgesforcomparetoo.Push(false);
                        }
                        else
                        { j++; continue; }
                    }
                    if (edgesforcomparetoo.Peek() == true) nowstart = edgesforcompareto[edgesforcompareto.Count - 1].To;
                    else { nowstart = edgesforcompareto[edgesforcompareto.Count - 1].From; }
                    edgesforcompare.Clear();
                    j = 0;
                } while (nowstart != end);

                var edgesforcomparetomin = edgesforcompareto.OrderBy(ed => ed.Free).ToList();
                foreach (var ed in edgesforcomparetomin)
                {
                    if (ed.Free != 0) { min = ed.Free; break; }
                    else continue;
                }

                edgesforcomparetoo.Reverse();
                while (edgesforcompareto.Count != 0)
                {
                    Edge ed = edgesforcompareto[0]; bool too = edgesforcomparetoo.Pop();

                    foreach (var edge in edges)
                        if (edge == ed)
                        {
                            if (too == true) { edge.Free -= min; edge.Load += min; }
                            else { edge.Load -= min; edge.Free += min; }
                            edgesforcompareto.Remove(ed);
                        }
                }
                minimal.Add(min);
            }

            foreach (var m in minimal)
                sum += m;
            minimal.Clear();

            if (sum == maxend || sum == maxfrom)
                Console.WriteLine($"Максимальная мощность потока = {sum}");
        }
       
    }

    public class Edge
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Free { get; set; }
        public int Load { get; set; }
        public Edge(int from,int to,int pass) 
        {
            From = from;
            To = to;
            Free = pass;
            Load = 0;
        }
    }
}



