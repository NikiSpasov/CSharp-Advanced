namespace _05.RubixMatrix
{
    using System;
    using System.Linq;

    class RubixMatrix
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = input[0];
            int cols = input[1];

            int cnt = 1;

            int[,] myMatrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    myMatrix[row, col] = cnt;
                    cnt++;
                }
            }

            int comToExecute = int.Parse(Console.ReadLine());

            for (int i = 0; i < comToExecute; i++)
            {
                string[] commandAndRounds = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandAndRounds[1];
                int movesToPerform = int.Parse(commandAndRounds[2]);

                int colToMove = 0;
                int rowToMove = 0;

                if (command == "up" || command == "down")
                {
                    colToMove = int.Parse(commandAndRounds[0]);
                }
                else
                {
                    rowToMove = int.Parse(commandAndRounds[0]);
                }

                switch (command)
                {
                    case "up":
                        for (int j = 0; j < movesToPerform; j++)
                        {
                            int lastNum = myMatrix[0, colToMove];

                            for (int k = 0; k < myMatrix.GetLength(0) - 1; k++)
                            {
                                myMatrix[k, colToMove] = myMatrix[k + 1, colToMove];
                            }
                            myMatrix[myMatrix.GetLength(0) - 1, colToMove] = lastNum;
                        }
                        break;
                    case "down":

                        for (int j = 0; j < movesToPerform; j++)
                        {
                            int lastNum = myMatrix[rows - 1, colToMove];

                            for (int k = 0; k < myMatrix.GetLength(0) - 1; k++)
                            {
                                myMatrix[rows - 1 - k, colToMove] = myMatrix[rows - 2 - k, colToMove];
                            }
                            myMatrix[0, colToMove] = lastNum;
                        }
                        break;
                    case "right":
                        for (int j = 0; j < movesToPerform; j++)
                        {
                            int lastNum = myMatrix[rowToMove, myMatrix.GetLength(1) - 1];

                            for (int k = myMatrix.GetLength(1) - 1; k > 0; k--)
                            {
                                myMatrix[rowToMove, k] = myMatrix[rowToMove, k - 1];
                            }
                            myMatrix[rowToMove, 0] = lastNum;
                        }
                        break;
                    case "left":
                        for (int j = 0; j < movesToPerform; j++)
                        {
                            int lastNum = myMatrix[rowToMove, 0];

                            for (int k = 0; k < cols - 1; k++)
                            {
                                myMatrix[rowToMove, k] = myMatrix[rowToMove, k + 1];
                            }
                            myMatrix[rowToMove, cols - 1] = lastNum;
                        }
                        break;
                }
            }

            int checkCounter = 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (myMatrix[row, col] == checkCounter)
                    {
                        Console.WriteLine("No swap required");
                        checkCounter++;
                        continue;
                    }

                    int[] checkCounterRowAndCol = FindCheckcounterPosition(checkCounter, myMatrix);
                    int tempRow = checkCounterRowAndCol[0];
                    int tempCol = checkCounterRowAndCol[1];

                    int temp = myMatrix[row, col];
                    myMatrix[row, col] = checkCounter;
                    myMatrix[tempRow, tempCol] = temp;
                    Console.WriteLine($"Swap ({row}, {col}) with ({tempRow}, {tempCol})");
                    checkCounter++;
                }
            }
        }

        private static int[] FindCheckcounterPosition(int checkCounter, int[,] myMatrix)
        {
            int[] positionOfCheckcounter = new int[2];

            for (int row = 0; row < myMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < myMatrix.GetLength(1); col++)
                {
                    if (myMatrix[row, col] == checkCounter)
                    {
                        positionOfCheckcounter[0] = row;
                        positionOfCheckcounter[1] = col;
                    }
                }
            }
            return positionOfCheckcounter;
        }
    }
}
