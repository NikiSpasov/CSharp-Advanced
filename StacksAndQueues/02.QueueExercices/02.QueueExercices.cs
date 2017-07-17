

using System;

namespace _02.QueueExercices
{
    using System.Collections.Generic;

    class Queue
    {
        static void Main()
        {
            Queue<string> texts = new Queue<string>();
            texts.Enqueue("First");
            texts.Enqueue("Second");
            texts.Enqueue("Third");


            string currentText = texts.Peek();
            Console.WriteLine(currentText);

            string fistElement = texts.Dequeue();
            Console.WriteLine(fistElement);
        }
    }
}
