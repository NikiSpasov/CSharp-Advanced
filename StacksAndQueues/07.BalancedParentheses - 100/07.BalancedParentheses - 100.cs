using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace _07.BalancedParentheses
{
    class Program
    {
        static void Main()
        {
            char[] input = Console.ReadLine()
                .Trim()
                .ToCharArray();

            char[] openingParentheses = new char[] {'(', '{', '['};

            Stack<char> parentheses = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (openingParentheses.Contains(input[i]))
                {
                    parentheses.Push(input[i]);
                }
                else
                {
                    if (parentheses.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    switch (input[i])
                    {
                        case ')':
                            if (parentheses.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case '}':
                            if (parentheses.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ']':
                            if (parentheses.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
