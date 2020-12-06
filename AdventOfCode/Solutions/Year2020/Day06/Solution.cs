using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day06 : ASolution
    {
        string[] groups;

        public Day06() : base(06, 2020, "")
        {
            groups = Input.Split("\n\n");
        }

        protected override string SolvePartOne()
        {
            int total = groups.Sum(group => group.Replace("\n", "").Distinct().Count());
            return total.ToString();
        }

        protected override string SolvePartTwo()
        {
            int total = 0;
            foreach (var group in groups)
            {
                var groupsYes = group.Replace("\n", "").Distinct();
                
                foreach (string person in group.SplitByNewline())
                {
                    groupsYes = groupsYes.Intersect(person.Distinct());
                }
                total += groupsYes.Count();
            }
            return total.ToString();
        }
    }
}
