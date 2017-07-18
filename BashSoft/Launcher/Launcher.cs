
using System;
using System.IO;

public static class Launcher
{
    static void Main()
    {
        //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
        //IOManager.TraverseDirectory(20);
        //StudentsRepository.InitializeData();
        //StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");
        //StudentsRepository.GetAllStudentsFromCourse("C#_advanced");
        //Tester.CompareContent(@"C:\Users\Nik\iCloudDrive\C# Advanced\BashSoft\FilesForTest\t1.txt",
        //@"C:\Users\Nik\iCloudDrive\C# Advanced\BashSoft\FilesForTest\t2.txt");// WORKING!  :)         
        //IOManager.CreateDirectoryInCurrentFolder("11");//working  
        //IOManager.TraverseDirectory(0);//working

       // IOManager.ChangeCurrentDirectoryRelative(".."); //may be working?

        IOManager.ChangeCurrentDirectoryAbsolute("c:\\Windows"); //may be working?
        IOManager.TraverseDirectory(20);
;


    }
}