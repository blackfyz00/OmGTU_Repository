using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static List<Auditorium> auditoriums;
        static bool auditoriumsInit = false;


        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.showMenu();
        }


        public class Menu
        {

            public static void showIfDidntFind()
            {
                Console.Clear();
                Console.WriteLine("Такой аудитории не было найдено\nНажмите любую клавишу, чтобы вернуться в меню");
                Console.ReadKey();
                Console.Clear();
            }

            public void showMenu()
            {
                while (true)
                {
                    Console.Clear();
                    int punkt;
                    Console.WriteLine("1.  Создание базы данных об аудиториях\r\n2.  Добавление аудиторий\r\n3.  Изменение данных аудитории по заданному номеру\r\n4.  Поиск аудиторий с кол-вом посадочных мест больше равным заданного \r\n5.  Поиск аудиторий с проектором \r\n6.  Поиск аудиторий с компьютером и заданным количеством посадочных мест\r\n7.  Поиск аудиторий по номеру этажа\r\n8.  Вывод аудиторий\r\n9.  Выход");
                    punkt = int.Parse(Console.ReadLine());
                    switch (punkt)
                    {
                        case 1:
                            Auditorium.createBD();
                            break;
                        case 2:
                            Auditorium.addToDB();
                            break;
                        case 3:
                            Console.WriteLine("Напишите номер аудитории в формате <<этаж-номер>>");
                            try
                            {
                                Auditorium.changeInfobyNumber(Console.ReadLine());
                            }
                            catch (System.FormatException)
                            {
                                Console.WriteLine("Данные введены некорректно. Операция прервана. Нажмите любую клавишу, чтобы вернуться в меню");
                                Console.ReadKey();
                            }
                            break;
                        case 4:
                            Console.WriteLine("Введите число посадочных мест");
                            try
                            {
                                Auditorium.findAuditoriumswithPlaces(Convert.ToInt32(Console.ReadLine()));
                            }
                            catch (System.FormatException)
                            {
                                Console.WriteLine("Данные введены некорректно. Операция прервана. Нажмите любую клавишу, чтобы вернуться в меню");
                                Console.ReadKey();
                            }
                            break;
                        case 5:
                            Auditorium.findAuditoriumwithProjector();
                            break;
                        case 6:
                            int places, Kompi;
                            Console.WriteLine("Введите количество посадочных мест");
                            places = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите количество ПК");
                            Kompi = int.Parse(Console.ReadLine());
                            try
                            {
                                Auditorium.findAuditoriumwithPCsAndPlaces(places, Kompi);
                            }
                            catch (System.FormatException)
                            {
                                Console.WriteLine("Данные введены некорректно. Операция прервана. Нажмите любую клавишу, чтобы вернуться в меню");
                                Console.ReadKey();
                            }
                            break;
                        case 7:
                            int flat;
                            Console.WriteLine("Введите этаж");
                            flat = int.Parse(Console.ReadLine());
                            try
                            {
                                Auditorium.findAuditoriumbyFlat(flat);
                            }
                            catch (System.FormatException)
                            {
                                Console.WriteLine("Данные введены некорректно. Операция прервана. Нажмите любую клавишу, чтобы вернуться в меню");
                                Console.ReadKey();
                            }
                            break;
                        case 8:
                            Auditorium.getAllInfoAllAuditoriums();
                            break;
                        case 9:
                            Environment.Exit(0);
                            break;

                    }
                }
            }
        }

        public class Auditorium
        {
            private String number;
            private int places;
            private bool projector;
            private int Kompi;
            public Auditorium(String number, int places, bool projector, int Kompi)
            {
                this.number = number;
                this.places = places;
                this.projector = projector;
                this.Kompi = Kompi;
            }

            public static void createBD()
            {
                auditoriums = new List<Auditorium>();
                auditoriumsInit = true;
                Console.Clear();
                Console.WriteLine("Новая база данных успешно создана \nНажмите любую клавишу, чтобы вернуться в меню");
                Console.ReadKey();
                Console.Clear();
            }

            public static void addToDB()
            {
                if (auditoriumsInit)
                {
                    String number, strProjector;
                    int places;
                    bool projector;
                    int Kompi;

                    Console.WriteLine("Введите номер аудитории в формате <<этаж-номер>>");
                    number = Console.ReadLine();

                    if (auditoriums != null)
                    {
                        for (int i = 0; i < auditoriums.Count; i++)
                        {
                            if (auditoriums[i].number == number)
                            {
                                Console.WriteLine("Данная аудитория уже существует. Для редактирования информации об этой данной аудитории воспользуйтесь соответствующей функцией в меню\nНажмите любую клавишу, чтобы вернуться в меню");
                                Console.ReadKey();
                                Console.Clear();
                                return;
                            }
                        }
                    }
                    try
                    {
                        Console.WriteLine("Введите количество посадочных мест");
                        places = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Данные введены некорректно. Добавление аудитории в базу данных прервано. Нажмите любую клавишу, чтобы вернуться в меню");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine("Подтвердите наличие/отсуствие проектора в аудитории(Да/Нет)");
                    strProjector = Console.ReadLine();

                    switch (strProjector)
                    {
                        case "да":
                        case "Да":
                        case "ДА":
                        case "дА":
                            projector = true;
                            Console.WriteLine("Проектор в аудитории присутствует");
                            break;
                        case "нет":
                        case "Нет":
                        case "НЕТ":
                        case "нЕТ":
                        case "нЕт":
                        case "неТ":
                        case "НеТ":
                        case "НЕт":
                            projector = false;
                            Console.WriteLine("Проектор в аудитории отсутствует");
                            break;
                        default:
                            projector = false;
                            Console.WriteLine("Введенная строка не распознана, проектор в аудитории отсутствует");
                            break;
                    }

                    Console.WriteLine("Введите количество компьютеров в аудитории(введите 0 если их нет)");
                    try
                    {
                        Kompi = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Данные введены некорректно. Количество компьютеров в аудитории = 0 \nНажмите клавишу, чтобы продолжить");
                        Kompi = 0;
                        Console.ReadKey();
                    }
                   
                    auditoriums.Add(new Auditorium(number, places, projector, Kompi));
                    Console.Clear();
                    Console.WriteLine("Аудитория успешно добавлена в базу данных \nНажмите любую клавишу, чтобы вернуться в меню");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("База данных не инициализированна. Добавление аудитории в базу данных прервано. Нажмите любую клавишу, чтобы вернуться в меню");
                    Console.ReadKey();
                }
            }


            public static void changeInfobyNumber(String number)
            {
                if (auditoriums != null)
                {
                    Auditorium changingAuditorium = findAuditoriumbyNumber(number);
                    if (changingAuditorium == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Такой аудитории не было найдено\nНажмите любую клавишу, чтобы вернуться в меню");
                        Console.ReadKey();
                        Console.Clear();

                    }
                    else
                    {
                        String changingNumber, strProjector;
                        int changingPlaces, indexOfChangingAuditorium;
                        bool changingProjector;
                        int changingPCs;

                        Console.WriteLine("Введите номер аудитории в формате <<этаж-номер>>");
                        changingNumber = Console.ReadLine();

                        Console.WriteLine("Введите количество посадочных мест");
                        changingPlaces = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Подтвердите наличие/отсуствие проектора в аудитории(Да/Нет)");
                        strProjector = Console.ReadLine();

                        switch (strProjector)
                        {
                            case "да":
                            case "Да":
                            case "ДА":
                            case "дА":
                                changingProjector = true;
                                break;
                            case "нет":
                            case "Нет":
                            case "НЕТ":
                            case "нЕТ":
                            case "нЕт":
                            case "неТ":
                            case "НеТ":
                            case "НЕт":
                                changingProjector = false;
                                break;
                            default:
                                changingProjector = false;
                                break;
                        }

                        Console.WriteLine("Введите количество компьютеров в аудитории(введите 0 если их нет)");
                        changingPCs = int.Parse(Console.ReadLine());

                        Auditorium updatedAuditorium = new Auditorium(changingNumber, changingPlaces, changingProjector, changingPCs);
                        indexOfChangingAuditorium = auditoriums.IndexOf(changingAuditorium);
                        auditoriums[indexOfChangingAuditorium] = updatedAuditorium;

                        Console.Clear();
                        Console.WriteLine("Аудитория успешно отредактирована \nНажмите любую клавишу, чтобы вернуться в меню");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("База данных не создана. Нажмите любую клавишу, чтобы вернуться в меню");
                    Console.ReadKey();
                }
            }

            public static void findAuditoriumswithPlaces(int places)
            {
                Console.Clear();
                bool foundAuditorium = false;
                if (auditoriums != null)
                {
                    for (int i = 0; i < auditoriums.Count; i++)
                    {
                        if (auditoriums[i].places >= places)
                        {
                            Console.WriteLine(getAllInfo(auditoriums[i]));
                            foundAuditorium = true;
                        }
                    }
                    if (foundAuditorium)
                    {
                        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Menu.showIfDidntFind();
                    }
                }
                else
                {
                    Console.WriteLine("База данных не инициализированна. Операция прервана. Нажмите любую клавишу, чтобы вернуться в меню");
                    Console.ReadKey();
                }
            }

            public static void findAuditoriumwithProjector()
            {
                Console.Clear();
                bool foundAuditorium = false;
                if (auditoriums != null)
                {
                    for (int i = 0; i < auditoriums.Count; i++)
                    {
                        if (auditoriums[i].projector == true)
                        {
                            Console.WriteLine(getAllInfo(auditoriums[i]));
                            foundAuditorium = true;
                        }
                    }
                    if (foundAuditorium)
                    {
                        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Menu.showIfDidntFind();
                    }
                }
                else
                {
                    Console.WriteLine("База данных не инициализирована. Операция прервана. Нажмите любую клавишу, чтобы вернуться в меню");
                    Console.ReadKey();
                }
            }

            public static void findAuditoriumwithPCsAndPlaces(int places, int Kompi)
            {
                Console.Clear();
                bool foundAuditorium = false;
                if (auditoriums != null)
                {
                    for (int i = 0; i < auditoriums.Count; i++)
                    {
                        if ((auditoriums[i].places >= places) & (auditoriums[i].Kompi >= Kompi))
                        {
                            Console.WriteLine(getAllInfo(auditoriums[i]));
                            foundAuditorium = true;
                        }
                    }
                    if (foundAuditorium)
                    {
                        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Menu.showIfDidntFind();
                    }
                }
                else
                {
                    Console.WriteLine("База данных не инициализирована. Операция прервана. Нажмите любую клавишу, чтобы вернуться в меню");
                    Console.ReadKey();
                }
            }

            public static void findAuditoriumbyFlat(int flat)
            {
                String currentAuditorium, currentFlat;
                int comparingFlat = -1;
                bool isAuditoriumFound = false;
                for (int i = 0; i < auditoriums.Count; i++)
                {
                    currentFlat = "";
                    currentAuditorium = auditoriums[i].number;
                    for (int j = 0; j < currentAuditorium.Length; j++)
                    {
                        if (Char.IsDigit(currentAuditorium[j]))
                        {
                            currentFlat += currentAuditorium[j];
                        }
                        else
                        {
                            comparingFlat = int.Parse(currentFlat);
                            break;
                        }
                    }
                    if (comparingFlat == flat)
                    {
                        Console.WriteLine(Auditorium.getAllInfo(auditoriums[i]));
                        isAuditoriumFound = true;
                    }
                }
                if (!isAuditoriumFound)
                {
                    Menu.showIfDidntFind();
                }
                else
                {
                    Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            public static void getAllInfoAllAuditoriums()
            {
                bool foundAuditorium = false;
                Console.Clear();
                if (auditoriums != null)
                {
                    for (int i = 0; i < auditoriums.Count(); i++)
                    {
                        Console.WriteLine(getAllInfo(auditoriums[i]));
                        foundAuditorium = true;
                    }
                    if (foundAuditorium)
                    {
                        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("База данных пуста\nНажмите любую клавишу, чтобы вернуться в меню");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("База данных не инициализирована. Операция прервана. Нажмите любую клавишу, чтобы вернуться в меню");
                    Console.ReadKey();
                }
            }

            public void setNumber(Auditorium auditorium, String number)
            {
                this.number = number;
            }

            public void setPlaces(Auditorium auditorium, int places)
            {
                this.places = places;
            }

            public void setProjector(Auditorium auditorium, bool projector)
            {
                this.projector = projector;
            }

            public void setPCs(Auditorium auditorium, int PCs)
            {
                this.Kompi = PCs;
            }

            public String getNumber(Auditorium auditorium)
            {
                return auditorium.number;
            }

            public int getPlaces(Auditorium auditorium)
            {
                return auditorium.places;
            }

            public bool getProjector(Auditorium auditorium)
            {
                return auditorium.projector;
            }

            public int getPCs(Auditorium auditorium)
            {
                return auditorium.Kompi;
            }

            public static String getAllInfo(Auditorium auditorium)
            {
                return "Номер: " + auditorium.number + " Количество посадочных мест: " + auditorium.places + " Наличие проектора: " + auditorium.projector + " Количество компьютеров: " + auditorium.Kompi;
            }

            public static Auditorium findAuditoriumbyNumber(String number)
            {
                bool isAuditoriumFound = false;
                int n = 0;
                for (int i = 0; i < auditoriums.Count; i++)
                {
                    if (auditoriums[i].number == number)
                    {
                        n = i;
                        isAuditoriumFound = true;
                        break;
                    }
                }
                if (isAuditoriumFound)
                {
                    return auditoriums[n];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}