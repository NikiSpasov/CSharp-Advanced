using System.Runtime.InteropServices;

namespace _05.LabFilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class FilterByAge
    {

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> peopleAndAges = new Dictionary<string, int>();
            

            for (int i = 0; i < n; i++)
            {
                List<string> nameAge = Console.ReadLine()
               .Split(new string[] {", "},
               StringSplitOptions.RemoveEmptyEntries)
               .ToList();

                peopleAndAges.Add(nameAge[0], int.Parse(nameAge[1]));
            }

            string condition = Console.ReadLine();

            int ageForCondition = int.Parse(Console.ReadLine());

            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, ageForCondition);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);


            PrintFilteredPeople(peopleAndAges, tester, printer);
        }

        private static void PrintFilteredPeople(
            Dictionary<string, int> peopleAndAges, 
            Func<int, bool> tester, 
            Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in peopleAndAges)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        public static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x < age;
                case "older":
                    return x => x >= age;
                default: return null;
            }
        }

        public static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Key}");
                case "age":
                    return age => Console.WriteLine($"{age.Value}");
                case "name age":
                    return (personAge) => Console.WriteLine($"{personAge.Key} - {personAge.Value}");
                default: return null;

            }
        }
    }
}
