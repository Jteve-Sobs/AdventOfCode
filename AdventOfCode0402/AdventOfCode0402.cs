using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0402
{
    internal class AdventOfCode0402
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("..\\..\\input.txt");

            var drawnNumbers = input.First().Split(',').ToList().Select(int.Parse).ToList();

            var bingoFields = new List<List<List<int>>>();

            var bingoLines = new List<List<int>>();

            var loosingBingoField = new List<List<int>>();

            var loosingMultiplier = 0;

            // Build lines
            for (int i = 2; i < input.Length; i++)
            {
                if (input.ElementAt(i) == String.Empty)
                {
                    continue;
                }

                var tempLine = input.ElementAt(i).Trim().Replace("  ", " ").Split(' ').ToList().Select(int.Parse).ToList();

                bingoLines.Add(tempLine);
            }

            // Create field from lines
            for (int i = 0; i < bingoLines.Count; i += 5)
            {
                var bingoField = new List<List<int>>
                {
                    bingoLines.ElementAt(i),
                    bingoLines.ElementAt(i + 1),
                    bingoLines.ElementAt(i + 2),
                    bingoLines.ElementAt(i + 3),
                    bingoLines.ElementAt(i + 4)
                };

                bingoFields.Add(bingoField);
            }

            var wonBingoFields = new List<int>();

            // Start with drawing numberts
            for (int i = 0; i < drawnNumbers.Count; i++)
            {
                if (wonBingoFields.Count == bingoFields.Count)
                {
                    loosingBingoField = bingoFields.ElementAt(wonBingoFields.Last());
                    loosingMultiplier = drawnNumbers.ElementAt(i - 1);
                    break;
                }

                for (int j = 0; j < bingoFields.Count; j++)
                {
                    for (int k = 0; k < bingoFields.First().Count; k++)
                    {
                        for (int l = 0; l < bingoFields.First().First().Count; l++)
                        {
                            if (bingoFields.ElementAt(j).ElementAt(k).ElementAt(l) == drawnNumbers.ElementAt(i))
                            {
                                bingoFields.ElementAt(j).ElementAt(k)[l] = -1;
                            }
                        }
                    }
                }

                // Check for winning if more than 4 values are replaced
                if (i > 3)
                {
                    var counter = 0;

                    for (int m = 0; m < bingoFields.Count; m++)
                    {
                        // Check in rows
                        for (int n = 0; n < bingoFields.First().Count; n++)
                        {
                            if (bingoFields.ElementAt(m).ElementAt(n).All(x => x == -1))
                            {
                                Console.WriteLine("Bingo field has won with row");
                                loosingBingoField = bingoFields.ElementAt(m);

                                if (!wonBingoFields.Contains(m))
                                {
                                    wonBingoFields.Add(m); 
                                }
                                break;
                            }
                        }

                        // Check in columns
                        for (int o = 0; o < bingoFields.First().Count; o++)
                        {
                            for (int p = 0; p < bingoFields.First().Count; p++)
                            {
                                for (int q = 0; q < bingoFields.First().First().Count; q++)
                                {
                                    if (bingoFields.ElementAt(m).ElementAt(q).ElementAt(p) == -1)
                                    {
                                        counter++;
                                    }
                                    else
                                    {
                                        break;
                                    }

                                    if (counter == 5)
                                    {
                                        Console.WriteLine("Bingo field has won with column");
                                        loosingBingoField = bingoFields.ElementAt(o);

                                        if (!wonBingoFields.Contains(m))
                                        {
                                            wonBingoFields.Add(m);
                                        }

                                        break;
                                    }
                                }
                                counter = 0;
                            }
                        }

                    }
                }
            }

            // Calculate solution
            var solution = 0;

            for (int i = 0; i < loosingBingoField.Count; i++)
            {
                for (int j = 0; j < loosingBingoField.First().Count; j++)
                {
                    if (loosingBingoField.ElementAt(i).ElementAt(j) != -1)
                    {
                        solution += loosingBingoField.ElementAt(i).ElementAt(j);
                    }
                }
            }

            solution *= loosingMultiplier;

            Console.WriteLine(solution);

            Console.ReadLine();
        }
    }
}
