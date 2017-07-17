using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(\d+)([a-zA-Z]+)([^a-zA-Z]+)$";
            Regex regex = new Regex(pattern);
            var input = Console.ReadLine();
            var msg = "";

            while (input != "Over!")
            {
                Match match = regex.Match(input);
                msg = match.Groups[2].Value;
                var after = match.Groups[3].Value;
                StringBuilder sb = new StringBuilder();
                sb.Append(match.Groups[1].Value);
                for (int i = 0; i < after.Length; i++)
                {
                    int num;
                    if (int.TryParse(after[i].ToString(), out num))
                    {
                        sb.Append(num);
                    }
                }

                var indexesInt = Array.ConvertAll(sb.ToString().ToCharArray(), a => (int)char.GetNumericValue(a));
                int length;
                if (int.TryParse(Console.ReadLine(), out length))
                {
                    if (length == msg.Length)
                    {
                        Console.Write($"{msg} == ");
                        foreach (var digit in indexesInt)
                        {
                            if (digit >= msg.Length || digit < 0)
                            {
                                Console.Write(" ");
                            }
                            else
                            {
                                Console.Write($"{msg[digit]}");
                            }
                        }
                        Console.WriteLine();
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}