using System.ComponentModel;

namespace _08.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class HandsOfCards
    {
        public static void Main()
        {

            string input = Console.ReadLine();

            Dictionary<string, HashSet<string>> playersAndUniquCards = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                List<string> playerAndCards = input
                    .Trim()
                    .Split(new[] { ':', ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                HashSet<string> cardsOnly = new HashSet<string>();

                string playerName = playerAndCards[0];

                playerAndCards.RemoveAt(0);

                foreach (var card in playerAndCards)
                {
                    cardsOnly.Add(card);
                }

                if (playerName == "JOKER")
                {
                    foreach (KeyValuePair<string, HashSet<string>> kvp in playersAndUniquCards)
                    {
                        int finalValue = getHandValue(playersAndUniquCards[kvp.Key]);

                        Console.WriteLine($"{kvp.Key}: {finalValue}"); //to do 
                    }
                }
      
                if (!playersAndUniquCards.ContainsKey(playerName))
                {
                    playersAndUniquCards.Add(playerName, cardsOnly);
                }
                else
                {
                    foreach (var card in cardsOnly)
                    {
                    playersAndUniquCards[playerName].Add(card);

                    }
                }

                input = Console.ReadLine();
            }
        }

        public static int getHandValue(HashSet<string> cardsOnly)
        {

            int firstMultiplier = 0;
            int secondMultiplier = 0;
            int handValue = 0;

            foreach (var card in cardsOnly)
            {
                string cardValue = card[0].ToString();
                string colour = card[card.Length - 1].ToString();

                switch (cardValue)
                {
                    case "2":
                        firstMultiplier = 2;
                        break;
                    case "3":
                        firstMultiplier = 3;
                        break;
                    case "4":
                        firstMultiplier = 4;
                        break;
                    case "5":
                        firstMultiplier = 5;
                        break;
                    case "6":
                        firstMultiplier = 6;
                        break;
                    case "7":
                        firstMultiplier = 7;
                        break;
                    case "8":
                        firstMultiplier = 8;
                        break;
                    case "9":
                        firstMultiplier = 9;
                        break;
                    case "1":
                        firstMultiplier = 10;
                        break;
                    case "J":
                        firstMultiplier = 11;
                        break;
                    case "Q":
                        firstMultiplier = 12;
                        break;
                    case "K":
                        firstMultiplier = 13;
                        break;
                    case "A":
                        firstMultiplier = 14;
                        break;
                }

                switch (colour)
                {
                    case "S":
                        secondMultiplier = 4;
                        break;
                    case "H":
                        secondMultiplier = 3;
                        break;
                    case "D":
                        secondMultiplier = 2;
                        break;
                    case "C":
                        secondMultiplier = 1;
                        break;
                }
                
                int totalCardValue = firstMultiplier * secondMultiplier;
                handValue += totalCardValue;
            }           
            return handValue;
        }
    }
}
