using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvenOrOdds
{
    class FindEvenOrOdds
    {
        static void Main()
        {
           
          var range = Console.ReadLine().Split(' ').Select(n => long.Parse(n)).ToArray();
            var from = range[0];
            var to = range[1];
            var oddOrEven = Console.ReadLine();
            long num = from;

            switch (oddOrEven)
            {
                case "odd":
                    while (num <= to )
                    {
                        if (num % 2 != 0)
                        {
                            Console.WriteLine(num);
                        }
                        num++;
                    } 
                    break;
                case "even":
                    while (num <= to)
                    {
                        if (num % 2 == 0)
                        {
                            Console.WriteLine(num);
                        }
                        num++;
                    }
                    break;

            }
 
        }
    }
}
