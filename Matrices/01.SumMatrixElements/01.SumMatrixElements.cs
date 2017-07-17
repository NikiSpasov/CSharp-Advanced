using System.Runtime.InteropServices;

namespace _01.SumMatrixElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class SumMatrixElem
    {
        static void Main()
        {
            string[] rowsAndCols = Console.ReadLine()
                .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            int rows = int.Parse(rowsAndCols[0]);
            int cols = int.Parse(rowsAndCols[1]);
            int[,] myMatrix = new int[rows, cols];


            for (int i = 0; i < rows; i++)
            {
                 var inputNumbers = Console.ReadLine()
                    .Split(new []{' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < cols; j++)
                {
                    myMatrix[i,j] = inputNumbers[j];
                }
            }
            int sum = 0;
            foreach (var element in myMatrix)
            {
                sum += element;
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
