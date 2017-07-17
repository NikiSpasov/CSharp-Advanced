using System.CodeDom;
using System.Xml;

namespace _10.PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class PredicateParty
    {
        static void Main()
        {
            List<string> people = Console.ReadLine()
                .Split(' ')
                .ToList();

            string input = Console.ReadLine();

            List<string> result = new List<string>();

            List<string> currentCollection = new List<string>();

            while (input != "Party!")
            {
                var commands = input.Split(' ').ToList();

                var doubleOrRemove = commands[0];
                var startsEdnLength = commands[1];
                var stringToSearch = commands[2];
                int lenght = 0;
                Int32.TryParse(stringToSearch, out lenght);

                if (doubleOrRemove == "Double")
                {
                    switch (startsEdnLength)
                    {
                        case "StartsWith":
                            currentCollection =
                                people
                                    .FindAll(x => x.IndexOf(
                                        stringToSearch) == 0 &&
                                        x.Length > stringToSearch.Length)
                                    .ToList();
                            foreach (var filtered in currentCollection)
                            {
                                people.Add(filtered);
                            }
                            break;

                        case "EndsWith":
                            currentCollection =
                                people
                                    .FindAll
                                    (x => x.IndexOf(stringToSearch) > 0)
                                    .ToList();
                            foreach (var filtered in currentCollection)
                            {
                                people.Add(filtered);
                            }
                            break;

                        case "Length":
                            currentCollection =
                                people
                                    .FindAll
                                    (x => x.Length == lenght)
                                    .ToList();
                            foreach (var filtered in currentCollection)
                            {
                                people.Add(filtered);
                            }
                            break;

                        default: return;
                    }
                }

                else if (doubleOrRemove == "Remove")
                {
                    switch (startsEdnLength)
                    {
                        case "StartsWith":
                            currentCollection =
                                people
                                    .FindAll(x => x.IndexOf
                                    (stringToSearch) == 0 &&
                                    x.Length > stringToSearch.Length)
                                    .OrderBy(x => x)
                                    .ToList();
                            foreach (var filtered in currentCollection)
                            {
                                people.Remove(filtered);
                            }
                            break;

                        case "EndsWith":
                            currentCollection =
                                people
                                    .FindAll
                                    (x => x.IndexOf(stringToSearch) > 0)
                                    .ToList();
                            foreach (var filtered in currentCollection)
                            {
                                people.Remove(filtered);
                            }
                            break;

                        case "Length":
                            currentCollection =
                                people
                                    .FindAll
                                    (x => x.Length == lenght)
                                    .ToList();
                            foreach (var filtered in currentCollection)
                            {
                                people.Remove(filtered);
                            }
                            break;


                        default: return;
                    }
                }
                input = Console.ReadLine();
            }


            List<string> ordered = people
                .OrderBy(x => x)
                .ToList();

            if (people.Count > 0)
            {
                Console.WriteLine(String.Join(", ", ordered) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }
    }
}
