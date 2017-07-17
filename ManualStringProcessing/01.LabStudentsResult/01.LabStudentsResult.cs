namespace _01.LabStudentsResult
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class StudentsResult
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            Console.WriteLine($"Name".PadRight(10) + "|"
                              + "CAdv".PadLeft(7) + "|"
                              + "COOP".PadLeft(7) + "|"
                              + "AdvOOP".PadLeft(7) + "|"
                              + "Average" + "|"
            );

            for (int i = 0; i < n; i++)
            {
                string[] splittedInput = input
                    .Split(new[] {'-', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = splittedInput[0];
                double cAdv = double.Parse(splittedInput[1]);
                double cOOP = double.Parse(splittedInput[2]);
                double advOOP = double.Parse(splittedInput[3]);
                double avg = (cAdv + cOOP + advOOP) / 3.0;
                
                Console.WriteLine(string.Format("{0,-10}|{1, 7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|",
                    name, cAdv, cOOP, advOOP, avg));

                input = Console.ReadLine();

            }
        }
    }
}
