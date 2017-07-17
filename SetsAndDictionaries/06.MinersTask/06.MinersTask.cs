

using System.Collections.Generic;

namespace _06.MinersTask
{
    using System;
    class MinerTast
    {
        static void Main()
        {

            Dictionary<string, int> resourcesAndQuantity = new Dictionary<string, int>();
            string resource = "";
            int quantity = 0;

            for (int i = 1; i >= 1; i++)
            {
                if (i % 2 != 0)
                {
                    resource = Console.ReadLine();
                    if (resource == "stop")
                    {
                        foreach (KeyValuePair<string, int> resources in resourcesAndQuantity)
                        {
                            Console.WriteLine($"{resources.Key} -> {resources.Value}");
                        }
                        return;
                    }
                    quantity = int.Parse(Console.ReadLine());

                    if (resourcesAndQuantity.ContainsKey(resource))
                    {
                        resourcesAndQuantity[resource] += quantity;
                    }
                    else
                    {
                        resourcesAndQuantity.Add(resource, quantity);
                    }
                }
            }
        }
    }
}

