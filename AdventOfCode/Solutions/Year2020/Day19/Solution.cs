using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions.Year2020
{

    class Day19 : ASolution
    {
        string[] rulesRaw;
        string[] messages;
        Dictionary<int, string> rules;

        public Day19() : base(19, 2020, "Monster Messages")
        {
            //DebugInput = "0: 4 1 5\n1: 2 3 | 3 2\n2: 4 4 | 5 5\n3: 4 5 | 5 4\n4: \"a\"\n5: \"b\"";
            rulesRaw = Input.Split("\n\n")[0].SplitByNewline();
            messages = Input.Split("\n\n")[1].SplitByNewline();
            rules = new Dictionary<int, string>();

            foreach (string line in rulesRaw)
            {
                int key = int.Parse(line.Split(": ")[0]);
                string value = line.Split(": ")[1];
                rules.Add(key, value);
            }
        }

        Dictionary<int, string> mem = new Dictionary<int, string>();
        string ParseRule(int key, bool part2 = false)
        {
            if (mem.ContainsKey(key))
                return mem[key];
            
            string rule = rules[key];

            if (rule.Contains("\""))
                return rule.Replace("\"", "");

            StringBuilder sb = new StringBuilder("(");

            string[] split = rule.Split(' ');
            foreach (string item in split)
            {
                if (char.IsDigit(item[0]))
                {
                    sb.Append(ParseRule(int.Parse(item)));
                }
                else if (item == "|")
                {
                    sb.Append('|');
                }
            }
            sb.Append(')');
            mem.Add(key, sb.ToString());
            return sb.ToString();
        }

        protected override string SolvePartOne()
        {
            int count = 0;
            Regex regex = new Regex("^" + ParseRule(0) + "$");
            foreach (var item in messages)
            {
                if (regex.IsMatch(item))
                    count++;
            }
            return count.ToString();
        }

        protected override string SolvePartTwo()
        {
            for (int i = 0; i < rules.Count; i++)
            {
                rules[i] = ParseRule(i, true);
            }
            int count = 0;
            Regex regex = new Regex("^" + rules[0] + "$");
            foreach (var item in messages)
            {
                if (regex.IsMatch(item))
                    count++;
            }
            return count.ToString();
        }
    }
}
