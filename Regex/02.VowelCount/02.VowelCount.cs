namespace _02.VowelCount
{
    using System;
    using System.Text.RegularExpressions;
    public class VowelCount
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = $"[AEOIUYeyuioa]";
            Regex vowels = new Regex(pattern);
            int vowelsCount = vowels.Matches(text).Count;
            Console.WriteLine($"Vowels: {vowelsCount}");
        }
    }
}
