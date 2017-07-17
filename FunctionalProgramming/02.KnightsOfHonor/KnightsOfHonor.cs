namespace _02.KnightsOfHonor
{
    using System;
    using System.Linq;
    class KnightsOfHonor
    {
        static void Main()
        {
            Action<string, string> appendWord = (x, y) => Console.WriteLine(x + " " + y);

            string sir = "Sir";

            Console.ReadLine()
                .Split(' ')
                .ToList()
                .ForEach(n => appendWord(sir, n));
        }
    }
}
