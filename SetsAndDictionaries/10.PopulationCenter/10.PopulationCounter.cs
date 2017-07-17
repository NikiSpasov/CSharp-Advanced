using System.Security.Cryptography.X509Certificates;

namespace _10.PopulationCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class PopulationCenter
    {
        static void Main()
        {
            string input = Console.ReadLine();

            var countrysAndTowns = new Dictionary<string, Dictionary<string, int>>();
            var countriesTotalPopulation = new Dictionary<string, int>();

            while (input != "report")
            {
                string[] populationData = input.Split('|').ToArray();
                string city = populationData[0];
                string country = populationData[1];
                int countOfPopulation = int.Parse(populationData[2]);

                Dictionary<string, int> townAndCount = new Dictionary<string, int>();
                townAndCount.Add(city, countOfPopulation);

                if (!countrysAndTowns.ContainsKey(country))
                {
                    countrysAndTowns.Add(country, townAndCount);
                }
                else
                {
                    countrysAndTowns[country].Add(city, countOfPopulation);                   
                }

                if (!countriesTotalPopulation.ContainsKey(country))
                {
                    countriesTotalPopulation.Add(country, countOfPopulation);
                }
                else
                {
                    countriesTotalPopulation[country] += countOfPopulation;
                }

                input = Console.ReadLine();
            }

            var countriesByDecending =
                countriesTotalPopulation.OrderByDescending(x => x.Value);
            var townsByDecending =
                countrysAndTowns.OrderByDescending(x => x.Value);


            foreach (var country in townsByDecending)
            {
                Console.WriteLine($"{country}: (Total population: {countriesByDecending[country]})");
                
            }

        }
    }
}
