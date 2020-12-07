using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;


namespace AdventOfCode.Solutions.Year2020
{
    class Content
    {
        public int count;
        public string color;
    }

    class Day07 : ASolution
    {
        Dictionary<string, List<Content>> rules;

        public Day07() : base(07, 2020, "")
        {
            rules = new Dictionary<string, List<Content>>();
            var input = Input.SplitByNewline().ToList();
            input.ForEach(ParseInput);
        }

        void ParseInput(string line)
        {
            line = line.Replace(".", "").Replace("bags", "bag");
            var bagColor = line.Split(" contain ")[0];
            var bagContent = line.Split(" contain ")[1].Split(",");
            rules.Add(bagColor, bagContent.Select(ParseContent).ToList());
        }

        Content ParseContent(string content)
        {
            content = content.Trim();
            var numbers = Regex.Matches(content, @"\d+").Select(x => int.Parse(x.Value));
            var count = numbers.Count() == 0 ? 0 : numbers.First();
            var output = new Content();
            output.color = Regex.Replace(content, @"\d", "").Trim();
            output.count = count;
            return output;
        }

        protected override string SolvePartOne()
        {
            var bags = rules.Where(x => x.Value.Select(x => x.color).Contains("shiny gold bag")).Select(x => x.Key).ToList();
            var total = bags;
            while (bags.Any())
            {
                var nextBag = rules.Where(x => x.Value.Select(x => x.color).Intersect(bags).Count() > 0).ToList();
                bags = nextBag.Select(x => x.Key).ToList();
                total = total.Concat(bags).ToList();
            }
            return total.Distinct().Count().ToString();
        }

        protected override string SolvePartTwo()
        {
            var goldBag = rules["shiny gold bag"];
            
            return CalcCount(goldBag).ToString();
        }

        int CalcCount(List<Content> content)
        {
            return content.Sum(x => x.count) + content.Sum(x => x.color == "no other bag" ? 0 : CalcCount(rules[x.color]) * x.count);
        }
    }
}
