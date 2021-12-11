using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode01
{
    internal class AdventOfCode0101
       {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines("..\\..\\input.txt").ToList().Select(int.Parse).ToList();

            var counter = 0;

            for (int i = 1; i < inputs.Count; i++)
            {
                if (inputs.ElementAt(i) > inputs.ElementAt(i - 1))
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);

            Console.ReadLine();
        }
    }
}
