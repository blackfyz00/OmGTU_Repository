using System.Reflection.Metadata.Ecma335;
delegate double del();
interface ICalc
{
    double Plus();
    double Minus();
    double Multiplication();
    double Division();
    double Sqrt();
    double Sin();
    double Cos();
}

class Calc : ICalc
{
    public double Plus()
    {
        Console.Clear();
        Console.Write("Введите 1 число: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("\nВведите 2 число: ");
        double b = double.Parse(Console.ReadLine());
        return a + b;
    }
    public double Minus()
    {
        Console.Clear();
        Console.Write("Введите 1 число: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("\nВведите 2 число: ");
        double b = double.Parse(Console.ReadLine());
        return a - b;
    }
    public double Multiplication()
    {
        Console.Clear();
        Console.Write("Введите 1 число: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("\nВведите 2 число: ");
        double b = double.Parse(Console.ReadLine());
        return a * b;
    }
    public double Division()
    {
        Console.Clear();
        Console.Write("Введите 1 число: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("\nВведите 2 число: ");
        double b = double.Parse(Console.ReadLine());
        if (b != 0)
            return a / b;
        else
            Console.WriteLine("Деление на ноль невозможно"); return double.NaN;
    }
    public double Sqrt()
    {
        Console.Clear();
        Console.Write("Введите число: ");
        double a = double.Parse(Console.ReadLine());
        if (a > 0)
            return Math.Sqrt(a);
        else
            Console.WriteLine("Корень из отрициательного числа извлечь невозможно"); return double.NaN;
    }
    public double Sin()
    {
        Console.Clear();
        Console.Write("Введите угол в радианах от 0 до pi/2: ");
        double a = double.Parse(Console.ReadLine());
        return Math.Sin(a);
    }
    public double Cos()
    {
        Console.Clear();
        Console.Write("Введите угол в радианах от 0 до pi/2: ");
        double a = double.Parse(Console.ReadLine());
        return Math.Cos(a);
    }
}
class Program
{
    static void Main()
    {
        Calc prog = new Calc();
        del operation = prog.Plus;
        double res = 0;
        while (true)
        {
            Console.Clear();
            Console.Write("Введите номер операции:\n1)сумма\n2)вычитание\n3)умножение\n4)деление\n5)извлечение квадратного корня\n6)sin\n7)cos\n8)выход\n\nОперация: ");
            double n = double.Parse(Console.ReadLine());
            switch (n)
            {
                case 1: operation = prog.Plus; break;
                case 2: operation = prog.Minus; break;
                case 3: operation = prog.Multiplication; break;
                case 4: operation = prog.Division; break;
                case 5: operation = prog.Sqrt; break;
                case 6: operation = prog.Sin; break;
                case 7: operation = prog.Cos; break;
            }
            if (n == 8)
                break;
            res = operation();
            Console.WriteLine($"\nРезультат: {res}");
            Console.ReadLine();
        }
    }
}