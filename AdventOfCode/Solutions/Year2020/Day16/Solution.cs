using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

namespace AdventOfCode.Solutions.Year2020
{
    class Day16 : ASolution
    {
        string[] rulesRaw;
        int[] myTicket;
        List<string> nearbyTickets;
        List<string> validTickets;
        Dictionary<string, int[]> rules;

        public Day16() : base(16, 2020, "")
        {
            rulesRaw = Input.Split("\n\n")[0].SplitByNewline();
            myTicket = Input.Split("\n\n")[1].SplitByNewline()[1].ToIntArray(",");
            nearbyTickets = Input.Split("\n\n")[2].SplitByNewline().ToList();
            nearbyTickets.RemoveAt(0);
            validTickets = new List<string>(nearbyTickets);

            rules = new Dictionary<string, int[]>();
            foreach (string line in rulesRaw)
            {
                string name = line.Split(": ")[0];
                int[] bounds = new int[4];
                bounds[0] = int.Parse(line.Split(": ")[1].Split(" or ")[0].Split("-")[0]);
                bounds[1] = int.Parse(line.Split(": ")[1].Split(" or ")[0].Split("-")[1]);
                bounds[2] = int.Parse(line.Split(": ")[1].Split(" or ")[1].Split("-")[0]);
                bounds[3] = int.Parse(line.Split(": ")[1].Split(" or ")[1].Split("-")[1]);

                rules.Add(name, bounds);
            }

        }

        protected override string SolvePartOne()
        {
            int error = 0;
            for (int i = 0; i < nearbyTickets.Count; i++)
            {
                int[] fields = nearbyTickets[i].ToIntArray(",");
                foreach (int field in fields)
                {
                    if (ValidRules(field).Count == 0)
                    {
                        error += field;
                        validTickets.Remove(nearbyTickets[i]);
                    }
                }
                
            }
            return error.ToString();
        }

        protected override string SolvePartTwo()
        {
            var nearby = new List<Dictionary<int, HashSet<string>>>();
            
            var firstDict = new Dictionary<int, HashSet<string>>();
            for (int j = 0; j < validTickets[0].ToIntArray(",").Length; j++)
            {
                firstDict.Add(j, ValidRules(validTickets[0].ToIntArray(",")[j]));
            }
            nearby.Add(firstDict);

            for (int i = 1; i < validTickets.Count; i++)
            {
                var dict = new Dictionary<int, HashSet<string>>();
                int[] fields = validTickets[i].ToIntArray(",");
                for (int j = 0; j < fields.Length; j++)
                {
                    dict[j] = ValidRules(fields[j]).Intersect(nearby[i - 1].GetValueOrDefault(j)).ToHashSet();
                }
                nearby.Add(dict);
            }

            void IntersectSets()
            {
                for (int i = 1; i < nearby.Count; i++)
                {
                    for (int j = 0; j < nearby[i].Count; j++)
                    {
                        nearby[i].GetValueOrDefault(j).Intersect(nearby[i - 1].GetValueOrDefault(j)).ToHashSet();
                    }
                }
            }

            Dictionary<int, string> final = new Dictionary<int, string>();
            int count = 0;
            while (count < 19)
            {
                foreach (var ticket in nearby)
                {
                    foreach (var field in ticket)
                    {
                        if (field.Value.Count == 1)
                        {
                            string ruleName = field.Value.First();
                            final.Add(field.Key, ruleName);
                            Console.WriteLine(count + " " + ruleName);
                            count++;

                            // remove rule from all tickets
                            for (int i = 0; i < nearby.Count; i++)
                            {
                                for (int j = 0; j < nearby[i].Count; j++)
                                {
                                    nearby[i].GetValueOrDefault(j).Remove(ruleName);
                                }
                            }
                            IntersectSets();
                        }
                    }
                }
            }

            BigInteger product = new BigInteger(1);
            product = (BigInteger) myTicket[3] * myTicket[4] * myTicket[9] * myTicket[11] * myTicket[15] * myTicket[16];
            return product.ToString();
        }


        HashSet<string> ValidRules(int num)
        {
            HashSet<string> valid = new HashSet<string>();
            foreach (var rule in rules)
            {
                int[] bounds = rule.Value;

                if ((num >= bounds[0] && num <= bounds[1]) || (num >= bounds[2] && num <= bounds[3]))
                {
                    valid.Add(rule.Key);
                }
            }
            return valid;
        }
    }
}