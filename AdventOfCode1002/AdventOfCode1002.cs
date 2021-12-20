using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode1002
{
    internal class AdventOfCode1002
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\inputTest.txt").ToList(); // -> solution: 288957
            var input = File.ReadAllLines("..\\..\\input.txt").ToList();

            var openingBrackets = new List<char>() { '(', '[', '{', '<' };
            var closingBrackets = new List<char>() { ')', ']', '}', '>' };

            var bracketsValues = new List<int>() { 1, 2, 3, 4 };

            var allMissingBrackets = new List<List<char>>();

            foreach (var line in input)
            {
                var openedBrackets = new List<char>();
                var corrupted = false;

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
                            corrupted = true;
                            break;
                        }
                    }
                }

                if (!corrupted)
                {
                    if (openedBrackets.Count > 0)
                    {
                        allMissingBrackets.Add(openedBrackets);
                    } 
                }
            }

            var missingBracketsScores = new List<ulong>();

            foreach (var singleMissingBrackets in allMissingBrackets)
            {
                ulong singleMissingBracketsScore = 0;

                singleMissingBrackets.Reverse();

                foreach (var item in singleMissingBrackets)
                {
                    var index = openingBrackets.IndexOf(item);

                    singleMissingBracketsScore *= 5;

                    singleMissingBracketsScore += (ulong)bracketsValues.ElementAt(index); 
                }

                missingBracketsScores.Add(singleMissingBracketsScore);
            }

            missingBracketsScores.Sort();

            var solution = missingBracketsScores.ElementAt(missingBracketsScores.Count / 2);

            Console.WriteLine(solution);

            Console.ReadLine();
        }
    }
}
