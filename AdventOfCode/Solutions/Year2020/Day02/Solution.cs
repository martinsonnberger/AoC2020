using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day02 : ASolution
    {

        public Day02() : base(02, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            string[] inputs = Input.Split(new char[]{'\n', ' ', '-', ':'}, StringSplitOptions.RemoveEmptyEntries);
            int[] min = new int[inputs.Length / 4];
            int[] max = new int[inputs.Length / 4];
            char[] c = new char[inputs.Length / 4];
            string[] pswd = new string[inputs.Length / 4];
            int count = 0;
            for (int i = 0; i < 4000; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        min[count] = int.Parse(inputs[i]);
                        break;
                    case 1:
                        max[count] = int.Parse(inputs[i]);
                        break;
                    case 2:
                        c[count] = char.Parse(inputs[i]);
                        break;
                    case 3:
                        pswd[count] = inputs[i];
                        count++;
                        break;
                    default:
                        break;
                }
            }
            int correct = 0;
            int charCount = 0;
            for (int i = 0; i < 1000; i++)
            {
                charCount = 0;
                for (int j = 0; j < pswd[i].Length; j++)
                {
                    if (pswd[i][j] == c[i])
                        charCount++;
                }
                if (charCount >= min[i] && charCount <= max[i])
                    correct++;
            }
            return correct.ToString();
        }

        protected override string SolvePartTwo()
        {
            string[] inputs = Input.Split(new char[]{'\n', ' ', '-', ':'}, StringSplitOptions.RemoveEmptyEntries);
            int[] first = new int[inputs.Length / 4];
            int[] second = new int[inputs.Length / 4];
            char[] c = new char[inputs.Length / 4];
            string[] pswd = new string[inputs.Length / 4];
            int count = 0;
            for (int i = 0; i < 4000; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        first[count] = int.Parse(inputs[i]);
                        break;
                    case 1:
                        second[count] = int.Parse(inputs[i]);
                        break;
                    case 2:
                        c[count] = char.Parse(inputs[i]);
                        break;
                    case 3:
                        pswd[count] = inputs[i];
                        count++;
                        break;
                    default:
                        break;
                }
            }
            int correct = 0;
            for (int i = 0; i < 1000; i++)
            {
                if (pswd[i][first[i] - 1] == c[i] || pswd[i][second[i] - 1] == c[i])
                {
                    if (pswd[i][first[i] - 1] != pswd[i][second[i] - 1])
                    {
                        correct++;
                    }
                }
            }
            return correct.ToString();
        }
    }
}
