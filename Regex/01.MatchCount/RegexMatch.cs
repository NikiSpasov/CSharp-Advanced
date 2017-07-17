namespace _01.MatchCount
{
    using System;
    using System.Text.RegularExpressions;
    public class RegexMatchCount
    {
        public static void Main()
        {
            Regex myRegex = new Regex(Console.ReadLine());
            string textToSeacheIn = Console.ReadLine();
            int matches = myRegex.Matches(textToSeacheIn).Count;
            Console.WriteLine(matches);
        }
    }
}
