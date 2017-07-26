using Models;
using System;
using System.Collections.Generic;

namespace Utilities
{
    public class CoinGenerator
    {
        private Dictionary<char, int> coinsAvailible =  new Dictionary<char, int>();
        private char[] coins = { '1', '2', '3', '5', '7' };
        public CoinGenerator()
        {
            this.Coins = new HashSet<Coin>();
            coinsAvailible.Add('1', 10);
            coinsAvailible.Add('2', 20);
            coinsAvailible.Add('3', 30);
            coinsAvailible.Add('5', 50);
            coinsAvailible.Add('7', 70);
        }
        public HashSet<Coin> Coins { get; set; }

        public Coin GenerateCoin(Window consoleWindow, Random rand)
        {
            //Random rand = new Random(0);
            char coinSymbol = coins[rand.Next(4)];
            Position coinPosition = new Position(rand.Next(3, consoleWindow.FrameWidth - 1), rand.Next(5, consoleWindow.FrameHeight - 1));
            Coin newCoin = new Coin(coinSymbol, coinsAvailible[coinSymbol], coinPosition);
            Coins.Add(newCoin);
            return newCoin;
        }
    }
}
