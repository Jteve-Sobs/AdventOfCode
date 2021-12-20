using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0901
{
    internal class AdventOfCode0901
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\inputTest.txt").ToList(); // -> solution: 15
            var input = File.ReadAllLines("..\\..\\input.txt").ToList();

            var smokeFlows = new List<List<int>>();

            foreach (var line in input)
            {
                var tempList = new List<int>();

                foreach (var element in line)
                {
                    tempList.Add(Int32.Parse(element.ToString()));
                }

                smokeFlows.Add(tempList);
            }

            var riskLevel = 0;

            for (int i = 0; i < smokeFlows.Count; i++)
            {
                for (int j = 0; j < smokeFlows.First().Count; j++)
                {
                    var value = smokeFlows.ElementAt(i).ElementAt(j);

                    if (i - 1 >= 0)
                    {
                        if (smokeFlows.ElementAt(i - 1).ElementAt(j) <= value)
                        {
                            continue;
                        }
                    }
                    if (j - 1 >= 0)
                    {
                        if (smokeFlows.ElementAt(i).ElementAt(j - 1) <= value)
                        {
                            continue;
                        }
                    }
                    if (i + 1 < smokeFlows.Count)
                    {
                        if (smokeFlows.ElementAt(i + 1).ElementAt(j) <= value)
                        {
                            continue;
                        }
                    }
                    if (j + 1 < smokeFlows.First().Count)
                    {
                        if (smokeFlows.ElementAt(i).ElementAt(j + 1) <= value)
                        {
                            continue;
                        }
                    }

                    riskLevel += value + 1;
                }
            }

            Console.WriteLine(riskLevel);

            Console.ReadLine();
        }
    }
}
