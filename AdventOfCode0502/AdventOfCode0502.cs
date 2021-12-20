using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode0502
{
    internal class AdventOfCode0502
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines("..\\..\\inputTest.txt"); // -> solution: 12
            var input = File.ReadAllLines("..\\..\\input.txt");

            var oceanField = new int[1000][];

            for (int i = 0; i < oceanField.Length; i++)
            {
                oceanField[i] = new int[1000];
            }

            // Build field
            for (int i = 0; i < input.Length; i++)
            {
                var values = input.ElementAt(i).Split(new string[] { " -> " }, StringSplitOptions.None);

                var start = values.First().Split(',');
                var end = values.ElementAt(1).Split(',');

                int startX = int.Parse(start.First());
                int startY = int.Parse(start.ElementAt(1));

                int endX = int.Parse(end.First());
                int endY = int.Parse(end.ElementAt(1));

                //todo: can be integrated into each other. check for all directions
                // Diagonal
                if (!(startX == endX || startY == endY))
                {
                    var xDirection = 0;
                    var yDirection = 0;

                    if (startX > endX)
                    {
                        xDirection = -1;
                    }
                    else
                    {
                        xDirection = 1;
                    }

                    if (startY > endY)
                    {
                        yDirection = -1;
                    }
                    else
                    {
                        yDirection = 1;
                    }

                    for (int j = startX, k = startY;
                        j !=  (endX + xDirection) || k != (endY + yDirection);
                        j += xDirection, k += yDirection)
                    {
                            oceanField[j][k] += 1;                       
                    }
                }
                // Horizontal and vertical
                else
                {
                    if (startX > endX)
                    {
                        var temp = startX;
                        startX = endX;
                        endX = temp;
                    }

                    if (startY > endY)
                    {
                        var temp = startY;
                        startY = endY;
                        endY = temp;
                    }

                    for (int j = startX; j <= endX; j++)
                    {
                        for (int k = startY; k <= endY; k++)
                        {
                            oceanField[j][k] += 1;
                        }
                    }
                }
            }

            int counter = 0;
            // Count points with value > 1
            for (int i = 0; i < oceanField.Length; i++)
            {
                for (int j = 0; j < oceanField[0].Length; j++)
                {
                    //Console.Write($"{oceanField[i][j]} ");

                    if (oceanField[i][j] > 1)
                    {
                        counter++;
                    }
                }
                //Console.WriteLine(Environment.NewLine);
            }

            Console.WriteLine(Environment.NewLine + counter);

            Console.ReadLine();
        }
    }
}
