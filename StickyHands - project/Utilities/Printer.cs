using Models;
using System;

namespace Utilities
{
    public class Printer
    {

        public Printer(Window window)
        {
            this.Window = window;
        }

        public Printer()
        {
            this.Window = new Window();
        }

        public Window Window { get; set; }

        public void PrintFrame()
        {
            for (int row = 0; row <= Window.FrameHeight; row++)
            {
                if (row <= 1)
                {
                    Console.WriteLine();
                    // todo: Print player stats
                    continue;
                }
                char firstSymbol = Window.VerticalBorder;
                char lastSymbol = Window.VerticalBorder;
                char middleSymbol = Window.EmptySpace;
                if (row == 2 || row == Window.FrameHeight)
                {
                    middleSymbol = Window.HorizontalBorder;
                    if (row == 2)
                    {
                        firstSymbol = Window.TopLeftCornerBorder;
                        lastSymbol = Window.TopRightCornerBorder;
                    }
                    else
                    {
                        firstSymbol = Window.BottomLeftCornerBorder;
                        lastSymbol = Window.BottomRightCornerBorder;
                    }

                }

                if (row != Window.FrameHeight)
                {
                    Console.WriteLine($" {firstSymbol}{new string(middleSymbol, Window.Width - 2)}{lastSymbol}");
                }
                else
                {
                    Console.WriteLine($" {firstSymbol}{new string(middleSymbol, Window.Width - 2)}{lastSymbol}");
                }
            }
        }

        public void PrintCoins(CoinGenerator coinGenerator)
        {
            foreach (Coin coin in coinGenerator.Coins)
            {
                PrintCoin(coin);
            }
        }
        public void PrintCoin(Coin coin)
        {
            Console.SetCursorPosition(coin.Position.X, coin.Position.Y);
            Console.Write(coin.Symbol);
        }
        public void PrintEnemy(Enemy enemy)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(enemy.Position.X, enemy.Position.Y);
            Console.Write(enemy.Symbol);
            Console.ForegroundColor = originalColor;
        }
        public void ClearCoins(CoinGenerator coinGenerator)
        {
            foreach (Coin coin in coinGenerator.Coins)
            {
                ClearCoin(coin);
            }
        }
        public void ClearCoin(Coin coin)
        {
            Console.SetCursorPosition(coin.Position.X, coin.Position.Y);
            Console.Write(" ");
        }
        public void PrintPlayer(Player player)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            Console.Write(player.Body);
            Console.ForegroundColor = originalColor;
        }
        public void ClearPlayer(Player player)
        {
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            Console.Write(" ");
        }
        public void PrintInfo(Player player)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(player.GetStats());
        }
        public void PrintStatsOnly(Player player)
        {
            Console.SetCursorPosition(0, 1);
            Console.Write(player.GetPlayerStats());
        }
        public void PrintTime(TimeSpan time)
        {
            string timeString = string.Format("Time elapsed {0:mm\\:ss}", time);
            Console.SetCursorPosition((Console.WindowWidth - timeString.Length) / 2, 0);
            Console.Write(timeString);
        }

        public void EndGame(Player player)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine(Environment.NewLine + "\tGAME OVER" + Environment.NewLine);
            Console.WriteLine("\tPlayer: " + player.Name);
            Console.WriteLine(string.Format($"\tTotal coins collected: {player.CoinsCollected.Count}" + Environment.NewLine + $"\tTotal points: {player.Points}" + Environment.NewLine));

        }
    }
}
