using System;
using System.Collections.Generic;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        string spell = null;
        List<string> Lines = new List<string>();
        while (true)
        {
            string a = Console.ReadLine();
            if (a == "end") break;
            else Lines.Add(a);
        }

        Dictionary<int, string> results = new Dictionary<int, string>();
        for (int i = 0; i < Lines.Count; i++)
        {
            string str = Lines[i];
            string[] parts = str.Split(' ');
            string itr = parts[0];
            string result = null;
            for (int j = 1; j < parts.Length; j++)
            {
                if (int.TryParse(parts[j], out int num)) result += results[num];
                else result += parts[j];
            }
            switch (itr)
            {
                case "MIX":
                    result = "MX" + result + "XM";
                    break;
                case "WATER":
                    result = "WT" + result + "TW";
                    break;
                case "DUST":
                    result = "DT" + result + "TD";
                    break;
                case "FIRE":
                    result = "FR" + result + "RF";
                    break;
            }
            results.Add(i + 1, result);
            spell = result;
        }
        Console.WriteLine(spell);
    }
}