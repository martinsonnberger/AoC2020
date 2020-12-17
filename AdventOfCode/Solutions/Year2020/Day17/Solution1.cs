/*
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day17 : ASolution
    {
        char[,,] grid;
        bool[,,] changes;
        string[] input;

        public Day17() : base(17, 2020, "")
        {
            grid = new char[50,50,50];
            changes = new bool[50,50,50];
            input = Input.SplitByNewline();
            //input = new string[] {".#.", "..#", "###"};
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                for (int y = 0; y < grid.GetLength(0); y++)
                {
                    for (int z = 0; z < grid.GetLength(2); z++)
                    {
                        grid[x,y,z] = '.';
                    }
                }
            } 
            for (int x = 0; x < input[0].Length; x++)
            {
                for (int y = 0; y < input.Length; y++)
                {
                    grid[25 + x, 25 + y, 25] = input[x][y];
                }
            }
        }

        protected override string SolvePartOne()
        {
            for (int i = 0; i < 6; i++)
            {
                SolveCycle();
            }
            int count = 0;
            for (int x = 0; x < grid.GetLength(1); x++)
            {
                for (int y = 0; y < grid.GetLength(0); y++)
                {
                    for (int z = 0; z < grid.GetLength(2); z++)
                    {
                        if (grid[x,y,z] == '#')
                        {
                            count++;
                        }
                    }
                }
            } 
            return count.ToString();
        }

        void SolveCycle()
        {
            for (int i = 0; i < changes.GetLength(0); i++)
            {
                for (int j = 0; j < changes.GetLength(1); j++)
                {
                    for (int k = 0; k < changes.GetLength(2); k++)
                    {
                        changes[i,j,k] = false;
                    }
                }
            } 

            for (int x = 1; x < grid.GetLength(1) - 1; x++)
            {
                for (int y = 1; y < grid.GetLength(0) - 1; y++)
                {
                    for (int z = 1; z < grid.GetLength(2) - 1; z++)
                    {
                        int count = ActiveNeighbors(x, y, z);
                        if (count == 3 && grid[x,y,z] == '.')
                        {
                            changes[x,y,z] = true;
                        }
                        else if ((count < 2 || count > 3) && grid[x,y,z] == '#')
                        {
                            changes[x,y,z] = true;
                        }
                    }
                }
            }

            for (int x = 0; x < changes.GetLength(1); x++)
            {
                for (int y = 0; y < changes.GetLength(0); y++)
                {
                    for (int z = 0; z < changes.GetLength(2); z++)
                    {
                        if (changes[x,y,z] && grid[x,y,z] == '#')
                        {
                            grid[x,y,z] = '.';
                        }
                        else if (changes[x,y,z] && grid[x,y,z] == '.')
                        {
                            grid[x,y,z] = '#';
                        }
                    }
                }
            } 

        }

        int ActiveNeighbors(int x, int y, int z)
        {
            int count = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        if (i == 0 && j == 0 && k == 0)
                        {
                            continue;
                        }
                        else
                        {
                            if (grid[x + i, y + j, z + k] == '#')
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
*/