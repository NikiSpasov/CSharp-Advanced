namespace _00.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        static void Main(string[] args)
        {
            string input = "abcd";
            string ui = input.Remove(0, 2);
            Console.WriteLine(ui);
        }
    }
}
