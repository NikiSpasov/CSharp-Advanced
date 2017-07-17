using System.Linq;

namespace _02.KnightGame
{
    using System;
    class KnightGame
    {
        static void Main()
        {
            int sizeOfMAtrix = int.Parse(Console.ReadLine());

            char[,] chessDesk = new char[sizeOfMAtrix, sizeOfMAtrix];

            for (int i = 0; i < sizeOfMAtrix; i++)
            {
                string  inputKnights = Console.ReadLine();

                for (int j = 0; j < inputKnights.Length; j++)
                {
                    if (inputKnights[j] == 'K')
                    {
                        chessDesk[i, j] = 'K';
                        continue;
                    }
                    chessDesk[i, j] = '0';
                }
            }
            for (int i = 0; i < chessDesk.GetLength(0); i++)
            {
                for (int j = 0; j < chessDesk.GetLength(1); j++)
                {
                    if (chessDesk[i, j] == 'K')
                    {
                        
                    }
                }
            }
        }
    }
}
