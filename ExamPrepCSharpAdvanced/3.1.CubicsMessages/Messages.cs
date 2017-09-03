using System;
using System.Text;
using System.Text.RegularExpressions;

public class Messages
{
    public static void Main()
    {
        string input;

        while ((input = Console.ReadLine()) != "Over!")
        {
            int messageLength = int.Parse(Console.ReadLine());

            Regex wholeMatch = new Regex(@"^[\d]+[A-Z|a-z]+[^A-Z|a-z]*$");

            Regex textMatch = new Regex(@"[A-Z|a-z]+");

            Regex everyNumMatch = new Regex(@"[\d]");

            if (wholeMatch.IsMatch(input))
            {
                var textFromInput = textMatch.Match(input).Value;

                if (textFromInput.Length == messageLength)
                {
                    StringBuilder sb = new StringBuilder();
                    var numCollection = everyNumMatch.Matches(input);

                    foreach (Match num in numCollection)
                    {
                        int index = int.Parse(num.Value);
                        if (index > -1 && index < textFromInput.Length)
                        {
                            sb.Append(textFromInput[index]);
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }

                    Console.WriteLine($"{textFromInput.Trim()} == {sb.ToString().Trim()}");
                }
            }
        }
    }
}

