namespace Writer2
{
    using System;
    using System.IO;

    public class WriterVer2
    {
        static void Main()
        {
            using (var reader = new StreamReader("../../WriteToAFileREversedVer2.cs"))
            {
                using (var writer = new StreamWriter("reversedVer2.txt"))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        for (int i = line.Length - 1; i >= 0; i--)
                        {
                            writer.Write(line[i]);
                        }
                        writer.WriteLine();
                        line = reader.ReadLine();
                    }
                }
            }

        }


    }
}
