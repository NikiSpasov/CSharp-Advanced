using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<ulong> fibNumbers = new Stack<ulong> {};
            fibNumbers.Push(1);
            fibNumbers.Push(1);

            for (int i = 1; i < n; i++)
            {
                ulong first = fibNumbers.Pop();
                ulong second = fibNumbers.Pop();

                fibNumbers.Push(first);
                fibNumbers.Push(first + second);
            }

            fibNumbers.Pop();
            Console.WriteLine(fibNumbers.Peek());
        }
    }
}
