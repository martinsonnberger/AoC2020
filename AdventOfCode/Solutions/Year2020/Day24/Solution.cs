using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day24 : ASolution
    {
        string[] lines;
        bool[,] tiles = new bool[128,128];

        public Day24() : base(24, 2020, "")
        {
            lines = Input.SplitByNewline();
        }

        protected override string SolvePartOne()
        {
            foreach (string line in lines)
            {
                var offset = ParseLine(line);
                tiles[tiles.GetLength(0) / 2 + offset.Item1, tiles.GetLength(1) / 2 + offset.Item2] = !tiles[tiles.GetLength(0) / 2 + offset.Item1, tiles.GetLength(1) / 2 + offset.Item2];
            }
            int count = 0;
            foreach (bool tile in tiles)
            {
                if (tile) count++;
            }
            return count.ToString();
        }

        protected override string SolvePartTwo()
        {
            bool[,] flip;
            for (int n = 0; n < 100; n++)
            {
                flip = new bool[tiles.GetLength(0),tiles.GetLength(1)];
                for (int i = 1; i < tiles.GetLength(0) - 1; i++)
                {
                    for (int j = 1; j < tiles.GetLength(1) - 1; j++)
                    {
                        int count = CountNeighbors((i, j));
                        if (tiles[i,j] && (count == 0 || count > 2))
                        {
                            flip[i,j] = true;
                        }
                        else if (!tiles[i,j] && count == 2)
                        {
                            flip[i,j] = true;
                        }
                    }
                }
                for (int i = 0; i < tiles.GetLength(0); i++)
                {
                    for (int j = 0; j < tiles.GetLength(1); j++)
                    {
                        if (flip[i,j])
                        {
                            tiles[i,j] = !tiles[i,j];
                        }
                    }
                }
            }
            
            int bcount = 0;
            foreach (bool tile in tiles)
            {
                if (tile) bcount++;
            }
            return bcount.ToString();
        }

        int CountNeighbors((int, int) index)
        {
            int count = 0;
            int x = index.Item1;
            int y = index.Item2;

            if (tiles[x + 1, y]) count++;
            if (tiles[x, y + 1]) count++;
            if (tiles[x - 1, y + 1]) count++;
            if (tiles[x - 1, y]) count++;
            if (tiles[x, y - 1]) count++;
            if (tiles[x + 1, y - 1]) count++;

            return count;
        }

        static (int, int) ParseLine(string line)
        {
            var offset = (0, 0);
            int i = 0;
            while (i < line.Length)
            {
                if (line.Substring(i).StartsWith("e"))
                {
                    offset.Item1++;
                    i++;
                    continue;
                }
                else if (line.Substring(i).StartsWith("se"))
                {
                    offset.Item2++;
                    i += 2;
                    continue;
                }
                else if (line.Substring(i).StartsWith("sw"))
                {
                    offset.Item1--;
                    offset.Item2++;
                    i += 2;
                    continue;
                }
                else if (line.Substring(i).StartsWith("w"))
                {
                    offset.Item1--;
                    i++;
                    continue;
                }
                else if (line.Substring(i).StartsWith("nw"))
                {
                    offset.Item2--;
                    i += 2;
                    continue;
                }
                else if (line.Substring(i).StartsWith("ne"))
                {
                    offset.Item1++;
                    offset.Item2--;
                    i += 2;
                    continue;
                }
            }
            return offset;
        }
    }
}
