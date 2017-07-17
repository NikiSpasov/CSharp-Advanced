using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GroupNumbersWithLists
{
    class GroupWithList
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            List<List<int>> remainders = new List<List<int>>();

            for (int i = 0; i < 3; i++)
            {
                remainders.Add(new List<int>());
            }

            for (int j = 0; j < inputNumbers.Length; j++)
            {
                int currentNum = inputNumbers[j]; 
                int remainder = currentNum % 3;
                if (remainder < 0)
                {
                    remainder *= -1;
                }
                remainders[remainder].Add(currentNum);
            }

            foreach (var list in remainders)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }
    }
}
