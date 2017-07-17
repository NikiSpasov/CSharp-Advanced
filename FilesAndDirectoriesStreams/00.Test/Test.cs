

namespace _00.Test
{
    using System;
    using System.IO;
    class Test
    {
        static void Main()
        {
            
            //Console.WriteLine(File.Exists("asdd"));

            //File.Copy("numbers.txt", "../another.txt", true);

            string numbers = File.ReadAllText("numbers.txt");// returns all text in a
            //single string variable;

            string[] textInLines = File.ReadAllLines("numbers.txt"); //returns array with 
            //lines - every line from the text is an index of this array;

            string text = File.ReadAllText("numbers.txt");

           // Console.WriteLine(numbers);
            //File.Move("numbers.txt", "abv.txt");

            File.WriteAllText("kume.txt", "davai kumeeeeee"); //gets the text and put it in 
            //a new file "kume.txt". No need to create the file before that.

            File.WriteAllLines("textFromArray.txt", textInLines);//gets every index from the array and put in
                                                                 //the ****.txt file

            // STREAMS (also in .IO class) 

            using (var reader = new StreamReader("numbers.txt"))
            {
                string currentLine = reader.ReadLine();
                Console.WriteLine(currentLine); //1 2 3 4 5
            }

            Path.GetFileNameWithoutExtension("numbers.txt");


            //Directories

            Directory.CreateDirectory("test/Niki/Lili/Gosho");
            //Directory.Delete("test"); //only if dir is empty!
            //Directory.Move("test", "gosho");
            var directories = Directory.GetDirectories("test");



        }
    }
}
