using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class JediCodeX
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<string> input = new List<string>();

        List<string> jedais = new List<string>();
        List<string> messages = new List<string>();


        for (int i = 0; i < n; i++)
        {
            input.Add(Console.ReadLine());
        }

        string prePattern = Console.ReadLine();
        string prePatternSecond = Console.ReadLine();

        string wholeNamePattern = prePattern + @"[a-zA-Z]+";
        string wholeMessagePattern = prePatternSecond + @"[a-zA-Z]+";

        Regex namePattern = new Regex(wholeNamePattern);
        Regex messagePattern = new Regex(wholeMessagePattern);

        Regex nameOnly = new Regex(@"[a-zA-Z]" + "{" + prePattern.Length + "}");
        Regex messageOnly = new Regex(@"[a-zA-Z\d]" + "{" + prePatternSecond.Length + "}"); //??

        foreach (var inputLine in input)
        {
            var nameWithPrefix = namePattern.Matches(inputLine);
            var messageWithPrefix = messagePattern.Matches(inputLine);

            foreach (Match mach in nameWithPrefix)
            {
                if (mach.Value != null && mach.Value != "")
                {
                    jedais.Add(nameOnly.Match(mach.Value).Value);
                }

            }

            foreach (Match match in messageWithPrefix)
            {
                if (match.Value != null && match.Value != "")
                {
                    messages.Add(messageOnly.Match(match.Value).Value);
                }
            }

        }

        int[] indexes = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        int cnt = 0;

        for(int i = 0; i < jedais.Count; i++)
        {
            if (!(indexes[i] > messages.Count) && indexes[i] > -1)
            {
                Console.WriteLine(jedais[cnt] + " - " + messages[indexes[i] - 1]);
                cnt++;
            }
        }
    }
}