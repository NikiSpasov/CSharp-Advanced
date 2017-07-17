namespace _05.Phonebook
{
    using System;
    using System.Collections.Generic;
    class Phonebook
    {
        static void Main()
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            string phoneNumber = "";
            string name = "";
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "search")
                {
                    while (true)
                    {
                        string searchedNames = Console.ReadLine();
                        if (searchedNames == "stop")
                        {
                            return;
                        }
                        if (phonebook.ContainsKey(searchedNames))
                        {
                            Console.WriteLine($"{searchedNames} -> {phonebook[searchedNames]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {searchedNames} does not exist.");
                        }
                    }
                }

                name = input[0];
                phoneNumber = input[1];

                if (!phonebook.ContainsKey(name))
                {
                    phonebook.Add(name, phoneNumber);
                }
                else
                {
                    phonebook[name] = phoneNumber;
                }
            }
        }
    }
}
