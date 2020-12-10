using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day10 : ASolution
    {
        int jolt1;
        int jolt3;
        int current;
        List<int> list = new List<int>();

        public Day10() : base(10, 2020, "")
        {
            list = Input.ToIntArray("\n").ToList();
            jolt1 = 0;
            jolt3 = 1;
        }
        protected override string SolvePartOne()
        {
            current = 0;
            list.Sort();

            foreach (var item in list)
            {
                if (item - current == 1)
                {
                    jolt1++;
                }
                if (item - current == 3)
                {
                    jolt3++;
                }
                current = item;
            }

            return (jolt1 * jolt3).ToString();
        }

        protected override string SolvePartTwo()
        {
            int device = list.Max() + 3;
            list.Add(0);
            list.Sort();
            list.Reverse();

            var edges = new Dictionary<int, long>();
            edges.Add(device, 1);
            foreach (var item in list)
            {
                edges.TryGetValue(item + 1, out long c1);
                edges.TryGetValue(item + 2, out long c2);
                edges.TryGetValue(item + 3, out long c3);
                edges[item] = c1 + c2 + c3;
            }
            
            return edges[0].ToString();
        }
    }
}
