using System;
using System.IO;
class Program
{
   static void Main()
    {
        int MaxN = 3;
        List<int[]> NKZ = new List<int[]>();

        int k = 1, z = 0; bool trap = false, not = false;
        for (int n = 1; n < MaxN + 1; n++)
        {
            while (k <= 2*n)
            {
                if (k - 2 * n == 0 || k % Math.Abs(k - 2 * n) == 0)
                {
                    not = false;
                    int i = n;
                    while (i != 0)
                    {
                        i = i * 2 - k; z++;
                        if (i == 0) { trap = true; break; }
                        if (i < 0 || i ==k) { not = true; z = 0; break; }
                    }
                    if(not) { k++; continue; }
                    if (trap) { NKZ.Add([n, k, z]); z = 0; k++; trap = false; }
                }
                else k++;
            }
            k = 1;
        }
        Console.WriteLine("Возможны следующие комбинации:");
        foreach (var q in NKZ)
        {
            Console.WriteLine(q[0] + " " + q[1] + " " + q[2]);
        }
    }
}