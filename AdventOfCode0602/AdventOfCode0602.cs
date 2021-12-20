using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0602
{
    internal class AdventOfCode0602
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\inputTest.txt").First().Split(',').Select(int.Parse).ToList(); // -> solution: 26984457539
            var input = File.ReadAllLines("..\\..\\input.txt").First().Split(',').Select(int.Parse).ToList();

            var fishstate = new ulong[9];

            for (int i = 0; i < input.Count; i++)
            {
                fishstate[input.ElementAt(i)] += 1;
            }

            for (int i = 0; i < 256; i++)
            {
                var newFish = fishstate.ElementAt(0);

                for (int j = 0; j < 8; j++)
                {
                    fishstate[j] = fishstate[j + 1];
                }

                fishstate[6] += newFish;
                fishstate[8] = newFish;
            }

            ulong counter = 0;
            // Count fishes
            for (int i = 0; i < fishstate.Length; i++)
            {
                counter += fishstate.ElementAt(i);
            }

            Console.WriteLine(counter);

            Console.ReadLine();
        }
    }
}
