using System;
using System.IO;
class Program
{
    class GearWheel
    {
        public int number;
        public double teeths;
        public int[] Connect_gear;
        public int direction;
        public int indx = 0;
        public int visit = 0;
    }
    static void Main()
    {
        List<string> input = new List<string>()
        {
            "3 2",
            "1 40",
            "2 15",
            "3 20",
            "1 2",
            "2 3",
            "1 3",
            "-1"
        };
        Queue<string> output = new Queue<string>();
        
        string str = input[0]; input.Remove(input[0]);
        string[] partstr = str.Split(" ");
        int n = Convert.ToInt32(partstr[0]);
        int m = Convert.ToInt32(partstr[1]);
        GearWheel[] gears = new GearWheel[n];
       
        for (int i = 0; i < n; i++)
        {
            gears[i] = new GearWheel();
            gears[i].Connect_gear = new int[n];
            string str1 = input[0]; input.Remove(input[0]);
            string[] partstr1 = str1.Split(" ");
            gears[i].number = Convert.ToInt32(partstr1[0]);
            gears[i].teeths = Convert.ToDouble(partstr1[1]);
        }
        for (int i = 0; i < m; i++)
        {
            string str1 = input[0]; input.Remove(input[0]);
            string[] partstr1 = str1.Split(" ");
            int one = Convert.ToInt32(partstr1[0]);
            int two = Convert.ToInt32(partstr1[1]);
            if (one >= 1 || one <= n || two >= 1 || two <= n)
            {
                for (int j = 0; j < n; j++)
                {
                    if (gears[j].number == one)
                    {
                        gears[j].Connect_gear[gears[j].indx] = two;
                        gears[j].indx++;
                    }
                    if (gears[j].number == two)
                    {
                        gears[j].Connect_gear[gears[j].indx] = one;
                        gears[j].indx++;
                    }
                }
            }
        }
        int start = 0;
        int end = 0;
        string str3 = input[0]; input.Remove(input[0]);
        string[] partstr3 = str3.Split(" ");
        string str4 = input[0]; input.Remove(input[0]);
        string[] partstr4 = str4.Split(" ");
        int three = Convert.ToInt32(partstr3[0]);
        int four = Convert.ToInt32(partstr3[1]);
        for (int j = 0; j < n; j++)
        {
            if (gears[j].number == three)
            {
                gears[j].direction = Convert.ToInt32(partstr4[0]);
                start = j;
            }
            if (gears[j].number == four) end = j;
        }
        if (search(gears[start], ref gears))
        {
            output.Enqueue("1");
            output.Enqueue(Convert.ToString(gears[end].direction));
            output.Enqueue(Convert.ToString(gears[start].teeths / gears[end].teeths) + "."+"000");
        }
        else output.Enqueue("-1");

        foreach(var q in output)
        {
            Console.WriteLine(q);
        }
    }
    static bool search(GearWheel gear, ref GearWheel[] gears)
    {
        for (int i = 0; i < gear.indx; i++)
        {
            for (int j = 0; j < gears.Length; j++)
            {
                if (gear.Connect_gear[i] == gears[j].number)
                {
                    if (gears[j].direction == 0) gears[j].direction = -gear.direction;
                    else if (gears[j].direction != -gear.direction) return false;
                    if (gears[j].visit != 1)
                    {
                        gears[j].visit = 1;
                        if (search(gears[j], ref gears) == false) return false;
                    }
                }
            }
        }
        return true;
    }
}