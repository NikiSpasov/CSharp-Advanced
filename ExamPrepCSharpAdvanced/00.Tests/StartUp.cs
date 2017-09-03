using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        Queue<int> intsForTest = new Queue<int>();
        intsForTest.Enqueue(1);

        var secondIntForTest = intsForTest.Dequeue();
        secondIntForTest = 15;

        intsForTest.Enqueue(secondIntForTest);



        int peaked = intsForTest.Peek();
        peaked = 4;

        for (int i = 0; i < intsForTest.Count; i++)
        {
            Console.WriteLine(intsForTest.Dequeue());
        }

    }
}

