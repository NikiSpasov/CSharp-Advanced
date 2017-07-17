using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class TEST
    {
        static void Main(string[] args)
        {
            string text =
                "[aаdSd[[asdasd<4REGEH22>asdosy] ***oopprefs[ew<16REGEH30>rdtr]ppp555b[tU<1REGEH15>s]trneti!t[dsaf<3REGEH1>fdwss]";
            int textLen = text.Length;
            Console.WriteLine(text[4].ToString() + text[26].ToString() + text[42].ToString() + text[72].ToString() + text[73].ToString() + text[88].ToString() + text[91].ToString() + text[92].ToString());
        }
    }
}
