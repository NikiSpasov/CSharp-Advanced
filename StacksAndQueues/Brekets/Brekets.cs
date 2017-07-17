

using System.Collections.Generic;

namespace Brekets
{
    using System;

    class Brekets
    {
        static void Main()
        {
            string expression = "((2 + 3) - 15 + 34 - (4,4 * (2+3)))";

            Stack<int> myFirstSt = new Stack<int>();


            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];
                if (ch == '(')
                {
                    myFirstSt.Push(i);
                }
                else if (ch == ')')
                {
                    int startIndex = myFirstSt.Pop();
                    int lenght = i - startIndex;
                    string contents = expression.Substring(startIndex, lenght+1);

                    Console.WriteLine(contents);
                }
            }
            //Console.WriteLine(expression[2]);
        }
    }
}
