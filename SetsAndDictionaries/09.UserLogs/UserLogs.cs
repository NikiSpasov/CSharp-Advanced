namespace _09.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class UserLogs
    {
        static void Main()
        {
            string input = Console.ReadLine();
            SortedDictionary<string, Dictionary<string, int>> usersAndIPs = new SortedDictionary<string, Dictionary<string, int>>();


            while (input != "end")
            {
                string[] text = input.Trim()
                    .Split(new []{'=', ' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string user = text[5];
                string currentIP = text[1];



                Dictionary<string, int> IP = new Dictionary<string, int>();

                if (!usersAndIPs.ContainsKey(user))
                {
                    IP.Add(currentIP, 1);
                    usersAndIPs.Add(user, IP);
                }
                else
                {
                    if (usersAndIPs[user].ContainsKey(currentIP))
                    {
                        usersAndIPs[user][currentIP] += 1;
                    }
                    else
                    {
                        usersAndIPs[user].Add(currentIP, 1);
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var ipCount in usersAndIPs)
            {
                Console.WriteLine($"{ipCount.Key}: ");

                var result = String.Join(", ", usersAndIPs[ipCount.Key].Select(kvp =>
                    String.Format("{0} => {1}", kvp.Key, kvp.Value)));

                Console.WriteLine(result + ".");
                
            }
        }
    }
}


//YES YES YES!!!!!

