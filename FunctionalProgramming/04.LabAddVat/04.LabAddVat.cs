using System.Runtime.InteropServices;

namespace _04.LabAddVat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class AddVat
    {
        static void Main()
        {
            Func<double, double> withVat = n => n * 1.2;
            Console.ReadLine().Split(new string[] { ", " },
                 StringSplitOptions.RemoveEmptyEntries)
                .Select(n => double.Parse(n))
                .ToList()
                .ForEach(n => Console.WriteLine($"{withVat(n):0.00}"));


            //ИЛИ:

            Console.ReadLine()
                .Split(new string[] { ", " },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:n2}"));
        }
    }
}
