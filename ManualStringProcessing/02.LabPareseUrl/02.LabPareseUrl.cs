using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LabPareseUrl
{
    class ParseUrl
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] splitted = input.Split(new[] {"://"}, 
                StringSplitOptions.RemoveEmptyEntries);

            if (splitted.Length != 2 || splitted[1].IndexOf("/") == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            string[] splittedForTheRest = splitted[1].Split('/');

            string protocol = splitted[0];
            string server = splittedForTheRest[0];
            string resources = input.Remove(0, protocol.Length + server.Length + 4);

            Console.WriteLine ($"Protocol = {protocol}{Environment.NewLine}" +
                               $"Server = {server}{Environment.NewLine}" +
                               $"Resources = {resources}");
        }
    }
}
