using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRAC4
{
    internal class Manager
    {
        public static bool TryParseNumber(string input, out int result)
        {
            if (int.TryParse(input, out result) && result > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Ошибка: это не число!");
                return false;
            }
        }
    }
}
