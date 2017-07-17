using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FormattingNumbers
{
    class FormatingNums
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine()
                .Split(new []{" ", "/r/n", "/n", "\t"}, 
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            long firstNum = long.Parse(numbers[0]);
            decimal secondNum = decimal.Parse(numbers[1]);
            decimal thirdNumber = decimal.Parse(numbers[2]);

            string firstNumToBinary = Convert.ToString(firstNum, 2).PadLeft(10, '0');
            string firstNumToHex = firstNum.ToString("X");
        
            Console.WriteLine(string.Format("|{0,-10}|{1, 10}|{2,10:f2}|{3, -10:f3}|",
                firstNumToHex, firstNumToBinary, secondNum, thirdNumber));

        }
    }
}
