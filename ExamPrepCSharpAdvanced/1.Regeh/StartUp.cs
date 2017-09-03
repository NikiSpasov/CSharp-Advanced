using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class StartUp
{

    public static void Main()
    {
        List<int> indexes = new List<int>();
        string input = Console.ReadLine();
        int lenght = input.Length;
        StringBuilder sb = new StringBuilder();
        int sumIt = 0;

        Regex regex = new Regex(@"\[[^\[ ]+<([0-9]+)REGEH([0-9]+)>[^\] ]*]");
        var matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            for (int i = 1; i <= 2; i++)
            {
                indexes.Add(int.Parse(match.Groups[i].Value));
            }
        }

        for (int i = 0; i < indexes.Count; i++)
        {
            int numberToAdd = indexes[i] + sumIt;

            while (numberToAdd >= lenght)
            {
                numberToAdd -= lenght - 1;
            }

            sb.Append(input[numberToAdd]);
            sumIt += indexes[i];
        }

        Console.WriteLine(sb.ToString());
    }
}