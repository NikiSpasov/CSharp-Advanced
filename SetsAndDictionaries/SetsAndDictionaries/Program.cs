using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetsAndDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> testDict = new Dictionary<string, int>();
            testDict.Add("2C", 15);

            bool isIn = testDict.ContainsKey("2C");//true
            //Console.WriteLine(isIn);


            string card = "10S";
            string cardValue = card[0].ToString();
            string colour = card[card.Length - 1].ToString();
            Console.WriteLine(cardValue + " " + colour);


        }
    }
}