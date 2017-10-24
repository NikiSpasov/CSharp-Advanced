using System;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

public class DangerousFloor
{
    public static void Main(string[] args)
    {
        string[,] board = new string[8, 8];

        //fill the board:
        for (int i = 0; i < 8; i++)
        {
            string[] input = Console.ReadLine().Split(new[] { ',' },
                System.StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < 8; j++)
            {
                board[i, j] = input[j];
            }
        }

        string command;

        while ((command = Console.ReadLine()) != "END")
        {
            string[] input = command.Split('-');
            Regex letterRegex = new Regex(@"[A-Za-z]+");
            Regex digit = new Regex(@"[\d]+");

            string figure = letterRegex.Match(input[0]).Value;
            string num = digit.Match(input[0]).Value;
            int rowOfFigure = int.Parse(num[0].ToString());
            int colOfFigure = int.Parse(command[1].ToString());

            string secondNum = digit.Match(input[1]).Value;
            int rowToGo = int.Parse(secondNum[0].ToString());
            int colToGo = int.Parse(secondNum[1].ToString());

            if (!CheckIfThereIsSuchPiece(board, figure, rowOfFigure, colOfFigure))
            {
                Console.WriteLine("There is no such a piece!");
                continue;
            }

            if (!CheckForValidMove(board, figure, rowOfFigure, colOfFigure, rowToGo, colToGo))
            {
                Console.WriteLine("Invalid move!");
                continue;
            }
            if (!CheckOutOfBoard(board, rowToGo, colToGo))
            {

                //get data from num.2 method?
                Console.WriteLine("Move go out of board!");
                continue;
            }
            board[rowToGo, colToGo] = figure;
            board[rowOfFigure, colOfFigure] = "x";            
        }

    }

    private static bool CheckOutOfBoard(string[,] board, int rowToGo, int colToGo)
    {
        if (rowToGo > 7 || colToGo > 7) //possible bug!
        {
            return false;
        }
        return true;
    }

    private static bool CheckForValidMove(string[,] board, string figure, int rowOfFigure, int colOfFigure, int rowToGo, int colToGo)
    {

        switch (figure)
        {
            case "K":
                if (rowOfFigure + 1 == rowToGo || rowOfFigure - 1 == rowToGo
                   || colOfFigure + 1 == colToGo || colOfFigure - 1 == colToGo
                   || (rowOfFigure + 1 == colToGo && colOfFigure + 1 == rowToGo)
                   || (rowOfFigure + 1 == colToGo && colOfFigure - 1 == rowToGo)
                   || (rowOfFigure - 1 == colToGo && colOfFigure + 1 == rowToGo)
                   || (rowOfFigure - 1 == colToGo && colOfFigure - 1 == rowToGo))
                {
                    return true;
                }
                return false;

            case "R":
                if (colOfFigure == colToGo || rowOfFigure == rowToGo )
                {
                    return true;
                }
                return false;

            case "B":
                if (rowOfFigure != rowToGo && colOfFigure != colToGo)
                {
                    return true;
                }
                return false;

            case "Q":
                if (rowOfFigure != rowToGo || colOfFigure != colToGo)
                {
                    return true;
                }
                return false;

            case "P":
                if (colOfFigure == colToGo && rowOfFigure - 1 == rowToGo)
                {
                    return true;
                }
                return false;
        }
        return false;
    }

    private static bool CheckIfThereIsSuchPiece(string[,] board, string figure, int rowOfFigure, int colOfFigure)
    {
        if (board[rowOfFigure, colOfFigure] == figure)
        {
            return true;
        }
        return false;       
    }
}

