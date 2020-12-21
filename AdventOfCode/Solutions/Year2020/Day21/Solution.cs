using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day21 : ASolution
    {
        Dictionary<HashSet<string>, HashSet<string>> foods = new Dictionary<HashSet<string>, HashSet<string>>();

        public Day21() : base(21, 2020, "")
        {
            foreach (string line in Input.SplitByNewline())
            {
                foods.Add(line.Split(" (contains ")[0].Split(" ").ToHashSet(), line.Split(" (contains ")[1].Replace(")", "").Split(", ").ToHashSet());
            }
        }

        protected override string SolvePartOne()
        {
            return null;
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
