class Program
{
    static void Main()
    {
        List<int> mas = new() { 1, 2, 25, 50, 32, 678, 345, 897, 3545, 7867 };
        var first = from numb in mas
                    where (numb % 10) % 3 == 0
                    select numb;

        var second = from numb in mas
                     where Enumerable.Range(0, numb.ToString().Length).Any(i => Convert.ToInt32(numb.ToString()[i]) % 2 == 0)
                     select numb;

        Console.Write("Числа, у которых последняя цифра кратна 3: ");
        foreach (var numb in first) Console.Write(numb + " ");

        Console.Write("\n\nЧисла, в которых присутствует четная цифра: ");
        foreach (var numb in second) { Console.Write(numb + " "); }
        Console.WriteLine();

        int[] mas2 = { 1, 2, 25, 33, 324, 52323, 6522, 124 };
        var third = from numb in mas2 
                    where numb % 2 == 0 
                    select numb;

        Console.Write("\nРезультат первой выборки: ");
        foreach (var numb in third) Console.Write(numb + " ");

        mas2 = Enumerable.Range(0, mas2.Length).Select(i => i % 2 != 0 ? 2 : mas2[i]).ToArray();
        var fourth = from numb in mas2
                     where numb % 2 == 0
                     select numb;

        Console.WriteLine("\n\nРезультат второй выборки: ");
        foreach (var numb in fourth) Console.Write(numb + " ");
    }


}