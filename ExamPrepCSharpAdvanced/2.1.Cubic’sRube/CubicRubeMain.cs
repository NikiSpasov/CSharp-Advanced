using System;
using System.Linq;

public class CubicRubeMain
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int totalSum = 0;

        int totalCellsUnchangedCount = 0;
        
        int[,,] cube = new int[n,n,n];

        string input;

        while ((input=Console.ReadLine()) != "Analyze")
        {
            int[] tokens = input.Split()
                .Select(int.Parse)
                .ToArray();

            int x = tokens[0];
            int y = tokens[1];
            int z = tokens[2];
            int particles = tokens[3];

            if (x < n  && y < n && z < n)
            {
                if (x >= 0 && y >= 0 && z >= 0)
                {
                    cube[x, y, z] = particles;
                }             
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    if (cube[i, j, k] == 0)
                    {
                        totalCellsUnchangedCount++;
                        continue;
                    }

                    totalSum += cube[i, j, k];
                }
            }          
        }

        Console.WriteLine(totalSum);
        Console.WriteLine(totalCellsUnchangedCount);
    }
}
