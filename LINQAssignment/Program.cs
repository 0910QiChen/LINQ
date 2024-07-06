using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 1. Numbers from range
            Given an array of integers, write a query that returns list of numbers greater than 30 and less than 100.
            Expected input and output
            [67, 92, 153, 15] → 67, 92 */
            List<int> Numbers = new List<int> { 30, 54, 3, 14, 25, 82, 1, 100, 23, 95 };

            //write your code here
            //Lamda(Method) Syntax
            var nums = Numbers.Where(n => n > 30 && n < 100).ToList();
            Console.WriteLine(string.Join(", ", nums));
            //Query(Comprehension) Syntax
            var numbs = from Number in Numbers where Number > 30 && Number < 100 select Number;
            Console.WriteLine(string.Join(", ", numbs));

            /* 2. Minimum length
            Write a query that returns words at least 5 characters long and make them uppercase.
            Expected input and output
            "computer", "usb" → "COMPUTER" */
            List<string> animals = new List<string>
            {
                "zebra",
                "elephant",
                "cat",
                "dog",
                "rhino",
                "bat"
            };

            //write your code here
            //Lamda(Method) Syntax
            var ans = animals.Where(word => word.Length >= 5).Select(word => word.ToUpper()).ToList();
            Console.WriteLine(string.Join(", ", ans));
            //Query(Comprehension) Syntax
            var anms = from animal in animals where animal.Length >= 5 select animal.ToUpper();
            Console.WriteLine(string.Join(", ", anms));

            /* 3. Select words
            Write a query that returns words starting with letter 'a' and ending with letter 'm'.
            Expected input and output
            "mum", "amsterdam", "bloom" → "amsterdam" */
            List<string> words = new List<string>
            {
                "alabam",
                "am",
                "balalam",
                "tara",
                "",
                "a",
                "axeliam",
                "39yo0m",
                "trol"
            };

            //write your code here
            //Lamda(Method) Syntax
            var wds = words.Where(word => word.StartsWith("a") && word.EndsWith("m")).ToList();
            Console.WriteLine(string.Join(", ", wds));
            //Query(Comprehension) Syntax
            var wors = from word in words where word.StartsWith("a") && word.EndsWith("m") select word;
            Console.WriteLine(string.Join(", ", wors));

            /* 4. Top 5 numbers
            Write a query that returns top 5 numbers from the list of integers in descending order.
            Expected input and output
            [78, -9, 0, 23, 54,  21, 7, 86]  → 86 78 54 23 21 */
            List<int> numbers = new List<int> { 6, 0, 999, 11, 443, 6, 1, 24, 54 };

            //write your code here
            //Lamda(Method) Syntax
            var nbs = numbers.OrderByDescending(n => n).Take(5).ToList();
            Console.WriteLine(string.Join(", ", nbs));
            //Query(Comprehension) Syntax
            var nbers = (from number in numbers orderby number descending select number).Take(5);
            Console.WriteLine(string.Join(", ", nbers));

            /* 5. Square greater than 20
            Write a query that returns list of numbers and their squares only if square is greater than 20
            Expected input and output
            [7, 2, 30] → 7 - 49, 30 - 900 */
            Numbers = new List<int> { 3, 9, 2, 4, 6, 5, 7 };

            //write your code here
            //Lamda(Method) Syntax
            var nms = Numbers.Select(n => new { number = n, square = n * n }).Where(n => n.square > 20).Select(n => $"{n.number} - {n.square}");
            Console.WriteLine(string.Join(", ", nms));
            //Query(Comprehension) Syntax
            var nmbers = from number in Numbers let square = number * number where square > 20 select $"{number} - {square}";
            Console.WriteLine(string.Join(", ", nmbers));

            /* 6. Most frequent character
            Write a query that returns most frequent character in string. Assume that there is only one such character.
            Expected input and output
            "panda"  → 'a'
            "n093nfv034nie9"→ 'n' */
            string str = "49fjs492jfJs94KfoedK0iejksKdsj3";

            //write your code here
            //Lamda(Method) Syntax
            char mfc = str.GroupBy(c => c).OrderByDescending(g => g.Count()).Select(g => g.Key).First();
            Console.WriteLine(mfc);
            //Query(Comprehension) Syntax
            var mostfreqchar = (from c in str group c by c into g orderby g.Count() descending select g.Key).First();
            Console.WriteLine(mostfreqchar);

            /* 7.Last word containing letter
            Given a non-empty list of words, sort it alphabetically and return a word that contains letter 'e'.
            Expected input and output
            ["plane", "ferry", "car", "bike"]→ "plane" */
            words = new List<string>
            {
                "cow",
                "dog",
                "elephant",
                "cat",
                "rat",
                "squirrel",
                "snake",
                "stork"
            };

            //write your code here
            //Lamda(Method) Syntax
            var wr = words.OrderByDescending(w => w).ToList().LastOrDefault(w => w.Contains("e"));
            Console.WriteLine(wr);
            //Query(Comprehension) Syntax
            var wor = (from word in words orderby word descending select word).LastOrDefault(w => w.Contains("e"));
            Console.WriteLine(wor);

            Console.ReadKey();
        }
    }
}
