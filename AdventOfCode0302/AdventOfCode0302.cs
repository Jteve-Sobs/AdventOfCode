using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0302
{
    internal class AdventOfCode0302
    {
        static void Main(string[] args)
        {
            var oxygenInput = File.ReadAllLines("..\\..\\input.txt").ToList();
            var CO2Input = File.ReadAllLines("..\\..\\input.txt").ToList();

            var oxygenGeneratorRating = "";
            var CO2ScrubberRating = "";

            var counterOnes = 0;

            for (int i = 0; i < oxygenInput.First().Length; i++)
            {
                if (oxygenInput.Count == 1)
                {
                    break;
                }

                for (int j = 0; j < oxygenInput.Count; j++)
                {
                    var value = oxygenInput.ElementAt(j).ElementAt(i);

                    if (value == '1')
                    {
                        counterOnes++;
                    }
                }

                if (counterOnes >= (oxygenInput.Count / 2))
                {
                    oxygenGeneratorRating += "1";
                    oxygenInput.RemoveAll(x => !x.StartsWith(oxygenGeneratorRating));
                }
                else
                {
                    oxygenGeneratorRating += "0";
                    oxygenInput.RemoveAll(x => !x.StartsWith(oxygenGeneratorRating));
                }

                counterOnes = 0;
            }

            for (int i = 0; i < CO2Input.First().Length; i++)
            {
                if (CO2Input.Count == 1)
                {
                    break;
                }

                for (int j = 0; j < CO2Input.Count; j++)
                {
                    var value = CO2Input.ElementAt(j).ElementAt(i);

                    if (value == '1')
                    {
                        counterOnes++;
                    }
                }

                if (counterOnes >= (CO2Input.Count / 2))
                {
                    CO2ScrubberRating += "0";
                    CO2Input.RemoveAll(x => !x.StartsWith(CO2ScrubberRating));
                }
                else
                {
                    CO2ScrubberRating += "1";
                    CO2Input.RemoveAll(x => !x.StartsWith(CO2ScrubberRating));
                }

                counterOnes = 0;
            }

            var valueCO2 = Convert.ToInt32(CO2Input.First(), 2);
            var valueOxygen = Convert.ToInt32(oxygenInput.First(), 2);

            var solution = valueCO2 * valueOxygen;
            Console.WriteLine(solution);

            Console.ReadLine();
        }
    }
}
