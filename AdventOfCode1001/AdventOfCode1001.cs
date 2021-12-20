using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode1001
{
    internal class AdventOfCode1001
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\inputTest.txt").ToList(); // -> solution: 26397
            var input = File.ReadAllLines("..\\..\\input.txt").ToList();

            var openingBrackets = new List<char>() { '(', '[', '{', '<' };
            var closingBrackets = new List<char>() { ')', ']', '}', '>' };

            var bracketsValues = new List<int>() { 3, 57, 1197, 25137 };

            var openedBrackets = new List<char>();

            var illegalBrackets = new List<char>();

            foreach (var line in input)
            {
                foreach (var bracket in line)
                {
                    if (openingBrackets.Contains(bracket))
                    {
                        openedBrackets.Add(bracket);
                    }
                    else
                    {
                        var correspondingOpeningBracket = openingBrackets.ElementAt(closingBrackets.IndexOf(bracket));

                        int index = openedBrackets.FindLastIndex(x => x == correspondingOpeningBracket);

                        if (index == openedBrackets.Count - 1)
                        {
                            openedBrackets.RemoveAt(index);
                        }
                        else
                        {
                            illegalBrackets.Add(bracket);
                            break;
                        }
                    }
                }

                openedBrackets.Clear();
            }

            var solution = 0;

            foreach (var item in illegalBrackets)
            {
                var index = closingBrackets.IndexOf(item);

                solution += bracketsValues.ElementAt(index);
            }

            Console.WriteLine(solution);

            Console.ReadLine();
        }
    }
}
