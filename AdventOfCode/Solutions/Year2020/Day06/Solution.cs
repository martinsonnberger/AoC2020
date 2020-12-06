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
            for (int i = 0; i < groups.Length; i++)
            {
                string[] persons = groups[i].SplitByNewline();
                int[] yesQuestions = new int[26];
                int[,] tickedQs = new int[persons.Length,26];
                for (int j = 0; j < persons.Length; j++)
                {
                    for (int k = 0; k < persons[j].Length; k++)
                    {
                        tickedQs[j, persons[j][k] - 97] = 1;
                    }
                }

                for (int j = 0; j < tickedQs.GetLength(0); j++)
                {
                    for (int k = 0; k < tickedQs.GetLength(1); k++)
                    {
                        if (tickedQs[j,k] == 0)
                        {
                            yesQuestions[k] = 1;
                        }
                    }
                }
                total += yesQuestions.Count(x => x == 0);
            }
            return total.ToString();
        }
    }
}
