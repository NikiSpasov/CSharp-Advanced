using System.Security.Cryptography.X509Certificates;

namespace _07.PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class PredicateForNames
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            Predicate<string> namesShorterOrEqual = s => s.Length <= length;

            Console.ReadLine()
                .Split(' ')
                .Where(x => namesShorterOrEqual(x))
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
