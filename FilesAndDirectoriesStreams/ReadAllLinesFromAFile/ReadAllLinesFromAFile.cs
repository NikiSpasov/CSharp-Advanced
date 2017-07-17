namespace ReadAllLinesFromAFile
{
    using System;
    using System.IO;

    class ReadAllLinesFromAFile
    {
        static void Main()
        {
            using (var reader = new StreamReader("../../ReadAllLinesFromAFile.cs"))
            {
                int number = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    number++;
                    Console.WriteLine($"Line{number}: {line}");
                    line = reader.ReadLine();
                }
            }
        }
    }
}
