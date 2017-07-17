namespace _01.LabSortEvenNumbers
{
    using System;
    using System.Linq;
    class SortEenNums
    {
        static void Main(string[] args)
        {


            Console.WriteLine(String.Join(", ",
                Console.ReadLine()
                    .Split(new string[] { " ,", " ", ",", "\r\n", "\t", "\n" },
                        StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .Where(k => k % 2 == 0)
                    .OrderBy(n => n)
                    .ToList()));
        }
    }
}
