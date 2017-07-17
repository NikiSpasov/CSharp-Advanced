namespace _00.Regex
{
    using System.Text.RegularExpressions;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            // [A-Z] - всички главни букви;
            // [a-z] - всички малки букви;
            // със "/" стартира регекса;
            // [A-Z][a-z]+ 
            // \w - мачва всички БУКВИ в изречението;
            // \w+ мачва всички ДУМИ в изречението;
            // \d - намери всички цифри;
            // \d+ - намери всички числа;
            // /abc/ - намери къде има "abc"
            // НО /[abc]/ ще намери всичките а, b или c-та/;
            //[^abc] - намери всички, които НЕ СА a, b или c;
            //[^abc ][abcd] - намери всички, които НЕ СА a, b или c, 
            // след които да следват a, b, c или d.
            //[0-9] - намери всикчо в рейнджа от 0 до 9;
            // \w - всикчо от A-Z, a-z 0-9 и _;
            // \W всичко безот A-Z, a-z 0-9 и _; - обратното;
            // \d всички цифри;
            // \D всичко което не е цифра;
            // \s - намира всичко което е спейс; 
            // \S - намира всичко което НЕ Е спейс;
            // \w{3} = \w\w\w - търси където има комбинация от три букви;
            // \w{2, 4} - всички комбинации на букви, от 2 до 4 букви
            // \w{2,} - всички думи с минимум две букви

            //Как да валидираме телефонен номер във формата
            // 0 878 123-123:
            //\d\s\d{3}\s\d{3}-\d{3}
            //Ако искаме да приема и тирет и този да е валиден:

            //0 878 123 / 123

            //променяме ето така:
            // \d\s\d{ 3}\s\d{ 3} (-|\/)\d{ 3}, т.е. с "или тире" в скобите - (-|\/)


            // "A.*Z хвани ми главното А и свърши до Z, без значение дали има такива а и з по средата;
            // A.*?Z - хвани ми всички случаи между А и първото Z;


            //^ - да мачва в началото; ^(?:Hi|Hello),\s*(\w+)$ - тук ?: означава да не ми ги групираш
            //$ - да мачва в края;

            //като сложиш нещо в скоби - получава се група, като индекса започва с 1
            //напр. \d\s(\d{3})\s\d{6} - тук групата е (\d{3})

            //var text = "Text 123 text 456";

            //var regex = new Regex(@"(\w+)\s(\d+)");
            //var firstMatch = regex.Match(text);
            //Console.WriteLine(firstMatch);
            //var result = regex.IsMatch(text);
            //Console.WriteLine(result);//true, има d/цифри/ в текста;
            //var matches = regex.Matches(text);
            //Console.WriteLine(matches.Count); //6, t.e. имаме 6 цифри в текста;

            //GROUPS:         

            //foreach (Match match in matches)
            //{
            //    Console.WriteLine(match.Value);//1, 2, 3, 4, 5, 6
            //    Console.WriteLine(match.Groups[0]); //.Group[0] is always equal to .Value!
            //}




            //REPLACE:

            //var text = "Niki: 123, Kiro: 456";
            //string pattern = @"\d{3}";
            //Regex regex = new Regex(pattern);
            //string result = regex.Replace(text, replacement: "999");
            //Console.WriteLine(result);//Niki: 999, Kiro: 999

            //var text = @"<ul> <li> <a href=""http://softuni.bg"">SoftUni</a> </li > </ul>";
            //var regex = new Regex(@"<a.*href=(""|')(.*)\1>(.*?)<\/a>");
            //var matches = regex.Matches(text);

            //foreach (Match match in matches)
            //{
            //    Console.WriteLine(match.Groups[0]);
            //    Console.WriteLine(match.Groups[1]);
            //    Console.WriteLine(match.Groups[2]);
            //    Console.WriteLine(match.Groups[3]);
            //}

            //var result  = regex.Replace(text, @"[URL href=""$2""]$3[/URL]"); //tuk $2 zna4i vzemi stoinostta ot vtorata grupa.
            //Console.WriteLine(result); //<ul> <li> [URL href="http://softuni.bg"]SoftUni[/URL] </li > </ul>

            //SPLIT:

            //var text = "1     2                  4   5 6 7";
            //var regex = new Regex(@"\s+");
            //var result = regex
            //    .Split(text)
            //    .Select(int.Parse)
            //    .ToArray();
            //масив 124567
            //мачка спейсовете и налива.



            //SOME MORE PRACTICE:


            //string input = "24 June 2014";
            //Regex regex = new Regex(@"\d+");
            //var result = regex.Match(input);
            //Console.WriteLine($"resultIndex: {result.Index} resultLength: {result.Length}");

            ////Console.WriteLine(matches.Value);
            ////matches = matches.NextMatch();

            //var isMatch = regex.IsMatch(input);
            //Console.WriteLine(isMatch);//true

            //List<double> fromMatches = new List<double>();
            //MatchCollection maaaches = regex.Matches(input);
            //for (int i = 0; i < maaaches.Count; i++)
            //{
            //    //Console.Write(maaaches[i] + " ");
            //    double currentMatch = double.Parse(maaaches[i].ToString());
            //    fromMatches.Add(currentMatch);

            //    Console.WriteLine($"{maaaches[i]} has been added to collection!");
            //}
            //var smetkata = fromMatches.Sum();
            //Console.WriteLine(smetkata);

            //string replaced = regex.Replace(input, replacement: "99");
            //Console.WriteLine(replaced); //99 June 99

            string input = "#vankata";
            Regex regex = new Regex(@"\w+");
            var result = regex.Match(input);
            Console.WriteLine(result);
        }
    }
}