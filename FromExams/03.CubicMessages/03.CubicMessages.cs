
namespace _03.CubicMessages
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;


    class CubicMessages
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int messageLength = int.Parse(Console.ReadLine());
            string message = "";
            List<string> messages = new List<string>();

            StringBuilder finalMessage = new StringBuilder();

            Regex validMessage = new Regex(@"^\d+[A-Za-z]+[^A-Za-z]*$");
            Regex messageRegex = new Regex(@"\D+[A-Za-z]+");
            Regex indexes = new Regex(@"\d");


            while (input != "Over!")
            {
                var isMatch = validMessage.IsMatch(input);

                message = messageRegex.Match(input).ToString();

                if (!isMatch || message.Length != messageLength)
                {
                    input = Console.ReadLine();
                    messageLength = int.Parse(Console.ReadLine());
                    continue;
                }

                MatchCollection indexesCollection = indexes.Matches(input);

                foreach (var index in indexesCollection)
                {
                    if (int.Parse(index.ToString()) > message.Length -1 || int.Parse(index.ToString()) < 0)
                    {
                        finalMessage.Append(" ");
                        continue;
                    }
                    finalMessage.Append(message[int.Parse(index.ToString())]);
                }

                messages.Add($"{message} == {finalMessage.ToString()}");

                finalMessage.Clear();

                input = Console.ReadLine();
                if (input == "Over!")
                {
                    break;
                }
                messageLength = int.Parse(Console.ReadLine());
            }
            foreach (var mes in messages)
            {
            Console.WriteLine($"{mes}");

            }
        }
    }
}
