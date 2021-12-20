using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0802
{
    internal class AdventOfCode0802
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\inputTest.txt").ToList(); // -> solution: 61229
            var input = File.ReadAllLines("..\\..\\input.txt").ToList();

            var counter = 0;

            foreach (var line in input)
            {
                var relevantPart = line.Split(new string[] { " | " }, StringSplitOptions.None).ToList();

                var signalPatterns = relevantPart.First().Split(' ').ToList();
                var values = relevantPart.ElementAt(1).Split(' ').ToList();

                var decoded = new List<int>();

                // Get unique identifiable numbers
                var one = signalPatterns.Where(x => x.Length == 2).First();
                var four = signalPatterns.Where(x => x.Length == 4).First();
                var seven = signalPatterns.Where(x => x.Length == 3).First();
                var eight = signalPatterns.Where(x => x.Length == 7).First();

                // 9 additinally has the bottom bar when looking at 4 or 7
                var nine = signalPatterns.Where(x =>
                    x.Length == 6
                    && x.Except(seven).Except(four).Count() == 1).First();
                // 6 has one difference to 1
                var six = signalPatterns.Where(x =>
                    x.Length == 6
                    && x != nine
                    && one.Except(x).Count() == 1).First();
                // Only zero left
                var zero = signalPatterns.Where(x =>
                    x.Length == 6
                    && x != nine
                    && x != six).First();

                // Which elements can be identified now
                var bottomLeft = eight.Except(nine).First();
                var topRight = eight.Except(six).First();
                var bottomRight = one.Except(new[] { topRight }).First();

                // 5 does not contain topRight and bottomLeft
                var five = signalPatterns.Where(x =>
                    x.Length == 5
                    && !x.Contains(topRight)
                    && !x.Contains(bottomLeft)).First();
                // 2 contains topRight and not bottomLeft
                var two = signalPatterns.Where(x =>
                    x.Length == 5
                    && x != five
                    && x.Contains(topRight)
                    && !x.Contains(bottomRight)).First();
                // Only 3 left
                var three = signalPatterns.Where(x =>
                    x.Length == 5
                    && x != five
                    && x != two).First();

                var numbers = new List<string>()
                {
                    SortString(zero),
                    SortString(one),
                    SortString(two),
                    SortString(three),
                    SortString(four),
                    SortString(five),
                    SortString(six),
                    SortString(seven),
                    SortString(eight),
                    SortString(nine)
                };
                
                foreach (var value in values)
                {
                    decoded.Add(numbers.IndexOf(numbers.Where(x => x == SortString(value)).First()));
                }

                for (int i = 0; i < decoded.Count; i++)
                {
                    counter += decoded.ElementAt(i) * (int)Math.Pow(10, decoded.Count - 1 - i);
                }
            }

            Console.WriteLine(counter);

            Console.ReadLine();
        }

        static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
