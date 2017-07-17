using System;
using System.Text.RegularExpressions;

namespace _06.ValidUsernames
{
    public class ValidUserNames
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"^[\w\d-]{3,16}$";
            Regex myRegex = new Regex(pattern);
            while (text != "END")
            {
                if (myRegex.IsMatch(text))
                {
                    Console.WriteLine("valid");
                    text = Console.ReadLine();
                    continue;
                }
                Console.WriteLine("invalid");
                text = Console.ReadLine();
            }
        }
    }
}
