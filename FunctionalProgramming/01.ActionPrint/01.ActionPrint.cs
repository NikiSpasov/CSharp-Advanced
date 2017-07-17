using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ActionPrint
{
    class ActionPrint
    {
        static void Main()
        {
            Action<string> printOnNewLine = n => Console.WriteLine(n);

            Console.ReadLine().Split(' ')
                .ToList()
                .ForEach(printOnNewLine);
        }
    }
}
