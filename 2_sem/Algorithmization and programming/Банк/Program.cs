class Client
{
    public int Number { get; set; }
    public string Name { get; set; }
    public double Surplus { get; set; }
    public double Wastes { get; set; }
    public double Tax => Surplus * 0.05;

    public Client(int number, string name, double surplus, double wastes)
    {
        Number = number;
        Name = name;
        Surplus = surplus;
        Wastes = wastes;
    }
}
class Program
{
    static void Main()
    {
        Client[] clients =
        {
            new Client(10, "Аа аа аа", 100000, 30000),
            new Client(20, "Бб бб бб", 70000, 60000),
            new Client(30, "Вв вв вв", 50000, 10000),
            new Client(40, "Гг гг гг", 300000, 50000),
            new Client(50, "Дд дд дд", 10000, 20000)
        };

        var deficit = clients.Where(d => d.Surplus - d.Wastes - d.Tax < 0);
        Console.WriteLine("Клиенты с отрицательным балансом: ");
        foreach (var d in deficit) { Console.WriteLine(d.Name); }

        var splus = clients.Count(s => s.Surplus - s.Wastes - s.Tax > 0);
        Console.WriteLine($"\nКоличество клиентов с положительным балансом: {splus}");

        Console.WriteLine();
        var maxsurplus = clients.Max(d => d.Surplus);
        var selectionsurplus = clients.Where(d => d.Surplus == maxsurplus);

        Console.WriteLine($"Клиенты с максимальным доходом: ");
        foreach (var client in selectionsurplus) { Console.WriteLine(client.Name); }

        var sumtax = clients.Sum(d => d.Tax);
        Console.WriteLine($"\nОбщая сумма налогов клиентов: {sumtax}");

    }
}