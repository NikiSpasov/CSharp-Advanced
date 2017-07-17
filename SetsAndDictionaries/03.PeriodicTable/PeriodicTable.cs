
using System.Runtime.ExceptionServices;

namespace _03.PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class PeriodicTable
    {
        static void Main()
        {
            SortedSet<string> chemicals = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var current = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < current.Length; j++)
                {
                    chemicals.Add(current[j]);
                }
            }
            foreach (var chemical in chemicals)
            {
                Console.Write($"{chemical} ");
            }
        }
    }
}
