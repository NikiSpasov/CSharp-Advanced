using System;
using System.IO;

public static class Tester
{
    public static void CompareContent(string userOutputPath, string expectedOutputPath)
    {
        OutputWriter.WriteMessageOnNewLine("Reading files...");

        string mismachPath = GetMismatchPath(expectedOutputPath);

        string[] actualOutputLines = File.ReadAllLines(userOutputPath);

        string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

        bool hasMismatch;

        string[] mismatches = GetLineWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);

        PrintOutput(mismatches, hasMismatch, mismachPath);
        OutputWriter.WriteMessageOnNewLine("Files read!");

    }

    private static void PrintOutput(string[] mismatches, bool hasMismatch, string mismachesPath)
    {
        if (hasMismatch)
        {
            foreach (var line in mismatches)
            {
                OutputWriter.WriteMessageOnNewLine(line);
            }
            File.WriteAllLines(mismachesPath, mismatches);
            return;
        }
        OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
    }

    private static string[] GetLineWithPossibleMismatches
        (string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
    {
        hasMismatch = false;
        string output = string.Empty;
        string[] mismatches = new string[actualOutputLines.Length];
        OutputWriter.WriteMessageOnNewLine("Comparing files...");

        for (int index = 0; index < actualOutputLines.Length; index++)
        {
            string actualLine = actualOutputLines[index];
            string expectedLine = expectedOutputLines[index];
            if (!actualLine.Equals(expectedLine))
            {
                output = $"Mismatch at line{index} -- expected: \"{expectedLine}\", " + $"actual: \"{actualLine}\"";
                output += Environment.NewLine;
                hasMismatch = true;

            }
            else
            {
                output = actualLine;
                output += Environment.NewLine;
            }
            mismatches[index] = output;
        }
        return mismatches;

    }

    public static string GetMismatchPath(string expectedOutputPath)
    {
        int indexOf = expectedOutputPath.LastIndexOf('\\');
        string directoryPath = expectedOutputPath.Substring(0, indexOf);
        string finalPath = directoryPath + @"\Mismatches.txt";
        return finalPath;
    }

}