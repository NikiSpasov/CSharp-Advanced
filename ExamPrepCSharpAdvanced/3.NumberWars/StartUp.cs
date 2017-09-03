using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public class StartUp
{
    public static void Main()
    {
        Game game = new Game();

        Queue<Card> firstPlayerCards = new Queue<Card>();
        Queue<Card> secondPlayerCards = new Queue<Card>();

        string[] firstInput = Console.ReadLine().Trim().Split();
        foreach (var card in firstInput)
        {
            firstPlayerCards.Enqueue(new Card(card));
        }

        string[] secondInput = Console.ReadLine().Trim().Split();
        foreach (var card in secondInput)
        {
            secondPlayerCards.Enqueue(new Card(card));
        }

        game.PlayGame(firstPlayerCards, secondPlayerCards);
    }
}

public class Card
{
    public int TotalPower { get; set; }
    public int PowerFromColor { get; set; }
    public int PowerFromNumber { get; set; }

    public Card(string card)
    {
        Regex regAlphabet = new Regex(@"[a-z]");
        Regex digits = new Regex(@"\d+");
        Match number = digits.Match(card);
        Match letter = regAlphabet.Match(card);

        this.PowerFromColor = GetPowerFromColor(char.Parse(letter.Value));
        this.PowerFromNumber = int.Parse(number.Value);
        this.TotalPower = this.PowerFromColor + this.PowerFromNumber;

    }

    public int GetPowerFromColor(char color)
    {
        return (int)color - 96;
    }
}

public class Game
{
    public void PlayGame(Queue<Card> firstPlayerCards, Queue<Card> secondPlayerCards)
    {
        int turns = 0;

        while (true)
        {

            Card firstCurCard = firstPlayerCards.Dequeue();
            Card secondCurCard = secondPlayerCards.Dequeue();

            if (firstCurCard.PowerFromNumber > secondCurCard.PowerFromNumber)
            {
                firstPlayerCards.Enqueue(firstCurCard);
                firstPlayerCards.Enqueue(secondCurCard);
                turns++;

                if (CheckTerminationCondition(firstPlayerCards.Count, secondPlayerCards.Count, turns))
                {
                    return;
                }

            }
            else if (firstCurCard.PowerFromNumber < secondCurCard.PowerFromNumber)
            {
                secondPlayerCards.Enqueue(secondCurCard);
                secondPlayerCards.Enqueue(firstCurCard);
                turns++;

                if (CheckTerminationCondition(firstPlayerCards.Count, secondPlayerCards.Count, turns))
                {
                    return;
                }

            }
            // CheckTerminationCondition(firstPlayerCards.Count, secondPlayerCards.Count, turns);

            //WAR
            if (firstCurCard.PowerFromNumber == secondCurCard.PowerFromNumber)
            {
                turns++;

                if (CheckTerminationCondition(firstPlayerCards.Count, secondPlayerCards.Count, turns))
                {
                    return;
                }

                while (true)
                {
                    List<Card> threeMoreCardsFirstPlayer = firstPlayerCards.Take(3).ToList();

                    for (int i = 0; i < 3; i++)
                    {
                        firstPlayerCards.Dequeue();
                    }

                    List<Card> threeMoreCardsSecondPlayer = secondPlayerCards.Take(3).ToList();

                    for (int i = 0; i < 3; i++)
                    {
                        secondPlayerCards.Dequeue();
                    }

                    int resultFromFirstPlayer = threeMoreCardsFirstPlayer.Select(x => x.PowerFromColor).Sum();
                    int resultFromSecondPlayer = threeMoreCardsSecondPlayer.Select(x => x.PowerFromColor).Sum();
                    if (resultFromFirstPlayer > resultFromSecondPlayer)
                    {
                        threeMoreCardsFirstPlayer.AddRange(threeMoreCardsSecondPlayer);
                        List<Card> orderedByDescending = 
                            threeMoreCardsFirstPlayer
                            .OrderByDescending(x => x.TotalPower)
                            .ToList();

                        foreach (var card in orderedByDescending)
                        {
                            firstPlayerCards.Enqueue(card);
                        }

                        if (CheckTerminationCondition(firstPlayerCards.Count, secondPlayerCards.Count, turns))
                        {
                            return;
                        }
                    }
                    if (resultFromFirstPlayer < resultFromSecondPlayer)
                    {
                        threeMoreCardsFirstPlayer.AddRange(threeMoreCardsSecondPlayer);
                        List<Card> orderedByDescending =
                            threeMoreCardsFirstPlayer
                                .OrderByDescending(x => x.TotalPower)
                                .ToList();
                        foreach (var card in orderedByDescending)
                        {
                            secondPlayerCards.Enqueue(card);
                        }

                        if (CheckTerminationCondition(firstPlayerCards.Count, secondPlayerCards.Count, turns))
                        {
                            return;
                        }
                    }
                    if (CheckTerminationCondition(firstPlayerCards.Count, secondPlayerCards.Count, turns))
                    {
                        return;
                    }
                }
            }

            bool CheckTerminationCondition(int firstCount, int secondCount, int turnNum)
            {
                bool conditionToEnd = false;
                if (turnNum >= 1000000)
                {
                    if (firstCount > secondCount)
                    {
                        Console.WriteLine($"First player wins after {turnNum} turns");
                        conditionToEnd = true;
                    }
                    else if (firstCount > secondCount)
                    {
                        Console.WriteLine($"Second player wins after {turnNum} turns");
                        conditionToEnd = true;
                    }
                    else
                    {
                        Console.WriteLine($"Draw after {turnNum} turns");
                        conditionToEnd = true;
                    }
                }

                if (firstCount == 0 && secondCount != 0)
                {
                    Console.WriteLine($"Second player wins after {turnNum} turns");
                    conditionToEnd = true;

                }

                if (secondCount == 0 && firstCount != 0)
                {
                    Console.WriteLine($"First player wins after {turnNum} turns");
                    conditionToEnd = true;
                }

                if (secondCount == 0 && firstCount == 0)
                {
                    Console.WriteLine($"Draw after {turnNum} turns");
                    conditionToEnd = true;
                }
                return conditionToEnd;
            }
        }
    }
}

