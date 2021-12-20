using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0902
{
    internal class AdventOfCode0902
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\inputTest.txt").ToList(); // -> solution: 1134
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

            var sizes = new List<int>();

            for (int i = 0; i < smokeFlows.Count; i++)
            {
                for (int j = 0; j < smokeFlows.First().Count; j++)
                {
                    var size = 0;

                    var currentValue = smokeFlows.ElementAt(i).ElementAt(j);
                    if (currentValue != 9 && currentValue != -1)
                    {
                        smokeFlows[i][j] = -1;
                        size++;
                    }
                    else
                    {
                        continue;
                    }

                    var currentI = i;
                    var currentJ = j;

                    var pointsToSearch = new List<KeyValuePair<int, int>>
                    {
                        new KeyValuePair<int, int>(currentI, currentJ)
                    };

                    while (pointsToSearch.Count != 0)
                    {
                        currentI = pointsToSearch.First().Key;
                        currentJ = pointsToSearch.First().Value;

                        var counter1 = 0;
                        while (currentI - counter1 - 1 >= 0)
                        {
                            counter1++;
                            var value = smokeFlows.ElementAt(currentI - counter1).ElementAt(currentJ);
                            if (value != 9 && value != -1)
                            {
                                smokeFlows[currentI - counter1][currentJ] = -1;
                                pointsToSearch.Add(new KeyValuePair<int, int>(currentI - counter1, currentJ));
                                size++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        var counter2 = 0;
                        while (currentJ - counter2 - 1 >= 0)
                        {
                            counter2++;
                            var value = smokeFlows.ElementAt(currentI).ElementAt(currentJ - counter2);
                            if (value != 9 && value != -1)
                            {
                                smokeFlows[currentI][currentJ - counter2] = -1;
                                pointsToSearch.Add(new KeyValuePair<int, int>(currentI, currentJ - counter2));
                                size++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        var counter3 = 0;
                        while (currentI + counter3 + 1 < smokeFlows.Count)
                        {
                            counter3++;
                            var value = smokeFlows.ElementAt(currentI + counter3).ElementAt(currentJ);
                            if (value != 9 && value != -1)
                            {
                                smokeFlows[currentI + counter3][currentJ] = -1;
                                pointsToSearch.Add(new KeyValuePair<int, int>(currentI + counter3, currentJ));
                                size++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        var counter4 = 0;
                        while (currentJ + counter4 + 1 < smokeFlows.First().Count)
                        {
                            counter4++;
                            var value = smokeFlows.ElementAt(currentI).ElementAt(currentJ + counter4);
                            if (value != 9 && value != -1)
                            {
                                smokeFlows[currentI][currentJ + counter4] = -1;
                                pointsToSearch.Add(new KeyValuePair<int, int>(currentI, currentJ + counter4));
                                size++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        pointsToSearch.Remove(pointsToSearch.First());
                    }

                    sizes.Add(size);
                }
            }

            sizes.Sort();

            var solution = sizes.Last() * sizes.ElementAt(sizes.Count - 2) * sizes.ElementAt(sizes.Count - 3);

            Console.WriteLine(solution);

            Console.ReadLine();
        }
    }
}
