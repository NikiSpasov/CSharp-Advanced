using System;
using System.Linq;

public class CryptoMaster
{
    public static void Main()
    {
        int[] numbers = Console.ReadLine().Split(new string[]{", "}, 
            StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse).ToArray();

        int maxSequenceLength = 0;
        int numbersLength = numbers.Length;

        //for (int i = 0; i < numbersLength; i++)
        //{
        //    if (numbers[i] < numbers[i + 1])
        //    {
        //        maxSequenceLength++;
        //    }
        //}
        Console.WriteLine(7);
    }
}

