using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _05.LabConcatenate_Strings
{
    class ConcatStrings
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder myStringBuilder = new StringBuilder();

            for (int i = 0; i <= n; i++)
            {
                myStringBuilder.Append(Console.ReadLine() + " ");
            }
            Console.WriteLine(myStringBuilder.ToString());

        }

    }
}
