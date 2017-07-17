using System.Linq;

namespace ReadAllLinesFromAFile
{
    using System;
    using System.IO;

    class ReadAllLinesFromAFile
    {
        static void Main()
        {
            using (var reader = new StreamReader("../../WriteToAFileReversed.cs"))
            {
                int number = 0;
                string currentLine = reader.ReadLine();

                using (StreamWriter writer = new StreamWriter("reversed.txt"))
                {
                    while (currentLine != null)
                    {
                        var reversed = currentLine.ToCharArray();
                        var rev = new string(reversed.Reverse().ToArray());
                        writer.WriteLine(rev);
                        currentLine = reader.ReadLine();

                    }
                }

                    
            }
        }
    }
}
