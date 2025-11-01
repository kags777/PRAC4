using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PRAC4
{
    internal class Date
    {
        private int Day { get; set; }
        private int Month { get; set; }
        private int Year { get; set; }

        public Date(int day, int month, int year)
        {
            if (year < 1 || year > 3000)
                throw new ArgumentOutOfRangeException(nameof(year), "Год должен быть в диапазоне 1–3000");

            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), "Месяц должен быть 1–12");

            if (day < 1 || day > DateTime.DaysInMonth(year, month))
                throw new ArgumentOutOfRangeException(nameof(day), "В этом месяце нет такого дня");

            Day = day;
            Month = month;
            Year = year;
        }
        public override string ToString()
        {
            return $"{Day:00}.{Month:00}.{Year}";
        }

        public static List<Date> AddData()
        {

            List<Date> dates = new List<Date>();
            Random rand = new Random();

            for (int i = 0; i < 20; i++)
            {
                int year = rand.Next(1, 3001);
                int month = rand.Next(1, 13);
                int day = rand.Next(1, 29); // чтобы не ловить 29/30/31-й в коротких месяцах

                dates.Add(new Date(day, month, year));

            }
            foreach (Date date in dates)
            {
                Console.WriteLine(date);
            }
            return dates;
        }

        //операторы запросов даты
        public static void RequestDate(List<Date> dates)
        {
            int dateYear = 2020;
            int dateMonth = 6;
            int dateDay = 1;

            int startYear = 2000;
            int endYear = 2020;

            var selectedDate1 = from d in dates
                                where d.Year == dateYear
                                select d;
            Console.WriteLine("Список дат для заданного года:");
            foreach (var dateSel in selectedDate1)
                Console.WriteLine(dateSel);
            Console.WriteLine();


            var selectedDate2 = from d in dates
                                where d.Month == dateMonth
                                select d;
            Console.WriteLine("Список дат для заданного месяца:");
            foreach (var dateSel in selectedDate2)
                Console.WriteLine(dateSel);
            Console.WriteLine();


            var selectedDate3 = (from d in dates
                                 where d.Year >= startYear && d.Year <= endYear
                                 select d).Count();
            Console.WriteLine($"Количество дат в диапазоне от 2000 до 2025 года : {selectedDate3}");
            Console.WriteLine();

            var maxDate = (from d in dates
                           orderby d.Year descending, d.Month descending, d.Day descending
                           select d).FirstOrDefault();

            Console.WriteLine($"Максимальная дата: {maxDate}");
            Console.WriteLine();

            var selectedDate5 = (from d in dates
                                 where d.Day == dateDay
                                 select d).FirstOrDefault();
            Console.WriteLine($"Первая дата для заданного дня: {selectedDate5}");
            Console.WriteLine();

            int Choice; // для выбора действия
            Manager manager = new Manager();

            do
            {
                do
                {
                    Console.WriteLine("\nВыберите, желаемую операцию:\n");
                    Console.WriteLine("1. Отсортировать даты по возрастанию\n");
                    Console.WriteLine("2. Отсортировать даты по убыванию\n");
                    Console.WriteLine("3. Выйти\n");
                    string choice = Console.ReadLine();
                    Manager.TryParseNumber(choice, out Choice);

                } while (false);

                switch (Choice)
                {
                    case 1:
                        var selectedDate6 = from d in dates
                                            orderby d.Year descending, d.Month descending, d.Day descending
                                            select d;

                        Console.WriteLine($"Даты по возрастанию: {selectedDate6}");
                        Console.WriteLine();

                        break;
                    case 2:
                        var selectedDate7 = from d in dates
                                            orderby d.Year ascending, d.Month ascending, d.Day ascending
                                            select d;
                        Console.WriteLine($"Даты по убыванию: {selectedDate7}");
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine("До свидания!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice.\n");
                        break;
                }
            } while (Choice != 3);
        }

        public static void ExpansionDate(List<Date> dates)
        {
            int dateYear = 2020;
            int dateMonth = 6;
            int dateDay = 1;

            int startYear = 2000;
            int endYear = 2020;

            //Методы расширения
            var selectedDate = dates.Where(d => d.Year == dateYear);
            Console.WriteLine("Список дат для заданного года:");
            foreach (var dateSel in selectedDate)
                Console.WriteLine(dateSel);
            Console.WriteLine();

            var selectedDate8 = dates.Where(d => d.Month == dateMonth);
            Console.WriteLine("Список дат для заданного месяца:");
            foreach (var dateSel in selectedDate8)
                Console.WriteLine(dateSel);
            Console.WriteLine();

            var selectedDate9 = dates.Where(d => d.Year > startYear && d.Year < endYear);
            Console.WriteLine("Количество дат в определенном диапазоне:");
            Console.WriteLine(selectedDate9.Count());
            Console.WriteLine();

            var selectedDate10 = dates.OrderByDescending(d => d.Year)
                          .ThenByDescending(d => d.Month)
                          .ThenByDescending(d => d.Day)
                          .FirstOrDefault();
            Console.WriteLine("Максимальная дата:");
            Console.WriteLine(selectedDate10);
            Console.WriteLine();

            var selectedDate11 = dates.Where(d => d.Day == dateDay)
              .FirstOrDefault();
            Console.WriteLine("Первая дата для заданного дня:");
            Console.WriteLine(selectedDate11);
            Console.WriteLine();

            int Choice; // для выбора действия
            Manager manager = new Manager();

            do
            {
                do
                {
                    Console.WriteLine("\nВыберите, желаемую операцию:\n");
                    Console.WriteLine("1. Отсортировать даты по возрастанию\n");
                    Console.WriteLine("2. Отсортировать даты по убыванию\n");
                    Console.WriteLine("3. Выйти\n");
                    string choice = Console.ReadLine();
                    Manager.TryParseNumber(choice, out Choice);

                } while (false);

                switch (Choice)
                {
                    case 1:
                        var selectedDate12 = dates
                            .OrderBy(d => d.Year)
                            .ThenBy(d => d.Month)
                            .ThenBy(d => d.Day);
                        Console.WriteLine("Список дат по возрастанию:");
                        foreach (var dateSel in selectedDate12)
                            Console.WriteLine(dateSel);
                        Console.WriteLine();
                        break;

                    case 2:
                        var selectedDate13 = dates
                            .OrderByDescending(d => d.Year)
                            .ThenByDescending(d => d.Month)
                            .ThenByDescending(d => d.Day);
                        Console.WriteLine("Список дат по убыванию:");
                        foreach (var dateSel in selectedDate13)
                            Console.WriteLine(dateSel);
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.WriteLine("До свидания!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice.\n");
                        break;
                }
            } while (Choice != 3);
        }
    }
}



