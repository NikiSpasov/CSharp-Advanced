using System;
using System.Collections.Generic;
using System.Linq;

public class CubicAssault
{
    public static void Main()
    {
        string input;


        //may be sortedDict??
       var regionWithMeteors = new Dictionary<string, Dictionary<string, int>>();

        while ((input = Console.ReadLine()) != "Count em all")
        {
            var tokens = input.Split(new string[] {" -> "}, StringSplitOptions
                .RemoveEmptyEntries);

            string region = tokens[0];
            string colorOfMeteors = tokens[1];
            int count = int.Parse(tokens[2]);

            if (!regionWithMeteors.ContainsKey(region))
            {
                //initialize with three /Black, Green, Red/ colors!

                regionWithMeteors.Add(region, new Dictionary<string, int>
                {
                    {"Black", 0},
                    {"Green", 0},
                    {"Red", 0}
                });

                //continue; //no?
            }
            if (colorOfMeteors == "Black")
            {
                regionWithMeteors[colorOfMeteors][colorOfMeteors] += count;
            }
            if (colorOfMeteors == "Green")
            {
                regionWithMeteors[colorOfMeteors][colorOfMeteors] += count;
                if (regionWithMeteors[colorOfMeteors][colorOfMeteors] >= 1000000)
                {
                    regionWithMeteors[colorOfMeteors][colorOfMeteors] = 0;
                    regionWithMeteors["Red"]["Red"] += 1;
                }
                if (regionWithMeteors["Red"]["Red"] >= 1000000)
                {
                    regionWithMeteors["Black"]["Black"] += 1;
                    regionWithMeteors["Red"]["Red"] = 0;
                }
            }
            if (colorOfMeteors == "Red")
            {
                regionWithMeteors[colorOfMeteors][colorOfMeteors] += count;
                if (regionWithMeteors[colorOfMeteors][colorOfMeteors] >= 1000000)
                {
                    regionWithMeteors[colorOfMeteors][colorOfMeteors] = 0;
                    regionWithMeteors["Black"]["Black"] += 1;
                }
            }

        }

        foreach (var region in regionWithMeteors
            .OrderByDescending(x => x.Value["Black"])
            .ThenBy(name => name.Key.Length)
            .ThenBy(name => name.Key))
        {
            var helper = regionWithMeteors.Values.OrderByDescending(x => x.Values);

            Console.WriteLine($"{region.Key}{Environment.NewLine}" +
                              $" -> ");
          //  Console.WriteLine(helper[region[]]);

        }
    }
}

