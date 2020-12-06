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
                HashSet<char> groupYes = new HashSet<char>();
                foreach (char c in group.Replace("\n", ""))
                {
                    groupYes.Add(c);
                }

                foreach (string person in group.SplitByNewline())
                {
                    HashSet<char> personYes = new HashSet<char>();
                    foreach (char c in person)
                    {
                        personYes.Add(c);
                    }
                    groupYes.IntersectWith(personYes);
                }
                total += groupYes.Count();
            }
            return total.ToString();
        }
    }
}
