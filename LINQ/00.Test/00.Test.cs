
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _00.Test
{
    public class Test
    {
        public static void Main()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> numbers2 = new List<int> { 2, 7, 6, 6, 7, 4, 2, 1, 3, 11 };


            List<string> someStrings = new List<string> { "Ivan", "Pesho", "Gosho", "Samko", "Epatoa" };

            List<Cat> cats = new List<Cat>
            {
                new Cat()
                {
                    Age = 3,
                    Name = "Miauuu",
                    Color = "Grey",
                    CourseId = "Miau",
                    MonthsForCourse = 2
                },

                new Cat()
                {
                    Age = 4,
                    Name = "Miauuu",
                    Color = "White",
                    CourseId = "Miau",
                    MonthsForCourse = 2
                },
                new Cat()
                {
                    Age = 1,
                    Name = "Miauuu",
                    Color = "White",
                    CourseId = "Murr",
                    MonthsForCourse = 3
                },

                new Cat()
                {
                    Age = 5,
                    Name = "Mury",
                    Color = "Blue",
                    CourseId = "Murr",
                    MonthsForCourse = 3
            }
            };

            List<School> school = new List<School>
            {
                new School
                {
                    course = "MuurMiau",
                    months = 2
                },

                new School
                {
                course = "MuurMi",
                 months = 3
                }

            };

            //Where, Select, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefaul

            List<int> sortedNums = numbers
                .Where(x => x > 3 && x < 9) //филтрира всички елементи, които са над 3 и по-малки от 9
                .Select(x => x + 1)//добавя към всеки един + 1
                .ToList();//и ги слага в листа.
                          //резултатът ще е 
                          //5, 6, 7, 8, 9, защото взима първо 4-та, след което добавя 1 и 5 отива в листа и т.н


            //!!!! В Н И М А Н И Е !!!!!
            //забележи същото, но с обърнат ред на Select / Where

            List<int> sortedNums2 = numbers
                .Select(x => x + 1)//добавя към всеки един + 1
                .Where(x => x > 3 && x < 9) //филтрира всички елементи, които са над 3 и по-малки от 9
                .ToList();
            //резултатът ще е 
            //4, 5, 6, 7, 8
            //защото първо добавя цифрите, а след това е филтъра за над 3 и под 9 

            //foreach (var num in sortedNums2)
            //{
            //    Console.WriteLine(num);
            //}



            //var resultFromFirstOrDefault = numbers.FirstOrDefault(x => x == 3);//ще върне 3;
            //var resultFromFirstOrDefault2 = numbers.FirstOrDefault(x => x == 1000);//ще върне 0 - дифоултната стойност на int, за това е orDefault
            //var resultFromFirst = numbers.First(x => x == 3);//ще върне 3;
            //var resultFromFirst2 = numbers.First(x => x == 1000);//ще ГРЪМНЕ!

            //СЪЩОТО Е И ЗА:

            //numbers.Last();
            //numbers.LastOrDefault()

            //ПРИ Single връща само елемента, ако е един, уникален, ако са два гърми, а ако е SingleOrDefault = default стойността връща;

            //var resultFromingle = numbers.Single(x => x > 3); //runTime Error, BOOM!
            // var resultFromingleOrDefault = numbers.SingleOrDefault(x => x > 3); //BOOM!, повече от един елемент отговарят на условията
            // var resultFromingle = numbers.SingleOrDefault(x => x == 300); // връща 0, default na int

            //string ww = "MurrrrDoc";


            //var catsSelectedAndFiltered = cats
            //    .Where(name => name.Name.Contains("i")) //да съдържа буквата "i" - филтър;
            //    .Where(age => age.Age > 3) //годините да са над 3
            //    .Select(x => new //създаване нов обект, в мойто може да слагаме много неща! НО се губят останалите пропърита на класа 
            //    //и работят само новосъздадените!
            //    {
            //        lastName =  $"{x.Name} {ww}",
            //        yearsAthome = 3// и т.н и т.н. - прикрепя пропъртита към 
            //    })
            //    .ToList();

            //var catsOrdered = cats
            //    .OrderBy(x => x.Name)
            //    .ThenBy(x => x.Color)
            //    .ThenBy(x => x.Age)
            //    .ToList();

            //foreach (var cat in catsOrdered)
            //{
            //    Console.WriteLine($"{cat.Name}, Colour: {cat.Color}, Age: {cat.Age}");
            //}

            //ЗА ОБРАТНИЯ РЕД: OrderByDescending();



            // Any(), All(), Distinct(), Skip(), Take()

            //var checksIfAny = numbers.Any(x => x==3); //return True, if there is no - False;

            //  var checksIfAllElementsMatchesACondition = numbers.All(x => x > 0); //True;

            List<int> nummsForDistinct = new List<int> { 1, 1, 1, 2, 3, 3, 3, 4 };
            //var result = nummsForDistinct.Distinct().ToList(); //List<int> {1, 2, 3, 4} - само уникалните стойности;
            //var resultFromSkip = nummsForDistinct
            //    .Skip(2) //пропуска два елемента (1, 1), остават 1, 2, 3, 3, 3, 4
            //    .Take(3) //взима първите три (1, 2, 3)
            //    .ToList(); // и накрая връща 1, 2, 3


            //GroupBy()

            var groupedElements = cats
                .GroupBy(cat => cat.Name)
                .ToList();
            //foreach (var group in groupedElements)
            //{
            //    Console.WriteLine(group.Key);
            //    foreach (var cat in group)
            //    {
            //        Console.WriteLine("--" + cat.Name + " " + cat.Age);
            //    }

            //}
            //Резултат - колекция от колекции:
            //прави групи по имена, показва името на групата /ключа/ и нейните членове:

            // Miauuu
            //    --Miauuu 3
            //    --Miauuu 4
            //    --Miauuu 4
            //Mury
            //    --Mury 5


            //ToDictionary
            //само уникални key-ве


            //ВАРИАНТ 1:

            //var dict = cats
            //    .ToDictionary(cat => cat.Name);//Boom, cat.Name "Miauuu" се повтаря!

            var dict = cats
                .ToDictionary(cat => cat.Age); //no problem, the keys are Age of cats, and the value is Cat itSelf, as Object!

            //ВАРИАНТ 2:

            var dictWithCustomParams = cats
                .ToDictionary(cat => cat.Age, cat => cat.Color);//here the key of that Dict is Ages, and values are Colors!!!

            //Count()
            var count = cats.Count(x => x.Age > 3 && x.Color.Contains("B")); //преброй ни тия котки над 3 г. и в цвета има "B", (връща 1)

            //SelectMany()
            List<int[]> collections = new List<int[]>
            {
                new int[] {1, 2, 3, 4 },
                new int[] {5, 6, 7, 8},
                new int[] {9, 10, 11, 12}
            };
            var unitedCollections = collections.SelectMany(n => n)
                .OrderByDescending(x => x)
                .ToList();

            //Min, Max, Sum, Average

            var youngestCat = cats.Min(x => x.Age);// 1

            //и за другите работи, макс, сум и т.н.

            //Zip() - върти върху две колекции и прави операции

            var result = numbers.Zip(numbers2, (a, b) => (a + b)).ToList();//3 9 9 10 12 и тн

            //ВниМАНИЕ - ако колекциите са с различен брой членове, не гърми, а пропуска тия които ги няма?!

            //Join()

            var catsInSchool = cats
                .Join(
                    school,
                    cat => cat.MonthsForCourse,
                    sc => sc.months,
                    (cat, sc) => new
                    {
                        CatName = cat.Name,
                        SchoolName = sc.course
                    });

            //foreach (var item in catsInSchool)
            //{
            //    Console.WriteLine(item.CatName + " " + item.SchoolName);
            //}

            List<int> forTakeTest = new List<int>
            {
                
            };
            List<int> rr = forTakeTest
                .Take(5)
                .OrderBy(x => x)
                .ToList();

        }
    }
}
