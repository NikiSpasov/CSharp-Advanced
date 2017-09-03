
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        Dictionary<string, Region> regions = new Dictionary<string, Region>();

        List<Region> helperForPrint = new List<Region>();
        string input;

        while ((input = Console.ReadLine()) != "Count em all")
        {
            var tokens = input.Split(new string[] {" -> "}, StringSplitOptions
                .RemoveEmptyEntries);

            string region = tokens[0];
            string colorOfMeteors = tokens[1];
            int count = int.Parse(tokens[2]);
            Region currentRegion;

            if (!regions.ContainsKey(region))
            {
                currentRegion = new Region(region);

                if (currentRegion.colorsAndCount.ContainsKey(colorOfMeteors))
                {
                    currentRegion.colorsAndCount[colorOfMeteors] += count;
                    currentRegion.CheckForConversion();
                }
                regions.Add(region, currentRegion);
            }
            else
            {
                currentRegion = regions[region];
                currentRegion.colorsAndCount[colorOfMeteors] += count;
                currentRegion.CheckForConversion();
            }
        }
        foreach (var region in regions)
        {
            helperForPrint.Add(region.Value);
        }

        Print(helperForPrint);


        void Print(List<Region> regs)
        {
            List<Region> sortedRegs = regs.OrderByDescending(x => x.colorsAndCount["Black"])
                .ThenBy(x => x.Name.Length)
                .ThenBy(x => x.Name)
                .ToList();

           foreach (var reg in sortedRegs)
           {
                Dictionary<string, int> hepler = new Dictionary<string, int>(reg.colorsAndCount)
                    .OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x=> x.Key, y => y.Value);

               reg.colorsAndCount = hepler;

               Console.WriteLine(reg.ToString().Trim());
           }
        }
    }
}

public class Region 
{
    public string Name { get; set; }

    private const string Black = "Black";
    private const string Red = "Red";
    private const string Green = "Green";


    public Dictionary<string, int> colorsAndCount;

    public Region(string name)
    {
        this.Name = name;

        this.colorsAndCount = new Dictionary<string, int>
        {
            {Black, 0},
            {Green, 0},
            {Red, 0}
        };
    }

    public void CheckForConversion()
    {
        if (this.colorsAndCount[Green] >= 1000000)
        {          
            this.colorsAndCount[Red]+= this.colorsAndCount[Green] / 1000000;
            this.colorsAndCount[Green] %= 1000000;
        }
        if (this.colorsAndCount[Red] >= 1000000)
        {
            this.colorsAndCount[Black] += this.colorsAndCount[Red] / 1000000;
            this.colorsAndCount[Red] %= 1000000;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.Name}");
        foreach (var color in this.colorsAndCount)
        {
            sb.AppendLine($"-> {color.Key} : {color.Value}");
        }

        return sb.ToString();
    }
}
