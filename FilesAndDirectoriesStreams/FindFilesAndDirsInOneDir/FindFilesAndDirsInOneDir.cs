

namespace FindFilesAndDirsInOneDir
{
    using System;
    using System.IO;

    class FindFilesAndDirsInOneDir
    {
        static void Main()
        {
            if (Directory.Exists("MainDir"))
            {
            Directory.Delete("MainDir", true);
            }
            Directory.CreateDirectory("MainDir");
            File.WriteAllText("MainDir/test1.txt", "111");
            File.WriteAllText("MainDir/test2.txt", "222");
            Directory.CreateDirectory("MainDir/SecondDir");
            File.WriteAllText("MainDir/SecondDir/test3.txt", "333");
            File.WriteAllText("MainDir/SecondDir/test4.txt", "444");

            Directory.CreateDirectory("MainDir/SecondDir/ThirdDir");
            File.WriteAllText("MainDir/SecondDir/ThirdDir/test5.txt", "555");
            File.WriteAllText("MainDir/SecondDir/ThirdDir/test6.txt", "666");

            CountDirsAndFiles("MainDir");


        }

        public static void CountDirsAndFiles(string directory)
        {
            Console.WriteLine($"--{directory}--");

            string[] allFiles = Directory.GetFiles(directory);

            foreach (var files in allFiles)
            {
                Console.WriteLine(files);
            }

            var allDirs = Directory.GetDirectories(directory);

            foreach (var dir in allDirs)
            {
                CountDirsAndFiles(dir);
            }
        }
    }
}
