
namespace _10.SimpleTextEditor
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    class SimpleTextEditor
    {
        static void Main()
        {
            int count = 0;
            string text = string.Empty;
            string textToRemove = string.Empty;
            StringBuilder myString = new StringBuilder();
            Stack<string> operationsInStack = new Stack<string>();
            Stack<string> textRemoved = new Stack<string>();
            Stack<int> start = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] currentInput = Console.ReadLine()
                    .Trim()
                    .Split(' ')
                    .ToArray();

                if (currentInput.Length > 1)
                {
                    text = currentInput[1];
                }

                string command = currentInput[0];

                switch (command)
                {
                    case "1":
                        myString.Append(text);
                        operationsInStack.Push(command);
                        int startindex = (myString.Length - text.Length);
                        start.Push(startindex);
                        count = text.Length;
                        break;

                    case "2":
                        operationsInStack.Push(command);
                        int charsToRemove = int.Parse(text);
                        textToRemove = myString
                            .ToString()
                            .Substring(myString.Length - charsToRemove, charsToRemove);

                        textRemoved.Push(textToRemove);

                        myString.Remove(myString.Length - charsToRemove, charsToRemove);
                        break;

                    case "3":
                        Console.WriteLine(myString[int.Parse(text) - 1]);
                        break;

                    case "4":
                        string oppToReverse = operationsInStack.Pop();
                        if (oppToReverse == "1")
                        {
                            myString.Remove(start.Pop(), count);

                        }
                        else if (oppToReverse == "2")
                        {
                            myString.Append(textRemoved.Pop());
                        }
                        break;
                }
            }
        }
    }
}
