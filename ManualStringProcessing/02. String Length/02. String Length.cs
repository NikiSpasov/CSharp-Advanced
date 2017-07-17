using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.String_Length
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            if (text.Length < 20)
            {
                Console.Write(text.Substring(0, text.Length));
                Console.WriteLine(new string('*', 20 - text.Length));
                return;
            }
            string substring = text.Substring(0, 20);
            Console.WriteLine(substring);
        }
    }
}
