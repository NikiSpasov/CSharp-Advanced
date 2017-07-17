
using System;

public static class Launcher
{
    static void Main()
    {
        //IOManager.TraverseDirectory(@"C:\Users\Nik\iCloudDrive\C# Advanced");
        StudentsRepository.InitializeData();
        StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");
        StudentsRepository.GetAllStudentsFromCourse("C#_advanced");
        //Tester.CompareContent(@"C:\Users\Niki\iCloudDrive\C# Advanced\BashSoft\Launcher\test2.txt",
       //     @"C:\Users\Niki\iCloudDrive\C# Advanced\BashSoft\Launcher\test3.txt");                                                           

    }
}