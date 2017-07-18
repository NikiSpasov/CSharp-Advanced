using System;
using System.IO;

public static class Tester
{
    public static void CompareContent(string userOutputPath, string expectedOutputPath)
    {
        OutputWriter.WriteMessageOnNewLine("Reading files...");

        try
        {
            string mismachPath = GetMismatchPath(expectedOutputPath);

            string[] actualOutputLines = File.ReadAllLines(userOutputPath);

            string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

            bool hasMismatch;

            string[] mismatches = GetLineWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);

            PrintOutput(mismatches, hasMismatch, mismachPath);
            OutputWriter.WriteMessageOnNewLine("Files read!");
        }
        catch (FileNotFoundException)
        {
            OutputWriter.DisplayException(ExeptionMessages.InvalidPath);
        }
    }

    private static void PrintOutput(string[] mismatches, bool hasMismatch, string mismachesPath)
    {
        if (hasMismatch)
        {
            foreach (var line in mismatches)
            {
                OutputWriter.WriteMessageOnNewLine(line);
            }
            try
            {
                File.WriteAllLines(mismachesPath, mismatches);

            }
            catch (DirectoryNotFoundException)
            {
               OutputWriter.DisplayException(ExeptionMessages.InvalidPath);
            }
            return;
        }
        OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
    }

    private static string[] GetLineWithPossibleMismatches
        (string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
    {
        hasMismatch = false;
        string output = string.Empty;
        OutputWriter.WriteMessageOnNewLine("Comparing files...");
        int minOutputLines = actualOutputLines.Length;

        if (actualOutputLines.Length != expectedOutputLines.Length)
        {
            hasMismatch = true;
            minOutputLines = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
            OutputWriter.DisplayException(ExeptionMessages.ComparisonOfFilesWithDifferentSizes);
        }
        string[] mismatches = new string[minOutputLines];



        for (int index = 0; index < minOutputLines; index++)
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