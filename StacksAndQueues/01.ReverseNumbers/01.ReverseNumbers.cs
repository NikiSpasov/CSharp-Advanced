namespace _01.ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Trim()
                .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                numbers.Push(input[i]);
            }
            
            Console.WriteLine(String.Join(" ", numbers));              
        }
    }
}
