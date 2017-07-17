using System.Runtime.InteropServices;

namespace _04.CountSymbols

{
    using System;
    using System.Collections.Generic;

    class Symbols
    {
        static void Main()
        {
            var inputText = Console.ReadLine().ToCharArray();

            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();

            foreach (var sign in inputText)
            {
                if (!chars.ContainsKey(sign))
                {
                    chars.Add(sign, 1);
                }
                else
                {
                    chars[sign]++;
                }
            }
            foreach (KeyValuePair<char, int> charsAndCount  in chars)
            {
                Console.WriteLine($"{charsAndCount.Key}: {charsAndCount.Value} time/s");
            }

        }
    }
}
