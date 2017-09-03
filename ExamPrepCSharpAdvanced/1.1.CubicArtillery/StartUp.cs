using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public class StartUp
{
    public static void Main()
    {
        int bunkerTotalCapacity = int.Parse(Console.ReadLine());
        Queue<Bunker> bunkers = new Queue<Bunker>();

        //  Dictionary<string, List<int>> bunkers = new Dictionary<string, List<int>>();

        string input;

        while ((input = Console.ReadLine()) != "Bunker Revision")
        {
            string[] tokens = input.Split();
            Regex alphabet = new Regex(@"[A-Z]+|[a-z]+");

            foreach (var token in tokens)
            {
                if (alphabet.IsMatch(token))
                {
                    bunkers.Enqueue(new Bunker(token));
                    continue;
                }
                int weapon = int.Parse(token);

                if (weapon > bunkerTotalCapacity)
                {
                    continue;
                }

                if (bunkers.Count != 0)
                {
                    if (bunkers.Count != 1)
                    {
                        int cnt = bunkers.Count;

                        while (cnt != 0)
                        {
                            cnt--;

                            var currentBunker = bunkers.Dequeue();

                            if (bunkerTotalCapacity - currentBunker.TotalSumOfWeapons <= weapon)
                            {
                                currentBunker.Weapons.Enqueue(weapon);

                                if (currentBunker.TotalSumOfWeapons == bunkerTotalCapacity)
                                {
                                    Console.WriteLine(currentBunker.Name + " -> " + string.Join(", ", currentBunker.Weapons));
                                    break;
                                }

                                bunkers.Enqueue(currentBunker);
                            }
                        }
                    }

                    else
                    {
                        Bunker theOnlyBunker = bunkers.Dequeue();

                        if (bunkerTotalCapacity >= weapon)
                        {
                            if (bunkerTotalCapacity - theOnlyBunker.TotalSumOfWeapons >= weapon)
                            {
                                theOnlyBunker.Weapons.Enqueue(weapon);
                            }
                            else
                            {
                                while (bunkerTotalCapacity - theOnlyBunker.TotalSumOfWeapons < weapon)
                                {
                                    theOnlyBunker.Weapons.Dequeue();
                                }
                                theOnlyBunker.Weapons.Enqueue(weapon);

                            }

                            bunkers.Enqueue(theOnlyBunker);

                        }
                    }
                }
            }
        }    
    }
}


public class Bunker
{
    public Bunker(string name)
    {
        Name = name;
        this.Weapons = new Queue<int>();
    }

    public string Name { get; set; }
    public Queue<int> Weapons { get; set; }

    public int TotalSumOfWeapons => this.Weapons.Sum();
}