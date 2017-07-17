using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _16.AdvancedExam19June2016
{

    class Program
    {
        const long formationSize = 1000000;

        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var meteors = new SortedDictionary<string, SortedDictionary<string, long>>();

            while (input != "Count em all")
            {
                var data = Regex.Match(input, @"^(.*?) -> (.*?) -> (.*?)$");

                var regionName = data.Groups[1].ToString();
                var meteorType = data.Groups[2].ToString();
                var count = long.Parse(data.Groups[3].ToString());

                if (!meteors.ContainsKey(regionName))
                {
                    meteors.Add(regionName, new SortedDictionary<string, long>());
                    meteors[regionName].Add("Green", 0);
                    meteors[regionName].Add("Red", 0);
                    meteors[regionName].Add("Black", 0);
                }

                meteors[regionName][meteorType] += count;

                if (meteors[regionName]["Green"] >= formationSize)
                {
                    meteors[regionName]["Red"] += meteors[regionName]["Green"] / formationSize;
                    meteors[regionName]["Green"] %= formationSize;
                }

                if (meteors[regionName]["Red"] >= formationSize)
                {
                    meteors[regionName]["Black"] += meteors[regionName]["Red"] / formationSize;
                    meteors[regionName]["Red"] %= formationSize;
                }

                input = Console.ReadLine();
            }

            foreach (var meteor in meteors.OrderByDescending(x => x.Value["Black"])
                .ThenBy(x => x.Key.Length)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine(meteor.Key);

                foreach (var type in meteor.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"-> {type.Key} : {type.Value}");
                }
            }
        }
    }
}