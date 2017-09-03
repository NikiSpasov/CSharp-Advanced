using System;
using System.Linq;

public class JediGalaxy
{
    public static void Main()
    {
        int cnt = 0;
        int ivoSum = 0;
        int ivoNum = 0;
        int evilNum = 0;

        int[] dimensions = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();
        int[,] array = new int[dimensions[0],dimensions[1]];

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = cnt;
                cnt++;
            }
        }

        int colDimension = array.GetLength(1);

        string input;

        while ((input = Console.ReadLine()) != "Let the Force be with you")
        {
            int[] ivoCoordinate = input
                .Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int ivoRow = ivoCoordinate[0] - 1;
            int ivoCol = ivoCoordinate[1] + 1;// -?

            int[] evilCooridnates = Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int evilRow = evilCooridnates[0] - 1;
            int evilCol = evilCooridnates[1] - 1;

            while (ivoRow > -1 && evilRow > -1 &&  evilCol > -1 && ivoCol < colDimension)
            {
                ivoNum = array[ivoRow, ivoCol];
                evilNum = array[evilRow, evilCol];

                ivoRow--;
                ivoCol++;

                evilRow--;
                evilCol--;

                if (ivoNum != evilNum)
                {
                    ivoSum += ivoNum;
                }
            }
        }
       
        Console.WriteLine(ivoSum);
    }
}