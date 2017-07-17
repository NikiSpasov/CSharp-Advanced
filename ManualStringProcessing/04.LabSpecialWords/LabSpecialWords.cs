namespace _04.LabSpecialWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class LabSpecialWords
    {
        static void Main()
        {
            List<string> specialWords = Console.ReadLine()
                .Trim()
                .Split(new[] { ',', ')', '(', '}', '{', '[', ']', '<', '>', '-', '!', '?', ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            List<string> text = Console.ReadLine()
            .Trim()
            .Split(new[] { ',', ')', '(', '}', '{', '[', ']', '<', '>', '-', '!', '?', ' ' },
            StringSplitOptions.RemoveEmptyEntries)
            .ToList();

            Dictionary<string, int> wordsAndCount = new Dictionary<string, int>();

            foreach (var word in specialWords)
            {
                wordsAndCount.Add(word, 0);

                if (text.Contains(word))
                {
                    while (text.Contains(word))
                    {
                        wordsAndCount[word] += 1;
                        int indexToRemove = text.IndexOf(word);
                        text.RemoveAt(indexToRemove);
                    }              
                }                                
            }
            foreach (var kvp in wordsAndCount)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }

        }
    }
}
