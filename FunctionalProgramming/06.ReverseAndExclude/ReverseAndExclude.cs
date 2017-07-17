
namespace _06.ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ReverseAndExclude
    {
        static void Main()
        {

            List<int> nums = Console.ReadLine()
                .Split(' ')
                .Select(n => int.Parse(n))
                .ToList();

            var divider = int.Parse(Console.ReadLine());


            var result = nums
                .Where(x => x % divider != 0)
                .Reverse()
                .ToList(); 
                

            foreach (var num in result)
            {
                Print(num);
            }

        }

        public static void Print(int num)
        {
            Console.Write($"{num} ");
        }
    }
}
