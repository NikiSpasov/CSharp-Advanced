namespace _11.PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var plantPesticide = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int cnt = 1;

            int days = 0;

            while (cnt != 0)
            {
                for (int i = 1; i < plantPesticide.Count - 1; i++)
                {
                    cnt = 0;
                    if (plantPesticide[i + 1] > plantPesticide[i])
                    {
                        plantPesticide.RemoveAt(i + 1);
                        cnt++;
                    }
                }
                days++;
            }
            Console.WriteLine(days - 1);





        }

    }
}
