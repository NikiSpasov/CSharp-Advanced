namespace _03.LabParseTags
{
    using System;
    class ParseTags
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string openingTag = "<upcase>";
            string closingTag = "</upcase>";

            int start = text.IndexOf(openingTag);

            while (start != -1)
            {
                int end = text.IndexOf(closingTag, start);
                if (end > -1)
                {
                    string textToBeReplaced = text.Substring(start, end + closingTag.Length - start);
                    text = text.Replace(textToBeReplaced, 
                        text.Substring(start + openingTag.Length, 
                        end - start - openingTag.Length)
                        .ToUpper());
                    start = text.IndexOf(openingTag, start + 1);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(text);
        }
    }
}
