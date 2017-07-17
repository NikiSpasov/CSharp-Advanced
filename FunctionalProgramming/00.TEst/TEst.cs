
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _00.TEst
{
    using System;

    class Test
    {
        static void Main()
        {
            string[] numbersAsAStrings = new[] {"1", "2", "3"};

            //пример за Lambda израз:
            List<int> numbers = numbersAsAStrings
                 .Select(n => int.Parse(n)) //тук;
                 .ToList();

            
            string msg = "123";

            //List<int> forTest = numbers.FindAll(x => x < 3); //1, 2

           
            // Action<int>



            //Func<int, int> myFunc = x => x + 1; //в скобие е първо какво приема, после какво връща;

            //Console.WriteLine(myAction(5));//6

            //Func<int> myFunc = () => 1 + 1; //в скобите на функцията последното е какво връща;
            //Console.WriteLine(myFunc());//2

            //Func<int, string> myFunc = n => n.ToString();
            //string result = myFunc(8);
            //Console.WriteLine(result);//8

            Action<int, int> myAction = (y, x) => Console.WriteLine(x + y);
            //myAction = Calc;
            //myAction += ReturnNumberAndSmileee;


            myAction(5, 6); //returns 6 /from Calc method and "5 Smileeee" 
            //from ReturnNumberAndSmilee method;
            //Action<T> can aggregate (only) named methods in it!
            //first (y, x) is NOT in myAction in this case.


        }

        //public static void Calc(int n, int y)
        //{
        //    Console.WriteLine(n + y);
        //}

        //public static void ReturnNumberAndSmileee (int n, int y)
        //{
        //    string str = n.ToString();
        //    string str2 = y.ToString();
        //    Console.WriteLine(n + " Smileeee" + y);
        //}

    }
}
