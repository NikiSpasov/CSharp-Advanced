namespace _08.MapDistrict
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class MapDistrict
    {
        static void Main()
        {
            List<string> input = Console.ReadLine()
                .Trim()
                .Split(new []{' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var filter = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> cityPopulations = new Dictionary<string, List<int>>();

            foreach (var cityDistr in input)
            {
               List<string> kvp = cityDistr.Split(':').ToList();
                string currentKey = kvp[0];
                int population = int.Parse(kvp[1]);

                if (!cityPopulations.ContainsKey(currentKey))
                {
                    cityPopulations.Add(currentKey, new List<int>());
                }
                cityPopulations[currentKey].Add(population);                    
            }       

            foreach (var kvp in cityPopulations.OrderByDescending(x => x.Value.Sum())) 
            {
                
                var result = cityPopulations[kvp.Key]
                    .OrderByDescending(x => x)
                    .Take(5)
                    .ToList();

                if (result.Count == 0)
                {
                    continue;
                }


                int sum = result.Sum();
                if (sum > filter)
                {
                    Console.Write($"{kvp.Key}: ");
                    Console.WriteLine(String.Join(" ", result));
                }
            }
        }
    }
}
