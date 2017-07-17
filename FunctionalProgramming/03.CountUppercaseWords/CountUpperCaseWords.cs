namespace _03.CountUppercaseWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class UpperCaseWordsCount
    {
        static void Main()
        {
            Func<string, bool> isCapital = n => char.IsUpper(n[0]);

            Console.ReadLine()
                .Split(' ')
                .Where(isCapital)//забележи как директно се прилага
                //.OrderBy(n => n) if you want Alphabeticly
                .ToList()
                .ForEach(n => Console.WriteLine(n));

        }
    }
}
