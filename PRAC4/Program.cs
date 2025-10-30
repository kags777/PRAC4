using System;
using System.Collections;
using System.Collections.Generic;

internal class APP
{
    static void Main()
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
        foreach (string person in selectedMonth1)
            Console.WriteLine(person);
        Console.WriteLine();
        Console.WriteLine("Только летние и зимние месяцы:");
        foreach (string person in selectedMonth2)
            Console.WriteLine(person);
        Console.WriteLine();
        Console.WriteLine("Отсортированные по алфавиту месяцы:");
        foreach (string person in selectedMonth3)
            Console.WriteLine(person);
        Console.WriteLine();
        Console.WriteLine("Месяцы с длиной названия 4 символа и содержащие в названии букву u:");
        foreach (string person in selectedMonth4)
            Console.WriteLine(person);


        ////Методы расширения
        //var selectedMonth2 = month.Where(p => p.Length == n  p == "June" || p == "July" || p == "August" || p == "December" 
        //    || p == "January" || p == "February")
        //                          .OrderBy(p => p) // сортировка по алфавиту
        //                          .Where(p => p.Length == 4 && p.Contains("u"))
        //                          .Select(p => p);


    }
}
