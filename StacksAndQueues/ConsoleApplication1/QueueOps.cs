
namespace _04.BasicQueueOps
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    class QueueOps
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsToEnqueue = input[0];
            int elementsToDequeue = input[1];
            int elementToCheck = input[2];


            Queue<int> myQueue = new Queue<int>();

            int[] numbers = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            foreach (var number in numbers)
            {
                myQueue.Enqueue(number);
            }
            
            for (int i = 0; i < elementsToDequeue; i++)
            {
                myQueue.Dequeue();
            }
            if (elementsToEnqueue == elementsToDequeue)
            {
                Console.WriteLine("0");
                return;
            }
            if (myQueue.Contains(elementToCheck))
            {
                Console.WriteLine("true");
                return;
            }
            else
            {
                int min = 0;


                while (myQueue.Count != 0)
                {
                    min = int.MaxValue;
                    int currentNum = myQueue.Dequeue();
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
