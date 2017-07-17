using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromesOfLetters
{
    class PalindromesOfLetters
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Trim()
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = input[0];
            int cols = input[1];

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{alphabet[row]}{alphabet[row + col]}{alphabet[row]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
