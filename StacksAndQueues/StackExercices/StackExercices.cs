namespace StackExercices
{
    using System;
    using System.Collections.Generic;
    public class StackExercices
    {
        public static void Main()
        {
            Stack<int> numbers = new Stack<int>();

            numbers.Push(5);
            numbers.Push(9);
            numbers.Push(123);


            int currentNumber = numbers.Peek();//123
            Console.WriteLine(currentNumber);

            int lastNumber = numbers.Pop();
            Console.WriteLine(lastNumber);
            currentNumber = numbers.Peek();
            Console.WriteLine(currentNumber);

            bool hasEleven = numbers.Contains(11);
            bool hasNine = numbers.Contains(9);
            Console.WriteLine($"Stack has 11: {hasEleven}");
            Console.WriteLine($"Stack has 9: {hasNine}");

        }
    }
}
