using System;
using System.Collections.Generic;
using System.IO;
using static OutputWriter;

public static class IOManager
{
    public static void TraverseDirectory(int depth)
    {
        OutputWriter.WriteEmptyLine();
        int initialIdentation = SessionData.currentPath.Split('\\').Length;

        Queue<string> subFolders = new Queue<string>();
        subFolders.Enqueue(SessionData.currentPath);
        int identation = 0;


        WriteMessageOnNewLine(SessionData.currentPath);

        while (subFolders.Count != 0)
        {
            string currentPath = subFolders.Dequeue();
            identation = currentPath.Split('\\').Length - initialIdentation;
            if (depth - identation < 0)
            {
                break;
            }
            SessionData.currentPath = currentPath;
            try
            {
                foreach (var dir in Directory.GetDirectories(currentPath))
                {

                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf('\\');
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                    }
                    WriteMessageOnNewLine(string.Format("-{0}{1}", new string('-', identation), dir));


                    subFolders.Enqueue(dir);
                }

            }
            catch (UnauthorizedAccessException)
            {
                OutputWriter.DisplayException(ExeptionMessages.UnauthorizedAccessExeptionMessage);
            }
        }
    }


    public static void CreateDirectoryInCurrentFolder(string name)
    {
        string path = Directory.GetCurrentDirectory() + "\\" + name;

        try
        {
            Directory.CreateDirectory(path);
        }
        catch (ArgumentException)
        {
            OutputWriter.DisplayException(ExeptionMessages.ForbiddenSymbolsContainedInName);
        }
        
    }

    public static void ChangeCurrentDirectoryRelative(string relativePath)
    {
        if (relativePath == "..")
        {
            try
            {
                string currentPath = SessionData.currentPath;
                int indexOfLastSlash = currentPath.LastIndexOf('\\');
                string newPath = currentPath.Substring(0, indexOfLastSlash);
                SessionData.currentPath = newPath;
            }
            catch (ArgumentOutOfRangeException)
            {
                OutputWriter.DisplayException(ExeptionMessages.UnableToGoHigherInPartitionHierarchy);
            }
            
        }
        else
        {
            string currentPath = SessionData.currentPath;
            currentPath += '\\' + relativePath;
            ChangeCurrentDirectoryAbsolute(currentPath);
        }

    }

    public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
    {
        if (!Directory.Exists(absolutePath))
        {
            OutputWriter.DisplayException(ExeptionMessages.InvalidPath);
            return;
        }
        SessionData.currentPath = absolutePath;
    }
}

