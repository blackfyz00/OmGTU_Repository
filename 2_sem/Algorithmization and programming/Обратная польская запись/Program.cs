using System.Text;

class Program
{
    static void Main()
    {
        string polish = Console.ReadLine(); string[] entrypolish = new string[polish.Length];
        for (int i = 0; i < polish.Length; i++)
            entrypolish[i]= Convert.ToString(polish[i]);

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < entrypolish.Length; i++)
        {
            if (entrypolish[i] != "+" && entrypolish[i] != "-" && entrypolish[i] != "*" && entrypolish[i] != "/")
                stack.Push(Convert.ToInt32(entrypolish[i]));

            else
            {
                switch (entrypolish[i])
                {
                    case "+":
                        if (stack.Count > 1)
                        {
                            int n1 = stack.Pop();
                            int n2 = stack.Pop();
                            stack.Push(n1 + n2);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: нехватка или избыток элементов для выполнения действия");
                            Environment.Exit(0);
                        }
                        break;
                    case "-":
                        if (stack.Count > 1)
                        {
                            int n3 = stack.Pop();
                            int n4 = stack.Pop();
                            stack.Push(n4 - n3);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: нехватка или избыток элементов для выполнения действия");
                            Environment.Exit(0);
                        }

                        break;
                    case "*":
                        if (stack.Count > 1)
                        {
                            int n5 = stack.Pop();
                            int n6 = stack.Pop();
                            stack.Push(n5 * n6);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: нехватка или избыток элементов для выполнения действия");
                            Environment.Exit(0);
                        }
                        break;
                    case "/":
                        if (stack.Count > 1)
                        {
                            int n7 = stack.Pop();
                            int n8 = stack.Pop();
                            if (n7 != 0)
                                stack.Push(n8 / n7);
                            else
                            {
                                Console.WriteLine("Невозможно поделить на ноль");
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: нехватка или избыток элементов для выполнения действия");
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        Console.WriteLine("знак действия не распознан, введите корректный пример");
                        Environment.Exit(0);
                        break;
                }
            }

        }
        if (stack.Count > 1)
            Console.WriteLine("Ошибка: нехватка действия");
        else
            Console.WriteLine($"Результат: {Convert.ToInt32(stack.Peek())}");

    }
}