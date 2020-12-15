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
            //startNums = new int[] {0, 3, 6};
        }

        protected override string SolvePartOne()
        {
            /*
            int[] memory = new int[30000000];
            Array.Copy(startNums, memory, startNums.Length);

            for (int i = startNums.Length; i < 30000000; i++)
            {
                memory[i] = CheckArray(memory, i);
                if  (i % 100000 == 0)
                    Console.WriteLine(i);
            }
            return memory[30000000 - 1].ToString();
            */
            return null;
        }

        public int CheckArray(int[] array, int index)
        {
            int number = array[index - 1];
            for (int i = index - 2; i >= 0; i--)
            {
                if (array[i] == number)
                {
                    return index - i - 1;
                }
            }
            return 0;
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}