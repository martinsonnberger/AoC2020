using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day15 : ASolution
    {
        int[] startNums;
        public Day15() : base(15, 2020, "")
        {
            startNums = Input.ToIntArray(",");
        }

        protected override string SolvePartOne()
        {
            return lastNumber(2020, startNums).ToString();
        }
        protected override string SolvePartTwo()
        {
            return lastNumber(30000000, startNums).ToString();
        }

        int lastNumber(int lastIndex, int[] numbers)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                dict.Add(numbers[i], i + 1);
            }

            int last = numbers[numbers.Length - 1];

            for (int i = numbers.Length + 1; i <= lastIndex; i++)
            {
                if (!dict.ContainsKey(last))
                {
                    dict[last] = i - 1;
                    last = 0;
                }
                else
                {
                    int newNum = i - dict[last] - 1;
                    dict[last] = i - 1;
                    last = newNum;
                }
            }
            return last;
        }
    }
}