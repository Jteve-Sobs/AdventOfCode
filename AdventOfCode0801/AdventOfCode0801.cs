using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0801
{
    internal class AdventOfCode0801
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\inputTest.txt").ToList(); // -> solution: 26
            var input = File.ReadAllLines("..\\..\\input.txt").ToList();

            var counter = 0;

            var searchedLengths = new List<int>() { 2, 3, 4, 7};

            foreach (var line in input)
            {
                var relevantPart = line.Split(new string[] { " | " }, StringSplitOptions.None).ElementAt(1);

                var values = relevantPart.Split(' ');

                foreach (var value in values)
                {
                    if (searchedLengths.Contains(value.Length))
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);

            Console.ReadLine();
        }
    }
}
