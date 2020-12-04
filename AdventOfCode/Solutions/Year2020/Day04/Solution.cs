using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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
                if (passport.IndexOf(fields[i]) == -1)
                {
                    return false;
                }
            }
            return true;
        }

        protected override string SolvePartTwo()
        {
            string[] passports = Input.Split("\n\n");
            int count = 0;
            for (int i = 0; i < passports.Length; i++)
            {
                if (CorrectPassport(passports[i]))
                {
                    count++;
                }
            }
            Test();
            return count.ToString();
        }

        static bool CorrectPassport(string passport)
        {
            string[] fields = new string[] {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};
            for (int i = 0; i < fields.Length; i++)
            {
                int index = passport.IndexOf(fields[i]);
                if (index == -1)
                {
                    return false;
                }
                else
                {
                    passport += ' ';
                    int endIndex = passport.IndexOfAny(new char[]{' ', '\n'}, index);
                    string value = passport.Substring(index + 4, endIndex - index - 4);
                    switch (i)
                    {
                        case 0:
                            int year = int.Parse(value);
                            if (!(year >= 1920 && year <= 2002))
                            {
                                return false;
                            }
                            break;
                        case 1:
                            year = int.Parse(value);
                            if (!(year >= 2010 && year <= 2020))
                            {
                                return false;
                            }
                            break;
                        case 2:
                            year = int.Parse(value);
                            if (!(year >= 2020 && year <= 2030))
                            {
                                return false;
                            }
                            break;
                        case 3:
                            string unit = value.Substring(value.Length - 2);
                            int height = int.Parse(value.Substring(0, value.Length - 2));
                            if (unit == "cm")
                            {
                                if (!(height >= 150 && height <= 193))
                                {
                                    return false;
                                }
                            }
                            else if (unit == "in")
                            {
                                if (!(height >= 59 && height <= 76))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                            break;
                        case 4:
                            Regex color = new Regex("^#([a-f0-9]{6})$");
                            if (!color.IsMatch(value))
                            {
                                return false;
                            }
                            break;
                        case 5:
                            Regex eyes = new Regex("^(amb|blu|brn|gry|grn|hzl|oth){1}$");
                            if (!eyes.IsMatch(value))
                            {
                                return false;
                            }
                            break;
                        case 6:
                            Regex number = new Regex(@"^\d{9}$");
                            if (!number.IsMatch(value))
                            {
                                return false;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return true;
        }

        static void Test()
        {
            Regex number = new Regex(@"^\d{9}$");
            Console.WriteLine(number.IsMatch("00000000"));
        }
    }
}
