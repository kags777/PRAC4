using PRAC4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

internal class APP
{
    static void Main()
    {
        int Choice; // для выбора действия
        Manager manager = new Manager();

        do
        {
            do
            {
                Console.WriteLine("\nВыберите, желаемую операцию:\n");
                Console.WriteLine("1. Отсортировать месяцы с помощью операторов запросов\n");
                Console.WriteLine("2. Отсортировать месяцы с помощью методов расширения\n");
                Console.WriteLine("3.Создать cписок дат.\n");
                Console.WriteLine("4. Выйти\n");
                string choice = Console.ReadLine();
                Manager.TryParseNumber(choice, out Choice);

            } while (false);

            switch (Choice)
            {
                case 1:
                    Months.Request();
                    break;
                case 2:
                    Months.Expansion();
                    break;
                case 3:
                    Date.AddData();
                    break;
                case 4:
                    Console.WriteLine("До свидания!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.\n");
                    break;
            }
        } while (Choice != 4);
    }
}
