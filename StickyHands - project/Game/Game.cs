using Models;
using System;
using System.Linq;
using Utilities;
using System.Diagnostics;
using System.Threading;

namespace Game
{
    class Game
    {
        static void Main(string[] args)
        {
            while (true)
            {
                StartGame();
                Console.Write($"Do you want to play again? Y/N: " + Environment.NewLine);
                ConsoleKeyInfo key = Console.ReadKey();
                while (true)
                {
                    if (key.Key == ConsoleKey.N)
                    {
                        return;
                    }
                    if (key.Key == ConsoleKey.Y)
                    {
                        break;
                    }
                    Console.WriteLine(Environment.NewLine + "Wrong key! Please enter 'Y' for yes or 'N' for no.");
                    key = Console.ReadKey();
                }
            }
            
        }

        private static void StartGame()
        {
            Console.Clear();
            Console.Write("Enter your name: ");
            Player player = new Player(Console.ReadLine());
            Console.Clear();
            Window consoleWindow = new Window();
            Printer printer = new Printer(consoleWindow);
            StartupHelper startupHelper = new StartupHelper(consoleWindow);
            CoinGenerator coinGenerator = new CoinGenerator();
            EnemyGenerator enemyGenerator = new EnemyGenerator();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Random random = new Random();
            Timer timer = new Timer(t =>
            {
                if (watch.Elapsed.Seconds % 3 == 0)
                {
                    Coin newCoin = coinGenerator.GenerateCoin(consoleWindow, random);
                    printer.PrintCoin(newCoin);
                }
                if (watch.Elapsed.Seconds % 2 == 0)
                {
                    if (enemyGenerator.Enemies.Count < 15)
                    {
                        Enemy newEnemy = enemyGenerator.GenerateEnemy(consoleWindow, random);
                        printer.PrintEnemy(newEnemy);
                    }
                }
                if (watch.Elapsed.Seconds % 1 == 0)
                {
                    printer.PrintTime(watch.Elapsed);
                }
            }, null, 1000, 1000);

            startupHelper.SetProperties();
            printer.PrintFrame();
            printer.PrintInfo(player);

            while (true)
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    Direction newDirection = GetDirection(key.Key);
                    printer.ClearPlayer(player);
                    player.Move(newDirection);
                    if (player.IsDead(consoleWindow.Height, consoleWindow.Width) ||
                        enemyGenerator.IsPlayerKilled(player))
                    {
                        timer.Dispose();
                        printer.EndGame(player);
                        return;
                    }
                    CollectCoin(player, coinGenerator);
                    printer.PrintStatsOnly(player);
                    printer.PrintPlayer(player);

                }
            }
        }

        static Direction GetDirection(ConsoleKey key)
        {
            Direction resultDirection = Direction.Left;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    resultDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    resultDirection = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    resultDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    resultDirection = Direction.Down;
                    break;
            }
            return resultDirection;
        }

        public static void CollectCoin(Player player, CoinGenerator coinGenerator)
        {
            Coin coin = coinGenerator.Coins.FirstOrDefault(c => c.Position.Equals(player.Position));
            if (coin != null)
            {
                player.Points += coin.Value;
                player.CoinsCollected.Push(coin);
                coinGenerator.Coins.Remove(coin);
            }
        }
    }
}
