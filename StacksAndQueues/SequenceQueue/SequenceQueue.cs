using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace SequenceQueue
{
    class PriorityQueue<T> where T:IComparable<T>
    {
        private OrderedBag<T> bag;
        static void Main()
        {
            int n = 3, p = 16;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            int index = 0;
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                if (current == p)
                {
                    Console.WriteLine("Index = {0}", index);
                    return;
                }
                index++;
                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current);
            }
        }
    }
}
