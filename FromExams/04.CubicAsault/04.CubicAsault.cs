using System.Xml.Schema;

namespace _04.CubicAsault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class CubicArmy
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, int>> total = new Dictionary<string, Dictionary<string, int>>();
            
            Dictionary<string, int> typeCount = new Dictionary<string, int>(); 

            while (input != "Count em all")
            {

              var data = Console.ReadLine()
                    .Split(new []{"->"}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                string region = data[0];
                string type = data[1];
                int count = int.Parse(data[2]);

                if (!total.ContainsKey(region))
                {
                    typeCount.Add(type, count);
                    total.Add(region, typeCount);
                    continue;
                }
                else
                {
                    //here more to do...
                    if (typeCount.ContainsKey(type) && type == "Black") //green 1mln = 1 red, 1mln red = 1 black
                    {
                        typeCount[type] += count;
                    }
                    if (typeCount.ContainsKey(type) && type == "Red") //green 1mln = 1 red, 1mln red = 1 black
                    {
                        typeCount[type] += count;
                    }
                  if (typeCount.ContainsKey(type) && type == "Green") //green 1mln = 1 red, 1mln red = 1 black
                    {
                        typeCount[type] += count;
                    }
                }
                total[region][type] += typeCount[type];

            }
           // foreach (var region in total.OrderBy(a => a.Key.(y => y == 'B']))
            {
                
            }
        }
    }
}
