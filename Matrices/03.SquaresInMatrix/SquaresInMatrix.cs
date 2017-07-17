namespace _03.SquaresInMatrix
{
    using System;
    using System.Linq;

    class SquaresInMatrix
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = input[0];
            int cols = input[1];

            string[,] myMatrix = new string[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                string[] letters = Console.ReadLine()
                    .Trim()
                    .Split(new []{' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    myMatrix[row, col] = letters[col];
                }
            }
            int squares = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (myMatrix[row, col] == myMatrix[row, col + 1]
                        && myMatrix[row + 1, col] == myMatrix[row + 1, col + 1])
                    {
                        squares++;
                    }
                }
            }            
            Console.WriteLine(squares);
        }
    }
}
