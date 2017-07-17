

using System.Linq;

namespace _07.FixEmails
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Dictionary<string, string> personsAndEmails = new Dictionary<string, string>();
            string person = "";
            string[] email;

            for (int i = 1; i >= 1; i++)
            {

                person = Console.ReadLine();
                if (person == "stop")
                {
                    foreach (KeyValuePair<string, string> emailsAndPersons in personsAndEmails)
                    {
                        Console.WriteLine($"{emailsAndPersons.Key} -> {emailsAndPersons.Value}");
                    }
                    return;
                }
                string inputEmail = Console.ReadLine();
                email = inputEmail
                    .Split('.');
                if (email[1] != "us" && email[1] != "uk")
                {
                    personsAndEmails.Add(person, inputEmail);
                }

            }
        }
    }
}
