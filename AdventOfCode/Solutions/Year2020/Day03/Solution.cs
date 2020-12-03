using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day03 : ASolution
    {

        public Day03() : base(03, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            string[] input = Input.SplitByNewline();
    
            return Trees(3, 1, input).ToString();
        }

        protected override string SolvePartTwo()
        {
            string[] input = Input.SplitByNewline();
             
            int total = Trees(1, 1, input) * Trees(3, 1, input) * Trees(5, 1, input) * Trees(7, 1, input) * Trees(1, 2, input);
            return total.ToString();
        }

        static int Trees(int right, int down, string[] input)
        {
            int count = 0;
            for (int i = 0, j = 0; i < input.Length; i+=down, j+=right)
            {
                if (input[i % input.Length][j % input[i].Length] == '#')
                    count++;
            }
            return count;
        }
    }
}
