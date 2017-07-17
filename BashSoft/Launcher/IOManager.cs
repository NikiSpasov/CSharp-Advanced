using System;
using System.Collections.Generic;
using System.IO;
using static OutputWriter;

public static class IOManager
{
    public static void TraverseDirectory(string path)
    {
        int initialIdentation = path.Split('\\').Length;
        Queue<string> subFolders = new Queue<string>();
        subFolders.Enqueue(path);
        int identation = 0;
         
        WriteMessageOnNewLine(path);

        while (subFolders.Count != 0)
        {
            string currentPath = subFolders.Dequeue();
            identation = currentPath.Split('\\').Length - initialIdentation;
            path = currentPath;
            foreach (var dir in Directory.GetDirectories(currentPath))
            {
                WriteMessageOnNewLine(string.Format("-{0}{1}", new string('-', identation), dir));
                subFolders.Enqueue(dir);
            }   
        }
    }

}

