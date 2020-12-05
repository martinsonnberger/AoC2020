using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day05 : ASolution
    {
        int[] ids;
        public Day05() : base(05, 2020, "")
        {
            string[] passes = Input.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1').SplitByNewline();
            ids = new int[passes.Length];
            for (int i = 0; i < passes.Length; i++)
            {
                string rowBinary = passes[i].Substring(0,7);
                int row = reverseBinary(rowBinary);

                string seatBinary = passes[i].Substring(7);
                int seat = reverseBinary(seatBinary);
                
                ids[i] = row * 8 + seat;
            }
        }

        protected override string SolvePartOne()
        {
            return Utilities.MaxOfMany(ids).ToString();
        }

        protected override string SolvePartTwo()
        {
            Array.Sort(ids);
            for (int i = 1; i < ids.Length; i++)
            {
                if (ids[i] - ids[i - 1] > 1)
                {
                    return (ids[i] - 1).ToString();
                }
            }
            return null;
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
    }
}
