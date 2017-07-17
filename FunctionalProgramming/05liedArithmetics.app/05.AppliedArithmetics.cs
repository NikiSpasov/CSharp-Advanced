namespace _05.AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class AppliedArithmetics
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();

            Func<int, int> addOne = n => n + 1;
            Func<int, int> substractOne = n => n - 1;
            Func<int, int> multiPlyBy2 = n => n * 2;

            List<int> resultList = new List<int>();


            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(addOne).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(substractOne).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(multiPlyBy2).ToList();
                        break;
                    case "print":
                        Console.WriteLine(String.Join(" ", numbers));
                        break;
                    default:
                        Console.WriteLine("Wrong command!");
                        return; 
                        
                }
                command = Console.ReadLine();
            }
            
        }
    }
}
