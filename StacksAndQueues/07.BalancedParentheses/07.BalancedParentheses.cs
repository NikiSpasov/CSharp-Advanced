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

            Queue<char> firstHalf = new Queue<char>();
            Queue<char> secondHalf = new Queue<char>();

            for (int i = 0; i < input.Length / 2; i++)
            {
                firstHalf.Enqueue(input[i]);
            }
            for (int i = input.Length; i > input.Length / 2; i--)
            {
                secondHalf.Enqueue(input[i - 1]);
            }

            for (int i = 0; i < input.Length / 2; i++)
            {
                int firstChar = firstHalf.Dequeue();
                int secondChar = secondHalf.Dequeue();             

                if (firstChar == '{' && secondChar == '}'
                    || firstChar == '(' && secondChar == ')'
                    || firstChar == '[' && secondChar == ']')
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
