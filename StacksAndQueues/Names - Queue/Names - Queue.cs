

using System.Collections.Generic;
using System.Linq;

namespace Names___Queue
{
    using System;
    class Queue
    {
        static void Main()
        {
            Queue<string> myFirstQueue = new Queue<string>();
            myFirstQueue.Enqueue("Ivan");
            myFirstQueue.Enqueue("Dragan");
            myFirstQueue.Enqueue("Petkan");
            myFirstQueue.Enqueue("Minka");


            Console.WriteLine(myFirstQueue.ElementAt(0));

            while (myFirstQueue.Count > 0)
            {
                string name = myFirstQueue.Dequeue();
                Console.WriteLine(name);
            }
        }
    }
}
