
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество действий");
        int count_operation = int.Parse(Console.ReadLine());

        int expression = 0;
        int ourx = 1;

        for (int i = 0; i < count_operation; i++)
        {
            string[] operation = Console.ReadLine().Split(' ', 2);

            switch (operation[0])
            {
                case "+":

                    if (operation[1] != "x")
                        expression += int.Parse(operation[1]);
                    else
                        ourx++;
                    break;

                case "-":
                    
                    if (operation[1] != "x")
                        expression -= int.Parse(operation[1]);
                    else ourx--; 
                    
                    break;

                case "*":

                    expression *= int.Parse(operation[1]);
                    ourx *= int.Parse(operation[1]);
                    break;

            }
        }
        
        int res = int.Parse(Console.ReadLine());
        res = (res-expression)/ourx;
        Console.WriteLine(res);
    }
}