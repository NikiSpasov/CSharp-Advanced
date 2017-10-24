using System;
using System.Collections.Generic;
using System.Linq;

public class GreedyTimes
{
    public static void Main(string[] args)
    {
        long capacityOfABag = long.Parse(Console.ReadLine());

        Dictionary<string, long> gold = new Dictionary<string, long>();
        Dictionary<string, long> gems = new Dictionary<string, long>();
        Dictionary<string, long> cash = new Dictionary<string, long>();

        string[] input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < input.Length; i += 2)
        {
            string key = input[i];
            int value = int.Parse(input[i + 1]);

            //gold:
            if (key.ToLower() == "gold") //check for Gold case
            {
                if (CheckForOverSizetheBag(value, gold, cash, gems, capacityOfABag))
                {
                    if (value > capacityOfABag)
                    {
                        continue;
                    }
                    if (value + gems.Values.Sum() <= capacityOfABag)
                    {
                        cash.Clear();
                    }
                    if (value <= capacityOfABag)
                    {
                        gems.Clear();
                        cash.Clear();
                    }
                }

                if (!gold.ContainsKey(key))
                {
                    gold.Add(key, value);
                    if (CheckIfGoldIsMoreThanGem(gold, gems))
                    {
                        continue;
                    }
                    gems.Clear();
                    cash.Clear();
                }

                gold[key] += value;
                if (CheckIfGoldIsMoreThanGem(gold, gems))
                {
                    continue;
                }
                gems.Clear();
                cash.Clear();
            }

            //gem:
            string finalThree = key.Remove(0, key.Length - 3).ToLower();
            if (key.Length > 3 &&
                finalThree == "gem")
            {
                if (CheckForOverSizetheBag(value, gold, cash, gems, capacityOfABag))
                {
                    continue;
                } //may be here?

                if (value + gems.Values.Sum() > gold.Values.Sum())
                {
                    continue;
                }
                if (!gems.ContainsKey(key))
                {
                    gems.Add(key, value);
                    continue;
                }
                gems[key] += value;
            }

            //cash:
            if (key.Length == 3)
            {
                if (CheckForOverSizetheBag(value, gold, cash, gems, capacityOfABag))
                {
                    continue;
                }

                if (cash.Values.Sum() + value > gems.Values.Sum())
                {
                    continue;
                }

                if (!cash.ContainsKey(key))
                {
                    cash.Add(key, value);
                    continue;
                }

                cash[key] += value;
            }

        }
        Print(cash, gems, gold);
    }

    private static void Print(Dictionary<string, long> cash, Dictionary<string, long> gems, Dictionary<string, long> gold)
    {
        Dictionary<string, Dictionary<string, long>> all = new Dictionary<string, Dictionary<string, long>>();

        if (cash.Count != 0)
        {
            all.Add("Cash", cash);
        }
        if (gems.Count != 0)
        {
            all.Add("Gem", gems);
        }
        if (gold.Count != 0)
        {
            all.Add("Gold", gold);
        }

        foreach (var type in all.OrderByDescending(x => x.Value.Values.Sum()))
        {
            var a = type.Value.OrderByDescending(x => x.Key).ThenBy(y => y.Value).ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"<{type.Key}> ${type.Value.Values.Sum()}");
            foreach (var part in a)
            {
                Console.WriteLine($"##{part.Key} - {part.Value}");
            }           
        }
    }

    private static bool CheckForOverSizetheBag(
        int value,
        Dictionary<string, long> gold,
        Dictionary<string, long> cash,
        Dictionary<string, long> gems,
        long capacityOfABag)
    {
        if (value + gold.Values.Sum() + cash.Values.Sum() + gems.Values.Sum() > capacityOfABag)
        {
            return true;
        }
        return false;
    }

    private static bool CheckIfGoldIsMoreThanGem(Dictionary<string, long> gold,
        Dictionary<string, long> gems)
    {
        if (gold.Values.Sum() > gems.Values.Sum())
        {
            return true;
        }
        return false;
    }
}

