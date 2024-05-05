class Program
{
    public static void Main()
    {
        const int k = 9;
        const int p = -1;
        const int v = -2;

        int[] coordbegin = new int[2];
        int[] coordend = new int[2];

        const int rangmatrix = 8;

    int[,] matrix = {{p, p, p, p, p, p, p, p},
                    { p, 0, k, k, p, k, v, p},
                    { p, k, k, k, p, k, k, p },
                    { p, k, k, k, k, k, k, p,},
                    { p, p, p, k, p, k, k, p },
                    { p, k, k, k, p, k, k, p },
                    { p, k, k, k, k, k, k, p },
                    { p, p, p, p, p, p, p, p } };

        Queue<int[]> qu = new Queue<int[]>(); int[] ab = new int[2];
        List<int[]> qu2 = new List<int[]>();
        int startstr = 0; int startstb = 0; int quCount = 0;
        int endstr = 0; int endstb = 0;

        int sum = 1; int sum_to_v = 0;

        int[,,] modmatrix = new int[rangmatrix, rangmatrix, 2];

        for (int i = 0; i < rangmatrix; i++)
            for (int j = 0; j < rangmatrix; j++)
                if (matrix[i, j] == p) { modmatrix[i, j, 0] = p; modmatrix[i, j, 1] = 1; }
                else modmatrix[i, j, 0] = matrix[i, j];

        for (int i = 0; i < rangmatrix; i++)
            for (int j = 0; j < rangmatrix; j++)
                if (modmatrix[i, j, 0] == v) { endstr = i; endstb = j; }

        for (int i = 0; i < rangmatrix; i++)
        {
            for (int j = 0; j < rangmatrix; j++)
             if (modmatrix[i, j, 0] == 0) 
                { 
                    startstr = i; startstb = j; 
                    modmatrix[i, j, 1] = 1; break; 
                } 
        }

        if (modmatrix[startstr - 1, startstb - 1, 1] != 1) 
        { qu.Enqueue([startstr - 1, startstb - 1]); modmatrix[startstr - 1, startstb - 1, 1] = 1; };

        if (modmatrix[startstr - 1, startstb, 1] != 1)
        { qu.Enqueue([startstr - 1, startstb]); modmatrix[startstr - 1, startstb, 1] = 1; }

        if (modmatrix[startstr - 1, startstb + 1, 1] != 1)
        { qu.Enqueue([startstr - 1, startstb + 1]); modmatrix[startstr - 1, startstb + 1, 1] = 1; }

        if (modmatrix[startstr, startstb - 1, 1] != 1)
        { qu.Enqueue([startstr, startstb - 1]); modmatrix[startstr, startstb - 1, 1] = 1; }

        if (modmatrix[startstr, startstb + 1, 1] != 1)
        { qu.Enqueue([startstr, startstb + 1]); modmatrix[startstr, startstb + 1, 1] = 1; }

        if (modmatrix[startstr + 1, startstb - 1, 1] != 1)
        { qu.Enqueue([startstr + 1, startstb - 1]); modmatrix[startstr + 1, startstb - 1, 1] = 1; }

        if (modmatrix[startstr + 1, startstb, 1] != 1)
        { qu.Enqueue([startstr + 1, startstb]); modmatrix[startstr + 1, startstb, 1] = 1; }

        if (modmatrix[startstr + 1, startstb + 1, 1] != 1)
        { qu.Enqueue([startstr + 1, startstb + 1]); modmatrix[startstr + 1, startstb + 1, 1] = 1; }

        quCount = qu.Count();
        if (quCount == 0) throw new Exception("Повсюду преграды, путь невозможен");

        while (qu.Count != 0)
       {

            for (int i = 0; i < quCount; i++)
            {            
                ab = qu.Dequeue();
                startstr = ab[0]; startstb = ab[1];

                modmatrix[startstr, startstb, 0] = sum; modmatrix[startstr, startstb, 1] = 1;

                if (startstr == endstr && startstb == endstb)
                {
                    sum_to_v = sum; modmatrix[endstr, endstb, 0] = sum*10;
                    modmatrix[endstr, endstb, 1] = 1;
                }

                if (modmatrix[startstr - 1, startstb - 1, 1] != 1)
                { qu2.Add([startstr - 1, startstb - 1]); modmatrix[startstr - 1, startstb - 1, 1] = 1; };

                if (modmatrix[startstr - 1, startstb, 1] != 1)
                { qu2.Add([startstr - 1, startstb]); modmatrix[startstr - 1, startstb, 1] = 1; }

                if (modmatrix[startstr - 1, startstb + 1, 1] != 1)
                { qu2.Add([startstr - 1, startstb + 1]); modmatrix[startstr - 1, startstb + 1, 1] = 1; }

                if (modmatrix[startstr, startstb - 1, 1] != 1)
                { qu2.Add([startstr, startstb - 1]); modmatrix[startstr, startstb - 1, 1] = 1; }

                if (modmatrix[startstr, startstb + 1, 1] != 1)
                { qu2.Add([startstr, startstb + 1]); modmatrix[startstr, startstb + 1, 1] = 1; }

                if (modmatrix[startstr + 1, startstb - 1, 1] != 1)
                { qu2.Add([startstr + 1, startstb - 1]); modmatrix[startstr + 1, startstb - 1, 1] = 1; }

                if (modmatrix[startstr + 1, startstb, 1] != 1)
                { qu2.Add([startstr + 1, startstb]); modmatrix[startstr + 1, startstb, 1] = 1; }

                if (modmatrix[startstr + 1, startstb + 1, 1] != 1)
                { qu2.Add([startstr + 1, startstb + 1]); modmatrix[startstr + 1, startstb + 1, 1] = 1; }

            }
     
            sum++;
            foreach(var que in qu2)
            {
                qu.Enqueue(que);
            }
            quCount = qu2.Count();
            qu2.Clear();
        }

        if (modmatrix[endstr, endstb, 1] == 0)
        { throw new Exception("Повсюду преграды, путь невозможен"); }


        for (int i = 0; i < rangmatrix; i++)
        {
            for (int j = 0; j < rangmatrix; j++)
                Console.Write(modmatrix[i, j,0] + "\t");
            Console.WriteLine();
        }
        Console.WriteLine("\nРасстояние от точки а до б = " + sum_to_v);




    }
}