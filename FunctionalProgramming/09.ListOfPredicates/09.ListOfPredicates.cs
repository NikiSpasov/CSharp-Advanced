using System.CodeDom;

namespace _09.ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class ListOfPredicates
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine()); 

            List<int> dividers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            
                        
           Predicate<int> isDividible;


            for (int i = 1; i <= num; i++)
            {
                if (withZeroRemain(i, dividers))
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }

        private static bool withZeroRemain(int num, List<int> dividers)
        {
            foreach (var divider in dividers)
            {
                if (num % divider != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
