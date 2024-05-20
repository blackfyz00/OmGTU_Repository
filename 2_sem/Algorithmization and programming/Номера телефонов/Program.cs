class Calls
{
    public string Numberfrom { get; set; }
    public string Numberto { get; set; }
    public string Date { get; set; }
    public int CountMin { get; set; }
    public Calls(string numberfrom, string numberto, string date, int minimalminutes)
    {
        Numberfrom = numberfrom;
        Numberto = numberto;
        Date = date;
        CountMin = minimalminutes;
    }
}
class Program
{
    static void Main()
    {
        List<Calls> calls = new List<Calls>();
        while (true)
        {
            Console.Write("Введите номер телефона с которого звонили: ");
            string numberfrom = Console.ReadLine();

            Console.Write("Введите номер телефона на который звонили: ");
            string numberto = Console.ReadLine();

            Console.Write("Введите дату звонка: ");
            string data = Console.ReadLine();

            Console.Write("Введите количество минут звонка: ");
            int minimalminutes = int.Parse(Console.ReadLine());

            Calls call = new Calls(numberfrom, numberto, data, minimalminutes);
            calls.Add(call);
            Console.Write("Для остановки введите end");
            if (Console.ReadLine() == "end")
                break;
        }

        while (true)
        {
            Console.Write("Введите номер абонента: ");
            string mannumber = Console.ReadLine();

            string num_often = Find_often_number(calls, mannumber);
            Console.WriteLine("Номер, на который чаще всего звонил выбранный абонент: " + num_often);

            Dictionary<string, int> calls_often = new Dictionary<string, int>();
            AddDictionary(calls_often, calls, mannumber, num_often);

            Console.WriteLine($"Информация о звонках абонента {mannumber} абоненту {num_often} по датам: ");
            Print_Dictionary(calls_often);

            string number_maxtime = Find_Talk_num(calls, mannumber);
            Console.WriteLine();

            Console.WriteLine($"Абонент {mannumber} наибоильшее количество минут разговаривал с {number_maxtime}");
            
            Dictionary<string, int> calls_max_time = new Dictionary<string, int>();
            AddDictionary(calls_max_time, calls, mannumber, number_maxtime);
            AddDictionary(calls_max_time, calls, number_maxtime, mannumber);
            
            Console.WriteLine($"Информация о разговорах абонента {mannumber} с абонентом {number_maxtime}");
            Print_Dictionary(calls_max_time);
           
            Console.Write("Введите end для остановки: ");
            if (Console.ReadLine() == "end")
                break;
        }
    }
    static string Find_often_number(List<Calls> calls, string number_from)
    {
        int count = 0;
        int count2 = 0;
        string number_oftencalls = " ";
        for (int i = 0; i < calls.Count; i++)
        {
            if (calls[i].Numberfrom == number_from)
            {
                for (int j = 0; j < calls.Count; j++)
                {
                    if (calls[j].Numberto == calls[i].Numberto)
                        count++;
                }
                if (count > count2)
                {
                    count2 = count;
                    number_oftencalls = calls[i].Numberto;
                }
                count = 0;
            }
        }
        return number_oftencalls;
    }
    static void Print_Dictionary(Dictionary<string, int> dictionary)
    {
        Console.WriteLine();
        Console.WriteLine("Дата|минуты");
        ICollection<string> list = dictionary.Keys;
        foreach (string s in list)
        {
            Console.WriteLine($"{s} - {dictionary[s]}");
        }
    }
    static string Find_Talk_num(List<Calls> calls, string num)
    {
        Dictionary<string, int> diction = new Dictionary<string, int>();
        for (int i = 0; i < calls.Count; i++)
        {
            if (num == calls[i].Numberfrom)
            {
                if (!diction.ContainsKey(calls[i].Numberto))
                    diction.Add(calls[i].Numberto, calls[i].CountMin);
                else
                    diction[calls[i].Numberto] += calls[i].CountMin;
            }
            if (num == calls[i].Numberto)
            {
                if (!diction.ContainsKey(calls[i].Numberfrom))
                {
                    diction.Add(calls[i].Numberfrom, calls[i].CountMin);
                }
                else
                    diction[calls[i].Numberfrom] += calls[i].CountMin;
            }
        }
        ICollection<string> keys = diction.Keys;
        int count_min = 0;
        string max_min_num = "";
        foreach (string s in keys)
        {
            if (diction[s] > count_min)
            {
                count_min = diction[s];
                max_min_num = s;
            }
        }
        return max_min_num;
    }

    static void AddDictionary(Dictionary<string, int> dictionary, List<Calls> calls, string abonent, string number)
    {
        for (int i = 0; i < calls.Count; i++)
        {
            if (calls[i].Numberfrom == abonent && calls[i].Numberto == number)
            {
                if (!dictionary.ContainsKey(calls[i].Date))
                    dictionary.Add(calls[i].Date, calls[i].CountMin);
                else
                    dictionary[calls[i].Date] += calls[i].CountMin;
            }
        }
    }
}