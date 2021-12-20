using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0701
{
    internal class AdventOfCode0701
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("..\\..\\inputTest.txt").First().Split(',').Select(int.Parse).ToList(); // -> solution: 37, best position: 2
            //var input = File.ReadAllLines("..\\..\\input.txt").First().Split(',').Select(int.Parse).ToList();

            var min = input.Min();
            var max = input.Max();

            var minFuel = int.MaxValue;
            var desirablePosition = 0;

            for (int i = 0; i <= max; i++)
            {
                var fuel = 0;

                for (int j = 0; j < input.Count; j++)
                {
                    fuel += Math.Abs(input.ElementAt(j) - i);
                }

                if (fuel < minFuel)
                {
                    minFuel = fuel;
                    desirablePosition = i;
                }
            }

            Console.WriteLine(minFuel);

            Console.ReadLine();
        }
    }
}
