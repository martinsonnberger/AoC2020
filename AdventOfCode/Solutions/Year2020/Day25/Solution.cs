using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day25 : ASolution
    {

        public Day25() : base(25, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            ulong cardPublic = 14205034;
            ulong doorPublic = 18047856;

            ulong value = 1;
            ulong loopSize = 0;
            while (value != cardPublic)
            {
                value = (value * 7) % 20201227;
                loopSize++;
            }
            
            ulong encryption = 1;
            for (ulong i = 0; i < loopSize; i++)
            {
                encryption = (encryption * doorPublic) % 20201227;
            }
            
            return encryption.ToString();
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
