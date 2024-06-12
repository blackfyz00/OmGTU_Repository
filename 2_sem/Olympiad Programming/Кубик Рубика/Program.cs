using System;
class Program
{
    static void Main()
    {
        string[] str = Console.ReadLine().Split(' ');
        int countelements = int.Parse(str[0]);
        int rotations = int.Parse(str[1]);

        string[] point = Console.ReadLine().Split(' ');

        int x = int.Parse(point[0]);
        int y = int.Parse(point[1]);
        int z = int.Parse(point[2]);
        int change = 0;

        for (int i = 0; i < rotations; i++)
        {
            string[] turn = Console.ReadLine().Split(' ');
            string axis  = turn[0];
            int coordinate = int.Parse(turn[1]);
            int sign = int.Parse(turn[2]);
            if (axis == "X")
            {
                if (x == coordinate)
                {
                    if (sign > 0)
                    {
                        change = z;
                        z = countelements + 1 - y;
                        y = change;
                    }
                    else
                    {
                        change = y;
                        y = countelements + 1 - z;
                        z = change;
                    }

                }
            }
            if (axis == "Y")
            {
                if (y == coordinate)
                {
                    if (sign > 0)
                    {
                        change = z;
                        z = countelements + 1 - x;
                        x = change;
                    }
                    else
                    {
                        change = x;
                        x = countelements + 1 - z;
                        z = change;
                    }
                }
            }
            if (axis == "Z")
            {
                if (z == coordinate)
                {
                    if (sign > 0)
                    {
                        change = y;
                        y = countelements + 1 - x;
                        x = change;
                    }
                    else
                    {
                        change = x;
                        x = countelements + 1 - y;
                        y = change;
                    }
                }
            }
        }
        Console.WriteLine($"\nОтвет: {x} {y} {z}");
    }
}