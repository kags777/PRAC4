using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PRAC4
{
    internal class Months
    {
        public static void Request() 
        { 
        
        string[] month = { "January","February","March","April","May","June", "July","August",
            "September","October","November","December"};
        int n = 5;//  количество букв в названии месяца

        //операторы запросов
        var selectedMonth1 = from m in month
                             where m.Length == n
                             select m;

        var selectedMonth2 = from m in month
                             where m == "June" || m == "July" || m == "August" || m == "December" || m == "January" || m == "February"
                             select m;

        var selectedMonth3 = from m in month
                             orderby m // сортировка по алфавиту
                             select m;

        var selectedMonth4 = from m in month
                             where m.Length == 4 && m.Contains("u")
                             select m;

        Console.WriteLine("Месяцы, с длиной строки названия пять символов:");
        foreach (string monthSel in selectedMonth1)
            Console.WriteLine(monthSel);
        Console.WriteLine();
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

        public static void Expansion()
        {
            string[] month = { "January","February","March","April","May","June", "July","August",
            "September","October","November","December"};
            //Методы расширения
            var selectedMonth = month.Where(m => m.Length == 5);
            Console.WriteLine("Месяцы, с длиной строки названия пять символов:");
            foreach (string monthSel in selectedMonth)
                Console.WriteLine(monthSel);
            Console.WriteLine();

            string[] summerWinter = { "June", "July", "August", "December", "January", "February" };
            var selectedMonth6 = month.Where(m => summerWinter.Contains(m));
            Console.WriteLine("Только летние и зимние месяцы:");
            foreach (string monthSel in selectedMonth6)
                Console.WriteLine(monthSel);
            Console.WriteLine();

            var selectedMonth7 = month.OrderBy(p => p); // сортировка по алфавиту
            Console.WriteLine("Отсортированные по алфавиту месяцы:");
            foreach (string monthSel in selectedMonth7)
                Console.WriteLine(monthSel);
            Console.WriteLine();

            var selectedMonth8 = month.Where(p => p.Length == 4 && p.Contains("u"));
            Console.WriteLine("Месяцы с длиной названия 4 символа и содержащие в названии букву u:");
            foreach (string monthSel in selectedMonth8)
                Console.WriteLine(monthSel);
        }
    }
}
