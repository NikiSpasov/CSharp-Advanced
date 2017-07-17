using System.Security.Cryptography.X509Certificates;

namespace _08.CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class CustomComparator
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .OrderBy(x => x % 2 != 0)
                .ThenBy(x => x % 2 == 0)
                .ThenBy(x => x)
                .ToList();

            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
}
