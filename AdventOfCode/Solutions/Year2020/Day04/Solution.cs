using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day04 : ASolution
    {

        public Day04() : base(04, 2020, "")
        {

        }

        protected override string SolvePartOne()
        {
            string[] passports = Input.Split("\n\n");
            int count = 0;
            for (int i = 0; i < passports.Length; i++)
            {
                if (ValidPassport(passports[i]))
                {
                    count++;
                }
            }
            return count.ToString();
        }

        static bool ValidPassport(string passport)
        {
            string[] fields = new string[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
            for (int i = 0; i < fields.Length; i++)
            {
                if (passport.Contains(fields[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }

        protected override string SolvePartTwo()
        {
            return null;
        }
    }
}
