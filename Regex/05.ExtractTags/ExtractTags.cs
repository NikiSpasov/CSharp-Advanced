namespace _05.ExtractTags
{
    using System;
    using System.Text.RegularExpressions;
    public class ExtractTags
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"<.*?>";
            Regex myRegex = new Regex(pattern);
            while (text != "END")
            {
                MatchCollection matches = myRegex.Matches(text);
                
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
                text = Console.ReadLine();

            }
        }
    }
}
