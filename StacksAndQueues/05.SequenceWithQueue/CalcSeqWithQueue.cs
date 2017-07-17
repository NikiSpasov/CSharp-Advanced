namespace _05.SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CalcSeqWithQueue
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            Queue<long> elementsInSequence = new Queue<long>();
            var result = new List<long>();
            elementsInSequence.Enqueue(n);
            result.Add(n);

            while (result.Count < 50)
            {
                long currentElement = elementsInSequence.Dequeue();
                long firstNumber = currentElement + 1;
                long secondNumber = (currentElement * 2) + 1;
                long thirdNumber = currentElement + 2;

                elementsInSequence.Enqueue(firstNumber);
                elementsInSequence.Enqueue(secondNumber);
                elementsInSequence.Enqueue(thirdNumber);

                result.Add(firstNumber);
                result.Add(secondNumber);
                result.Add(thirdNumber);
            }

            Console.WriteLine(string.Join(" ", result.Take(50)));

        }

    }
}
