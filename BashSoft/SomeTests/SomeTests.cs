using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeTests
{
    class SomeTests
    {
        static void Main(string[] args)
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
