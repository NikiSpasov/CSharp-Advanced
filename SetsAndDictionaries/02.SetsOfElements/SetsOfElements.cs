

namespace _02.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class SetsOfElements
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int lengthFirstSet = input[0];
            int lengthSecondSet = input[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();


            for (int i = 0; i < lengthFirstSet + lengthSecondSet; i++)
            {
                int n = int.Parse(Console.ReadLine());
          
                if (i < lengthFirstSet)
                {
                    firstSet.Add(n);
                    continue;
                }
                secondSet.Add(n);
            }

            firstSet.IntersectWith(secondSet);
            foreach (var number in firstSet)
            {
                Console.WriteLine(number);
            }
        }
    }
}
