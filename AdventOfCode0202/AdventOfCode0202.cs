using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0202
{
    internal class AdventOfCode0202
    {
        static void Main(string[] args)
        {
            var inputsString = File.ReadAllLines("..\\..\\input.txt").ToList();

            var aim = 0;
            var horizontalPosition = 0;
            var depth = 0;

            for (int i = 0; i < inputsString.Count; i++)
            {
                var value = Int32.Parse(inputsString.ElementAt(i).Split().Last());

                if (inputsString.ElementAt(i).Contains("down"))
                {
                    aim += value;
                }
                else if (inputsString.ElementAt(i).Contains("up"))
                {
                    aim -= value;
                }
                else // forward
                {
                    horizontalPosition += value;

                    depth += aim * value;
                }
            }

            var solution = horizontalPosition * depth;

            Console.WriteLine(solution);

            Console.ReadLine();
        }
    }
}
