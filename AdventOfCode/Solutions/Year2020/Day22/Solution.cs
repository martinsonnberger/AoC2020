using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day22 : ASolution
    {
        Queue<int> p1 = new Queue<int>();
        Queue<int> p2 = new Queue<int>();

        public Day22() : base(22, 2020, "")
        {
            //DebugInput = "Player 1:\n9\n2\n6\n3\n1\n\nPlayer 2:\n5\n8\n4\n7\n10";
            string[] array1 = Input.Split("\n\n")[0].SplitByNewline();
            string[] array2 = Input.Split("\n\n")[1].SplitByNewline();
            for (int i = 1; i < array1.Length; i++)
            {
                p1.Enqueue(int.Parse(array1[i]));
                p2.Enqueue(int.Parse(array2[i]));
            }
        }

        protected override string SolvePartOne()
        {
            
            while(p1.Count > 0 && p2.Count > 0)
            {
                int p1Num = p1.Dequeue();
                int p2Num = p2.Dequeue();

                if (p1Num > p2Num)
                {
                    p1.Enqueue(p1Num);
                    p1.Enqueue(p2Num);
                }
                else {
                    p2.Enqueue(p2Num);
                    p2.Enqueue(p1Num);
                }
            }
            
            int sum = 0;
            var winner = new Queue<int>();
            if (p1.Count > 0)
            {
                winner = p1;
            }
            else
            {
                winner = p2;
            }

            for (int i = winner.Count; i > 0; i--)
            {
                sum += i * winner.Dequeue();
            }
            return sum.ToString();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
