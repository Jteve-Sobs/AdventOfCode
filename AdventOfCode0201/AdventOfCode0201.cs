using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode02
{
    internal class AdventOfCode0201
    {
        static void Main(string[] args)
        {
            var inputsString = File.ReadAllLines("..\\..\\input.txt").ToList();

            var listUpString = inputsString.Where(x => x.Contains("up")).ToList();
            var listDownString = inputsString.Where(x => x.Contains("down")).ToList();
            var listForwardString = inputsString.Where(x => x.Contains("forward")).ToList();

            listUpString = listUpString.Select(x => x.Replace("up ", "")).ToList();
            listDownString = listDownString.Select(x => x.Replace("down ", "")).ToList();
            listForwardString = listForwardString.Select(x => x.Replace("forward ", "")).ToList();

            var listUp = listUpString.Select(int.Parse).ToList();
            var listDown = listDownString.Select(int.Parse).ToList();
            var listForward = listForwardString.Select(int.Parse).ToList();

            var up = listUp.Sum();
            var down = listDown.Sum();
            var forward = listForward.Sum();

            var downLevel = down - up;

            Console.WriteLine(downLevel * forward);

            Console.ReadLine();

        }
    }
}
