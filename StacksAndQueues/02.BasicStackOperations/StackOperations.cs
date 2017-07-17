namespace _02.BasicStackOperations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class StackOperations
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Trim()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsToPush = input[0];
            int elementsToPop = input[1];
            int elementToCheck = input[2];

            Stack<int> myStack = new Stack<int>();

            int[] numbers = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            foreach (var number in numbers)
            {
                myStack.Push(number);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                myStack.Pop();
            }
            if (elementsToPush == elementsToPop)
            {
                Console.WriteLine("0");
                return;
            }
            else if (myStack.Contains(elementToCheck))
            {
                Console.WriteLine("true");
                return;
            }
            else
            {
                int min = int.MaxValue;


                while (myStack.Count != 0)
                {
                    int currentNum = myStack.Pop();
                    if (currentNum < min)
                    {
                        min = currentNum;
                    }
                }
                Console.WriteLine(min);
            }
        }
    }
}
