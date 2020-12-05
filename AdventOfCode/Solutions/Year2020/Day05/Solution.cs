using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day05 : ASolution
    {

        public Day05() : base(05, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            string[] passes = Input.SplitByNewline();
            int max = 0;
            int[,] usedSeats = new int[110, 9]; 
            for (int i = 0; i < passes.Length; i++)
            {
                string rowBinary = passes[i].Substring(0,7).Replace('F', '0').Replace('B', '1');
                int row = reverseBinary(rowBinary);

                string seatBinary = passes[i].Substring(7).Replace('L', '0').Replace('R', '1');
                int seat = reverseBinary(seatBinary);
                usedSeats[row, seat] = 1;
                int id = row * 8 + seat;
                if (id > max)
                {
                    max = id;
                }
            }

            for (int i = 1; i < 110; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (usedSeats[i, j] == 0 && usedSeats[i - 1, j] != 0)
                    {
                        Console.WriteLine(i + " " + j);
                    }
                }
            }
            return max.ToString();
        }

        static int reverseBinary(string input)
        {
            int lo = 1;
            int hi = (int) Math.Pow(2, input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                int mid = lo + (hi - lo) / 2;
                if (input[i] == '0')
                {
                    hi = mid;
                }
                else if (input[i] == '1')
                {
                    lo = mid + 1;
                }
            }
            return hi - 1;
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
