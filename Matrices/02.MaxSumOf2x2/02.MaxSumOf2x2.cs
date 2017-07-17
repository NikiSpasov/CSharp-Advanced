namespace _02.MaxSumOf2x2
{
    using System;
    using System.Linq;

    class MaxSumOf2x2
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = input[0];
            int cols = input[1];

            int bestSum = int.MinValue;
            int sum = 0;

            int[,] matrix = new int[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowOfNumbers = Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowOfNumbers[col];
                }
            }
            int beginCol = 0;
            int beginRow = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] +
                          matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        beginRow = row;
                        beginCol = col;
       
                    }
                }
            }
            Console.WriteLine(matrix[beginRow, beginCol] + " " + matrix[beginRow, beginCol + 1]);
            Console.WriteLine(matrix[beginRow + 1, beginCol] + " " + matrix[beginRow + 1, beginCol + 1]);
            Console.WriteLine(bestSum);

        }
    }
}
