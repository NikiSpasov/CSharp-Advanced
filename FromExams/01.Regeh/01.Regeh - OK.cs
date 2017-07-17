using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    using System;

    class Regeh
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            int inputTextLength = inputText.Length;
            string[] input = inputText
                .Split(new []{' ', '\r', '\n', '\t'},
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            StringBuilder finalText = new StringBuilder();
            int finalIndex = 0;           

            Regex wholeGroup = new Regex(@".[^\[]+<([\d]+?)REGEH([\d]+?)>[^\[]+?]");
           // string pattern = @".[^\[]+<([\d]+?)REGEH([\d]+?)>[^\[]+?]";

            foreach (var text in input)
            {
                MatchCollection matches = wholeGroup.Matches(text);
                foreach (Match match in matches)
                {
                    
                    int n = match.Groups.Count;
                    for (int i = 1; i < n; i++)
                    {
                        int index = int.Parse(match.Groups[i].Value);
                        finalIndex += index;
                        while (finalIndex > inputTextLength - 1)
                        {
                            finalIndex -= inputTextLength - 1;
                        }
                        string letter = inputText[finalIndex].ToString();
                        finalText.Append(letter);

                    }
                } 
            }
            Console.WriteLine(finalText.ToString());
        }
    }
}
