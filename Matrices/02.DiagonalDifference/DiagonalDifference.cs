namespace _02.DiagonalDifference
{
    using System;
    using System.Linq;

    class DiagonalDiff
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int firstDiagonal = 0;
            int secondDiagonal = 0;

            int[,] myMatrix = new int[n, n]; 

            for (int rows = 0; rows < myMatrix.GetLength(0); rows++)
            {
                int[] numbers = Console.ReadLine()
                    .Trim()
                    .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int cols = 0; cols < myMatrix.GetLength(1); cols++)
                {
                    myMatrix[rows, cols] = numbers[cols];
                }
                firstDiagonal += myMatrix[rows, rows];
                secondDiagonal += myMatrix[rows, n - 1 - rows];
            }
            Console.WriteLine(Math.Abs(firstDiagonal - secondDiagonal));
        }
    }
}
