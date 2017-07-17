namespace _04.ExtractIntegersNumbers
{
    using System;
    using System.Text.RegularExpressions;
    public class ExtractTags
    {  
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = $"[\\d]+";
            Regex myRegex = new Regex(pattern);
            MatchCollection matches = myRegex.Matches(text);
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
