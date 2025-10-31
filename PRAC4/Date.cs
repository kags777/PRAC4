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

        //операторы запросов
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

            var selectedDate4 = (from d in dates
                                 where d.Day == dateDay
                                 select d).FirstOrDefault();
            Console.WriteLine($"Первая дата для заданного дня: {selectedDate4}");
            Console.WriteLine();


            var selectedDate5 = (from d in dates
                                where d.Day == dateDay
                                select d).FirstOrDefault();
            Console.WriteLine($"Первая дата для заданного дня: {selectedDate5}");
            Console.WriteLine();

            var selectedMonth2 = from m in month
                                 where m == "June" || m == "July" || m == "August" || m == "December" || m == "January" || m == "February"
                                 select m;

            var selectedMonth3 = from m in month
                                 orderby m // сортировка по алфавиту
                                 select m;

            var selectedMonth4 = from m in month
                                 where m.Length == 4 && m.Contains("u")
                                 select m;

            
            Console.WriteLine("Только летние и зимние месяцы:");
            foreach (string monthSel in selectedMonth2)
                Console.WriteLine(monthSel);
            Console.WriteLine();
            Console.WriteLine("Отсортированные по алфавиту месяцы:");
            foreach (string monthSel in selectedMonth3)
                Console.WriteLine(monthSel);
            Console.WriteLine();
            Console.WriteLine("Месяцы с длиной названия 4 символа и содержащие в названии букву u:");
            foreach (string monthSel in selectedMonth4)
                Console.WriteLine(monthSel);
            Console.WriteLine();
        }
    }
}



