using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace _02CubicsRube
{
    class Program
    {
        static void Main(string[] args)
        {

            int cubeSide = int.Parse(Console.ReadLine());

            List<long>[,,] rubicCube = new List<long>[cubeSide,cubeSide,cubeSide];

            int totalFreeCells = rubicCube.Length;

            BigInteger result = 0;

           string input = Console.ReadLine();

            while (input != "Analyze")
            {
                long[] dimensionsAndValue = input
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(long.Parse)
                        .ToArray();
                long firstD = dimensionsAndValue[0];
                long secondD = dimensionsAndValue[1];
                long thirdD = dimensionsAndValue[2];
                long particle = dimensionsAndValue[3];

                if (firstD > rubicCube.GetLength(0) - 1
                    || secondD > rubicCube.GetLength(1) - 1
                    || thirdD > rubicCube.GetLength(2) - 1
                    || firstD < 0 
                    || secondD < 0 
                    || thirdD < 0
                    || particle == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                totalFreeCells--;
                result += particle;
                input = Console.ReadLine();

                //rubicCube[firstD, secondD, thirdD] = particle;
            }
            
            Console.WriteLine(result);
            Console.WriteLine(totalFreeCells);
        }
    }
}
