using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.RecursiveFibonacci
{
    class Program
    {
        private static long[] fibNumbers;
        public static void Main()
        {
            int nthNumber = int.Parse(Console.ReadLine());
            fibNumbers = new long[nthNumber];
            long result = GetFibonaci(nthNumber);
            Console.WriteLine(result);
        }

        private static long GetFibonaci(int nthNumber)
        {
            if (nthNumber <= 2)
            {
                return 1;
            }
            if (fibNumbers[nthNumber - 1] != 0)
            {
                return fibNumbers[nthNumber - 1];
            }
            return fibNumbers[nthNumber -1] = GetFibonaci(nthNumber - 1) + GetFibonaci(nthNumber - 2);
        }
    }
}
