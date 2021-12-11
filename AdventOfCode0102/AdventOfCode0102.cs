using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode01
{
    internal class AdventOfCode0102
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines("..\\..\\input.txt").ToList().Select(int.Parse).ToList();

            var counter = 0;

            for (int i = 3; i < inputs.Count; i++)
            {
                var sum = inputs.ElementAt(i) + inputs.ElementAt(i - 1) + inputs.ElementAt(i - 2);
                var previousSum = inputs.ElementAt(i - 1) + inputs.ElementAt(i - 2) + inputs.ElementAt(i - 3);

                if (sum > previousSum)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);

            Console.ReadLine();
        }
    }
}
