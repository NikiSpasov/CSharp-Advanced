using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters;

public static class StudentsRepository
{
    public static bool isDataIntitialized = false;
    private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

    public static void InitializeData()
    {
        if (!isDataIntitialized)
        {
            OutputWriter.WriteMessageOnNewLine("Reading data...");
            studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            ReadData();
        }
        else
        {
            OutputWriter.DisplayException(ExeptionMessages.DataAlreadyInitialisedException);
        }
    }

    public static void ReadData()
    {

        string input = Console.ReadLine();
        while (!string.IsNullOrEmpty(input))
        {
            string[] tokens = input.Split(new[] { ' ', ',', '\r', '\n', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            string course = tokens[0];
            string student = tokens[1];
            int mark = int.Parse(tokens[2]);

            if (!studentsByCourse.ContainsKey(course))
            {
                studentsByCourse.Add(course, new Dictionary<string, List<int>>());
            }
            if (!studentsByCourse[course].ContainsKey(student))
            {
                studentsByCourse[course].Add(student, new List<int>());
            }
            studentsByCourse[course][student].Add(mark);
            input = Console.ReadLine();

        }
        isDataIntitialized = true;
        OutputWriter.DisplayException("Data read!");
    }

    private static bool IsQueryForCoursePossible(string courseName)
    {
        if (!isDataIntitialized)
        {
            OutputWriter.DisplayException(ExeptionMessages.DataNotInitializedExceptionMessage);
            return false;
        }

        if (studentsByCourse.ContainsKey(courseName))
        {
            return true;
        }

        OutputWriter.DisplayException(ExeptionMessages.InexistingCourseInDataBase);

        return false;

    }

    private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
    {
        if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
        {
            return true;
        }

            OutputWriter.DisplayException(ExeptionMessages.InexistingStudentInDataBase);
        
        return false;

    }

    public static void GetStudentScoresFromCourse(string courseName, string userName)
    {
        if (IsQueryForStudentPossible(courseName, userName))
        {
            OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(userName, studentsByCourse[courseName][userName]));
        }
    }

    public static void GetAllStudentsFromCourse(string courseName)
    {
        if (IsQueryForCoursePossible(courseName))
        {
            OutputWriter.WriteMessageOnNewLine($"{courseName}");
            foreach (var studentMarksEntry in studentsByCourse[courseName])
            {
                OutputWriter.PrintStudent(studentMarksEntry);
            }
        }
    }
}





