using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day20 : ASolution
    {
        string[] tiles;
        Dictionary<int, string[]> dict = new Dictionary<int, string[]>();

        public Day20() : base(20, 2020, "")
        {
            tiles = Input.Split("\n\n");
            for (int i = 0; i < tiles.Length; i++)
            {
                int key = int.Parse(tiles[i].Split(":\n")[0].Substring(5, 4));
                string[] value = tiles[i].Split(":\n")[1].SplitByNewline();
                dict.Add(key, value);
            }
        }

        protected override string SolvePartOne()
        {
            long product = 1;

            foreach (var tile in dict)
            {
                if (Matches(tile.Key) == 2)
                {
                    product *= tile.Key;
                }
            }

            return product.ToString();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }

        int Matches(int id)
        {
            string[] image = dict.GetValueOrDefault(id);
            string[] edges = new string[4];
            edges[0] = image[0];
            edges[1] = ColumnAsString(image, image[0].Length - 1);
            edges[2] = image[image.Length - 1];
            edges[3] = ColumnAsString(image, 0);
            
            int count = 0;
            foreach (var tile in dict)
            {
                if (tile.Key == id)
                {
                    continue;
                }
                string[] tileEdges = new string[4];
                tileEdges[0] = tile.Value[0];
                tileEdges[1] = ColumnAsString(tile.Value, image[0].Length - 1);
                tileEdges[2] = tile.Value[image.Length - 1];
                tileEdges[3] = ColumnAsString(tile.Value, 0);
                
                for (int i = 0; i < edges.Length; i++)
                {
                    for (int j = 0; j < tileEdges.Length; j++)
                    {
                        if (edges[i] == tileEdges[j] || edges[i].Reverse() == tileEdges[j])
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        static string ColumnAsString(string[] input, int index)
        {
            string column = "";
            for (int i = 0; i < input.Length; i++)
            {
                column += input[i][index];
            }
            return column;
        }


        static string[] FlipVertical(string[] image)
        {
            string[] flipped = new string[image.Length];
            for (int i = 0; i < flipped.Length; i++)
            {
                flipped[i] = image[i].Reverse();
            }
            return flipped;
        }

        static string[] FlipHorizontal(string[] image)
        {
            char[][] flipped = new char[image.Length][];
            for (int i = 0; i < flipped.Length; i++)
            {
                flipped[i] = new char[image.Length];
            }

            for (int i = 0; i < image.Length; i++)
            {
                for (int j = 0; j < image.Length / 2; j++)
                {
                    flipped[j][i] = image[image.Length - j - 1][i];
                    flipped[image.Length - j - 1][i] = image[j][i];
                }
            }
            string[] output = new string[image.Length];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = new string(flipped[i]);
            }
            return output;
        }

        static string[] Rotate90(string[] image)
        {
            char[][] rotated = new char[image.Length][];

            for (int i = 0; i < image.Length; i++)
            {
                rotated[i] = new char[image.Length];
                for (int j = 0; j < image.Length; j++)
                {
                    rotated[i][j] = image[image.Length - j - 1][i];
                }
            }
            
            string[] output = new string[image.Length];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = new string(rotated[i]);
            }
            return output;
        }
    }
}
