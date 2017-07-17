using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeTests
{
    public class SomeTests
    {
        static void Main()
        {

        }
        public static void ReadNextLine(string fileName)
        {
            var lines = File.ReadLines("data.txt");

            string currentLine = lines.Skip().First();
            LastLineNumber++;
        }
    }
}
