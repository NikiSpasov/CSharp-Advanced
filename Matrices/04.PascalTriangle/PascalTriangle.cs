using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PascalTriangle
{
    class PascalTriangle
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            long[][] triangle = new long[number][];

            triangle[0] = new long [1];
            triangle[0][0] = 1;

            for (int row = 1; row < number; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;

                for (int i = 1; i <= row - 1; i++)
                {
                    triangle[row][i] = triangle[row - 1][i - 1] + triangle[row - 1][i];
                }

                triangle[row][row] = 1;
            }

            int whereToStart = triangle[number - 1].Length - 1;

            foreach (var arr in triangle)
            {
                Console.Write(new string(' ', whereToStart));
                Console.WriteLine(string.Join(" ", arr));
                whereToStart--;
            }
        }
    }
}
