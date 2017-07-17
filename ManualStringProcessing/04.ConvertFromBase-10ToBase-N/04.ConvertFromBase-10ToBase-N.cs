using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConvertFromBase_10ToBase_N
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int baseToConvert = numbers[0];
            int decimalNum = numbers[1];

            string result = Int32ToString(decimalNum, baseToConvert);
            Console.WriteLine(result);
        }
        public static string Int32ToString(int value, int toBase)
        {
            string result = string.Empty;
            do
            {
                result = "0123456789ABCDEF"[value % toBase] + result;
                value /= toBase;
            }
            while (value > 0);

            return result;
        }
    }
}
