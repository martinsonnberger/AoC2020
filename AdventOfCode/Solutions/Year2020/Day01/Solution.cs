using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day01 : ASolution
    {

        public Day01() : base(01, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            int[] input = Utilities.ToIntArray(Input, "\n");
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    if (input[i] + input[j] == 2020)
                    {
                        return (input[i] * input[j]).ToString();
                    }
                }
            }
            return null;
        }

        protected override string SolvePartTwo()
        {
            int[] input = Utilities.ToIntArray(Input, "\n");
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    for (int k = j; k < input.Length; k++)
                    {
                        if (input[i] + input[j] + input[k] == 2020)
                        {
                            return (input[i] * input[j] * input[k]).ToString();
                        }
                    }
                }
            }
            return null;
        }
    }
}
