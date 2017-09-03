using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class JediDream

{
    public static void Main()
    {
        // Regex staticMethodRegex = new Regex(@"[A-Za-z]+ ([A-Z][A-Za-z]+)");

        Dictionary<string, List<string>> methodMethods = new Dictionary<string, List<string>>();

        Regex methodRegex = new Regex(@"[A-Z][a-zA-Z]+\(");

        Regex staticFilter = new Regex(@"static");

        Regex methodName = new Regex(@"[A-Z][a-z|A-Z|\d]+");

        int n = int.Parse(Console.ReadLine());

        string input = Console.ReadLine();

        string currentMethodName = string.Empty;

        List<string> nameOfMethod = new List<string>();

        for (int i = 0; i < n; i++)
        {
            MatchCollection wholeMethod = methodRegex.Matches(input);

            foreach (Match match in wholeMethod)
            {
                if (match.Value != "")
                {
                    nameOfMethod.Add(methodName.Match(match.Value).Value);
                }
            }

            if (nameOfMethod.Count == 0)
            {
                input = Console.ReadLine();
                continue;
            }

            if (staticFilter.IsMatch(input))
            {
                {
                    methodMethods.Add(nameOfMethod[0], new List<string>());
                    currentMethodName = nameOfMethod[0];
                    input = Console.ReadLine();
                    nameOfMethod.Clear();
                    continue;
                }
            }
            foreach (var method in nameOfMethod)
            {
                methodMethods[currentMethodName].Add(method);
            }
            nameOfMethod.Clear();

            if (i != n - 1)
            {
                input = Console.ReadLine();
            }
        }

        foreach (var methodMeth in methodMethods.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
        {
            Console.WriteLine(methodMeth.Key + " -> " + methodMeth.Value.Count +  " -> " + string.Join(", ", methodMeth.Value.OrderBy(x => x)));
        }
    }
}



