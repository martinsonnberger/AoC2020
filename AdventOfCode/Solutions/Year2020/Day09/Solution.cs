using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day09 : ASolution
    {
        string[] input;
        long[] numbers;
        long wrongNum;

        public Day09() : base(09, 2020, "")
        {
            input = Input.SplitByNewline();
            numbers = new long[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                numbers[i] = long.Parse(input[i]);
            }
        }

        protected override string SolvePartOne()
        {
            for (int i = 25; i < numbers.Length; i++)
            {
                bool holds = false;
                for (int j = i - 25; j < i; j++)
                {
                    for (int k = j + 1; k < i; k++)
                    {
                        if (numbers[j] + numbers[k] == numbers[i] && numbers[j] != numbers[k])
                        {
                            holds = true;
                        }
                    }
                }
                if (!holds)
                {
                    wrongNum = numbers[i];
                }
            }
            return wrongNum.ToString();
        }

        protected override string SolvePartTwo()
        {
            var list = numbers.ToList();

            var subsets = Enumerable.Range(0, list.Count).SelectMany(start => Enumerable.Range(1, list.Count-start).Select(count => list.GetRange(start, count)));

            foreach (var set in subsets)
            {
                if (set.Sum() == wrongNum)
                {
                    return (set.Min() + set.Max()).ToString();
                }
            }
            
            return null;
        }
    }
}
