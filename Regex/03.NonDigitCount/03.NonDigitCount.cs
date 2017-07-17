namespace _03.NonDigitCount
{
    using System;
    using System.Text.RegularExpressions;
    class NonDigitCount
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string pattern = $"[\\D]";
            Regex myRegex = new Regex(pattern);
            int nonDigitCount = myRegex.Matches(text).Count;
            Console.WriteLine($"Non-digits: {nonDigitCount}");
        }
    }
}
