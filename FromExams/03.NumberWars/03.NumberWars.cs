

namespace _03.NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class NumberWars
    {
        static void Main()
        {
            var cardsFirst = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var cardsSecond = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> firstPlayerCards = new Queue<string>();
            Queue<string> secondPlayerCards = new Queue<string>();

            foreach (var card in cardsFirst)
            {
                firstPlayerCards.Enqueue(card);
            }
            foreach (var card in cardsSecond)
            {
                secondPlayerCards.Enqueue(card);
            }

            int cnt = 0;

            while (firstPlayerCards.Count != 0 && secondPlayerCards.Count != 0 && cnt != 0)
            {
                cnt++;

                string firstCard = firstPlayerCards.Dequeue();
                string secondCard = secondPlayerCards.Dequeue();

                int firstCardNumber = getCardNumber(firstCard);
                int secondCardNumber = getCardNumber(secondCard);

                if (firstCardNumber > secondCardNumber)
                {
                    if (powerOfCard(firstCard) > powerOfCard(secondCard))
                    {
                        firstPlayerCards.Enqueue(secondCard);
                        firstPlayerCards.Enqueue(firstCard);
                    }
                    else
                    {
                        firstPlayerCards.Enqueue(firstCard);
                        firstPlayerCards.Enqueue(secondCard);
                    }
                }
                else if (secondCardNumber > firstCardNumber)
                {
                    if (powerOfCard(firstCard) > powerOfCard(secondCard))
                    {
                        secondPlayerCards.Enqueue(secondCard);
                        secondPlayerCards.Enqueue(firstCard);
                    }
                    else
                    {
                        secondPlayerCards.Enqueue(firstCard);
                        secondPlayerCards.Enqueue(secondCard);
                    }

                }
                else
                {
                    int firstListSum = 0;
                    int secondListSum = 0;

                    List<string> cardsFromWar = new List<string>();
                    cardsFromWar.Add(firstCard);
                    cardsFromWar.Add(secondCard);

                    while (firstListSum == secondListSum)
                    {

                        for (int i = 0; i < 3; i++)
                        {
                            var firstOneAdd = firstPlayerCards.Dequeue();
                            var secondOneAdd = secondPlayerCards.Dequeue();
                            firstListSum += firstOneAdd[firstOneAdd.Length - 1] - 96;
                            secondListSum += secondOneAdd[secondOneAdd.Length - 1] - 96;

                            cardsFromWar.Add(firstOneAdd);
                            cardsFromWar.Add(secondOneAdd);
                            if (firstPlayerCards.Count == 0 && secondPlayerCards.Count == 0)
                            {
                                if (firstListSum == secondListSum)
                                {
                                    Console.WriteLine("Draw after 1 turns");
                                    return;
                                }
                                else if (firstListSum > secondListSum)
                                {
                                    Console.WriteLine($"First player wins after {cnt} turns");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine($"Second player wins after {cnt} turns");
                                    return;
                                }
                            }
                        }

                    }
                    var cardsFromWarSorted = cardsFromWar
                        .OrderByDescending(powerOfCard)
                        .ToList();

                    if (firstListSum > secondListSum)
                    {
                        foreach (var card in cardsFromWarSorted)
                        {
                            firstPlayerCards.Enqueue(card);
                        }
                    }
                    else if (secondListSum > firstListSum)
                    {
                        foreach (var card in cardsFromWarSorted)
                        {
                            secondPlayerCards.Enqueue(card);
                        }
                    }

                }

                if (cnt == 1000000)
                {
                    if (firstPlayerCards.Count > secondPlayerCards.Count)
                    {
                        Console.WriteLine($"First player wins after {cnt} turns");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Second player wins after {cnt} turns");
                        return;
                    }
                }
            }
            if (firstPlayerCards.Count == 0)
            {
                Console.WriteLine($"Second player wins after {cnt} turns");
                return;
            }
            else if (secondPlayerCards.Count == 0)
            {
                Console.WriteLine($"First player wins after {cnt} turns");
                return;
            }
        }

        public static int powerOfCard(string card)
        {
            int totalPower = 0;

            int num = int.Parse(card.Substring(0, card.Length - 1));
            int letterToNum = card[card.Length - 1] - 96;

            totalPower = num + letterToNum;

            return totalPower;
        }

        public static int getCardNumber(string card)
        {
            int num = int.Parse(card.Substring(0, card.Length - 1));
            return num;
        }
    }
}
