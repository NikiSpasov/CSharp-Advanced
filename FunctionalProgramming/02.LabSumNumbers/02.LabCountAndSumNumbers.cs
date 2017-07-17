using System.Runtime.Remoting.Messaging;

namespace _02.LabSumNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class CountAndSum
    {
        public static void Main()
        {
            var numbers = Console.ReadLine();

            Func<string, int> parser = n => int.Parse(n);
            Func<List<int>, int> countNumsInList = n => n.Count;

            int count = countNumsInList(
                numbers.Split(new string[] {", "},
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(parser)
                    .ToList());

            Console.WriteLine(count);

            Console.WriteLine(
                numbers.Split(new string[] { ", " },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(parser)
                    .Sum());
            
        }
    }
}
