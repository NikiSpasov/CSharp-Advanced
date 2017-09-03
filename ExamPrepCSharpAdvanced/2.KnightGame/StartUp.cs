using System;
using System.Globalization;
using System.Runtime.InteropServices;

public class StartUp
{
    public static void Main()
    {
        int rowToRemove = 0, colToRemove = 0, minNumber = 0, knightsToRemove = 0;

        int sizeOfTheBoard = int.Parse(Console.ReadLine());

        string[,] chessBoard = new string[sizeOfTheBoard, sizeOfTheBoard];

        for (int i = 0; i < sizeOfTheBoard; i++)
        {
            string input = Console.ReadLine().Trim();
            for (int j = 0; j < input.Length; j++)
            {
                if (input[j] == 'K')
                {
                    chessBoard[i, j] = "K";
                }
                else
                {
                    chessBoard[i, j] = "0";
                }
            }
        }
        while (true)
        {
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                for (int j = 0; j < chessBoard.GetLength(1); j++)
                {
                    if (chessBoard[i, j] == "K")
                    {
                        int hits = HitsOnAnotherKnight(chessBoard, i, j);
                        if (hits > minNumber)
                        {
                            minNumber = hits;
                            rowToRemove = i;
                            colToRemove = j;
                        }
                    }
                }
            }
            if (minNumber > 0)
            {
                chessBoard[rowToRemove, colToRemove] = "0";
                knightsToRemove++;
                minNumber = 0;
                continue;
            }
            Console.WriteLine(knightsToRemove);
            return;
        }
    }

    private static int HitsOnAnotherKnight(string[,] chessBoard, int row, int col)
    {
        int chessMaxRow = chessBoard.GetLength(0) - 1;
        int chessMaxCol = chessBoard.GetLength(1) - 1;
        int chessMinRow = 0;
        int chessMinCol = 0;

        int hits = 0;

        //MoveUpLeft
        if (row - 2 >= chessMinRow && col - 1 >= chessMinCol && chessBoard[row - 2, col - 1] == "K")
        {
            hits++;
        }
        //MoveURight
        if (row - 2 >= chessMinRow && col + 1 <= chessMaxCol && chessBoard[row - 2, col + 1] == "K")
        {
            hits++;
        }
        //MoveDownLeft
        if (row + 2 <= chessMaxRow && col - 1 >= chessMinCol && chessBoard[row + 2, col - 1] == "K")
        {
            hits++;
        }
        //MoveDownRight
        if (row + 2 <= chessMaxRow && col + 1 <= chessMaxCol && chessBoard[row + 2, col + 1] == "K")
        {
            hits++;
        }
        //MoveSideLeftUp
        if (row - 1 >= chessMinRow && col - 2 >= chessMinCol && chessBoard[row - 1, col - 2] == "K")
        {
            hits++;
        }
        //MoveSideLeftDown
        if (row + 1 <= chessMaxRow && col - 2 >= chessMinCol && chessBoard[row + 1, col - 2] == "K")
        {
            hits++;
        }
        //MoveSideRightDown
        if (row + 1 <= chessMaxRow && col + 2 <= chessMaxCol && chessBoard[row + 1, col + 2] == "K")
        {
            hits++;
        }
        //MoveSideRightUp
        if (row - 1 >= chessMinRow && col + 2 <= chessMaxCol && chessBoard[row - 1, col + 2] == "K")
        {
            hits++;
        }
        return hits;
    }
}