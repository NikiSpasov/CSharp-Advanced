

namespace _01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;
    class UniqueUsernames
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string currentUsername = Console.ReadLine();
                usernames.Add(currentUsername);

            }
            foreach (var user in usernames)
            {
                Console.WriteLine(user);
            }
        }
    }
}
