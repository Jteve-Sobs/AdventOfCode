using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode1102
{
    internal class AdventOfCode1102
    {
        private static List<Tuple<int, int>> FlashQueue = new List<Tuple<int, int>>();
        private static List<Tuple<int, int>> FlashedPointsInStep = new List<Tuple<int, int>>();
        private static List<List<int>> OctopusField = new List<List<int>>();

        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\inputTest.txt").ToList(); // -> solution: 195
            var input = File.ReadAllLines("..\\..\\input.txt").ToList();

            // Build field
            for (int i = 0; i < input.Count; i++)
            {
                var tempList = new List<int>();

                for (int j = 0; j < input.First().Length; j++)
                {
                    tempList.Add(Int32.Parse(input[i][j].ToString()));
                }

                OctopusField.Add(tempList);
            }

            var solution = 0;

            for (int i = 0; i < int.MaxValue; i++)
            {
                FlashedPointsInStep.Clear();

                // Add one charge to every entry
                for (int j = 0; j < OctopusField.Count; j++)
                {
                    for (int k = 0; k < OctopusField.First().Count; k++)
                    {
                        OctopusField[j][k] += 1;

                        if (OctopusField[j][k] > 9)
                        {
                            AddUnflashedPointsToQueueAndMarkAsFlashed(j, k);
                        }
                    }
                }

                while (FlashQueue.Count > 0)
                {
                    var x = FlashQueue.First().Item1;
                    var y = FlashQueue.First().Item2;

                    OctopusField[x][y] = 0;

                    // Above flash
                    if (x - 1 >= 0)
                    {
                        AddChargeIfNotFlashed(x - 1, y);

                        if (OctopusField[x - 1][y] > 9)
                        {
                            AddUnflashedPointsToQueueAndMarkAsFlashed(x - 1, y);
                        }

                        if (y - 1 >= 0)
                        {
                            AddChargeIfNotFlashed(x - 1, y - 1);

                            if (OctopusField[x - 1][y - 1] > 9)
                            {
                                AddUnflashedPointsToQueueAndMarkAsFlashed(x - 1, y - 1);
                            }
                        }

                        if (y + 1 < OctopusField.First().Count)
                        {
                            AddChargeIfNotFlashed(x - 1, y + 1);

                            if (OctopusField[x - 1][y + 1] > 9)
                            {
                                AddUnflashedPointsToQueueAndMarkAsFlashed(x - 1, y + 1);
                            }
                        }
                    }

                    // Left and right of flash
                    if (y + 1 < OctopusField.First().Count)
                    {
                        AddChargeIfNotFlashed(x, y + 1);

                        if (OctopusField[x][y + 1] > 9)
                        {
                            AddUnflashedPointsToQueueAndMarkAsFlashed(x, y + 1);
                        }
                    }

                    if (y - 1 >= 0)
                    {
                        AddChargeIfNotFlashed(x, y - 1);

                        if (OctopusField[x][y - 1] > 9)
                        {
                            AddUnflashedPointsToQueueAndMarkAsFlashed(x, y - 1);
                        }
                    }

                    // Below flash
                    if (x + 1 < OctopusField.Count)
                    {
                        AddChargeIfNotFlashed(x + 1, y);

                        if (OctopusField[x + 1][y] > 9)
                        {
                            AddUnflashedPointsToQueueAndMarkAsFlashed(x + 1, y);
                        }

                        if (y + 1 < OctopusField.First().Count)
                        {
                            AddChargeIfNotFlashed(x + 1, y + 1);

                            if (OctopusField[x + 1][y + 1] > 9)
                            {
                                AddUnflashedPointsToQueueAndMarkAsFlashed(x + 1, y + 1);
                            }
                        }

                        if (y - 1 >= 0)
                        {
                            AddChargeIfNotFlashed(x + 1, y - 1);

                            if (OctopusField[x + 1][y - 1] > 9)
                            {
                                AddUnflashedPointsToQueueAndMarkAsFlashed(x + 1, y - 1);
                            }
                        }
                    }

                    FlashQueue.RemoveAt(0);
                }

                if (FlashedPointsInStep.Count == OctopusField.Count * OctopusField.First().Count)
                {
                    solution = i + 1;
                    break;
                }
            }

            Console.WriteLine(solution);

            Console.ReadLine();
        }

        public static void AddUnflashedPointsToQueueAndMarkAsFlashed(int x, int y)
        {
            var tempTuple = new Tuple<int, int>(x, y);

            if (!FlashedPointsInStep.Contains(tempTuple))
            {
                FlashQueue.Add(tempTuple);
                FlashedPointsInStep.Add(tempTuple);
            }
        }

        public static void AddChargeIfNotFlashed(int x, int y)
        {
            var tempTuple = new Tuple<int, int>(x, y);

            if (!FlashedPointsInStep.Contains(tempTuple))
            {
                OctopusField[x][y] += 1;
            }
        }
    }
}