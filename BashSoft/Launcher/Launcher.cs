
using System;

public static class Launcher
{
    static void Main()
    {
        //StudentsRepository.InitializeData();
        //StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");
        //StudentsRepository.GetAllStudentsFromCourse("C#_advanced");
        Tester.CompareContent(@"C:\Users\Niki\iCloudDrive\C# Advanced\BashSoft\Launcher\test2.txt",
            @"C:\Users\Niki\iCloudDrive\C# Advanced\BashSoft\Launcher\test3.txt");                                                           

    }
}