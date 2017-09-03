using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class JediMeditation
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<string> toshkoISim4o = new List<string>();
        List<string> masters = new List<string>();
        List<string> knight = new List<string>();
        List<string> padawans = new List<string>();
        bool ordered = false;


        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split();

            foreach (var jedi in tokens)
            {
                if (jedi[0] == 'y')
                {
                    ordered = true;
                }
                if (jedi[0] == 't' || jedi[0] == 's')
                {
                    toshkoISim4o.Add(jedi);
                }
                if (jedi[0] == 'p')
                {
                    padawans.Add(jedi);
                }
                if (jedi[0] == 'k')
                {
                    knight.Add(jedi);
                }
                if (jedi[0] == 'm')
                {
                    masters.Add(jedi);
                }
            }
        }

        StringBuilder sb = new StringBuilder();
        if (ordered)
        {
            foreach (var master in masters)
            {
                sb.Append(master + " ");
            }
            foreach (var knght in knight)
            {
                sb.Append(knght + " ");
            }
            foreach (var ourGuys in toshkoISim4o)
            {
                sb.Append(ourGuys + " ");
            }
            foreach (var padawan in padawans)
            {
                sb.Append(padawan + " ");
            }

            Console.WriteLine(sb.ToString().Trim());
            
        }
        else
        {
            foreach (var ourGuys in toshkoISim4o)
            {
                sb.Append(ourGuys + " ");
            }
            foreach (var master in masters)
            {
                sb.Append(master + " ");
            }
            foreach (var knght in knight)
            {
                sb.Append(knght + " ");
            }
            foreach (var padawan in padawans)
            {
                sb.Append(padawan + " ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
