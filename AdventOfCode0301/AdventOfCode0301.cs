using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0301
{
    internal class AdventOfCode0301
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("..\\..\\input.txt").ToList();

            var counterOnes = 0;
            var gammaRate = "";
            var epsilonRate = "";

            for (int i = 0; i < input.First().Length; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    var value = input.ElementAt(j).ElementAt(i);

                    if (value == '1')
                    {
                        counterOnes++;
                    }
                }

                if (counterOnes > (input.Count / 2))
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
                else
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }

                counterOnes = 0;
            }

            var epsilson = Convert.ToInt32(epsilonRate, 2);
            var gamma = Convert.ToInt32(gammaRate, 2);

            var solution = gamma * epsilson;

            Console.WriteLine(solution);

            Console.ReadLine();
        }
    }
}
