namespace _03.CustomMinFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class CustomMinFunc
    {
        static void Main()
        {
            Func<List<int>, int> findSmallest = n =>
            n.Min();

            Console.WriteLine(findSmallest  
                (
                Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList()
               ));
        }
    }
}
