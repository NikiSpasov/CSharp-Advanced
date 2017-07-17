namespace _03.GroupNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class GroupNumbers
    {
        static void Main()
        {
            int[] inputNumbers = Console.ReadLine()
                .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] myMatrix = new int[3][];
            int firstRowIndex = 0;
            int secondRowIndex = 0;
            int thirdRowIndex = 0;


            foreach (var number in inputNumbers)
            {
                if (number % 3 == 0)
                {
                    firstRowIndex++;
                }
                else if (number % 3 == 1 || number % 3 == -1)
                {
                    secondRowIndex++;
                }
                else
                {
                    thirdRowIndex++;
                }
            }

            myMatrix[0] = new int[firstRowIndex];
            myMatrix[1] = new int[secondRowIndex];
            myMatrix[2] = new int[thirdRowIndex];

            int firstCnt = 0;
            int secondCnt = 0;
            int thirdCnt = 0;

            foreach (var number in inputNumbers)
            {
                if (number % 3 == 0)
                {
                    myMatrix[0][firstCnt] = number;
                    firstCnt++;
                }
                else if (number % 3 == 1 || number % 3 == -1)
                {
                    myMatrix[1][secondCnt] = number;
                    secondCnt++;
                }
                else if (number % 3 == 2 || number % 3 == -2)
                {
                    myMatrix[2][thirdCnt] = number;
                    thirdCnt++;
                }
            }

           foreach (var array in myMatrix)
            {
                Console.WriteLine(string.Join(" ", array));
            }

        }
    }
}
