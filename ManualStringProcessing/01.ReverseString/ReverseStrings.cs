using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseString
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine().ToCharArray();
            Array.Reverse(text);
            var reversed = new string(text);
            Console.WriteLine(reversed);
        }
    }
}
