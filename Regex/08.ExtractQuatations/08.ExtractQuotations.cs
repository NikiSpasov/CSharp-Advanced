
namespace _08.ExtractQuatations
{
    using System;
    using System.Text.RegularExpressions;

    class ExtractQuotations
    {
        static void Main()
        {
            string text = Console.ReadLine();
            Regex myRegex = new Regex("(\"|')(.*?)\\1");


            MatchCollection quotes = myRegex.Matches(text);
            foreach (Match match in quotes)
            {
                Console.WriteLine(match.Groups[2].Value);
            }

        }
    }
}
