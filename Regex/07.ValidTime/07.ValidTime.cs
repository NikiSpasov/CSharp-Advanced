

namespace _07.ValidTime
{
    using System;
    using System.Text.RegularExpressions;
    public class ValidTime
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"([01][0-9]):([0-5][0-9]):([0-5][0-9]) [AP]M";
            Regex myRegex = new Regex(pattern);
            while (text != "END")
            {
                Match match = myRegex.Match(text);
                if (match.Success)
                {
                    Console.WriteLine(IsValidTime(match) ? "valid" : "invalid");
                    text = Console.ReadLine();
                    continue;
                }
                Console.WriteLine("invalid");
                
                text = Console.ReadLine();
            }
        }

        public static bool IsValidTime(Match isValid)
        {
            int hours = int.Parse(isValid.Groups[1].Value);
            int minutes = int.Parse(isValid.Groups[2].Value);
            int seconds = int.Parse(isValid.Groups[3].Value);
            if (hours < 12)
            {
                if (minutes < 60)
                {
                    if (seconds < 60)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
