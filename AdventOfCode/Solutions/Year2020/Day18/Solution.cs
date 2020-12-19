using System;

namespace AdventOfCode.Solutions.Year2020
{

    class Day18 : ASolution
    {
        string[] lines;

        public Day18() : base(18, 2020, "")
        {
            lines = Input.SplitByNewline();
        }

        protected override string SolvePartOne()
        {
            long sum = 0;
            
            foreach (string line in lines)
            {
                sum += SolveExpression(line);
            }
            
            return sum.ToString();

        }

        protected override string SolvePartTwo()
        {
            long sum1 = 0;
            
            foreach (string line in lines)
            {
                sum1 += SolveExpression2(line);
            }
            
            return sum1.ToString();
        }

        long SolveExpression(string expression)
        {
            if (expression.Contains("("))
            {
                expression = SolveParans(expression, false);
            }
            string[] symbols = expression.Split(" ");
            long total = 0;
            if (symbols[1] == "+")
            {
                total = long.Parse(symbols[0]) + long.Parse(symbols[2]);
            }
            else if (symbols[1] == "*")
            {
                total = long.Parse(symbols[0]) * long.Parse(symbols[2]);
            }

            for (int i = 3; i < symbols.Length - 1; i++)
            {
                if (symbols[i] == "+")
                {
                    total += long.Parse(symbols[i + 1]);
                }
                else if (symbols[i] == "*")
                {
                    total *= long.Parse(symbols[i + 1]);
                }
            }
            return total;
        }

        long SolveExpression2(string expression)
        {
            if (expression.Contains("("))
            {
                expression = SolveParans(expression, true);
            }

            string[] symbols = expression.Split(" ");

            if (expression.Contains('+'))
            {
                for (int i = 0; i < symbols.Length; i++)
                {
                    if (symbols[i] == "+")
                    {
                        long sum = long.Parse(symbols[i - 1]) + long.Parse(symbols[i + 1]);
                        int begin = expression.IndexOf('+') - 1 - symbols[i - 1].Length;
                        int end = expression.IndexOf('+') + 1 + symbols[i + 1].Length;
                        int length = end - begin + 1;
                        expression = ReplaceFirst(expression, expression.Substring(begin, length), sum.ToString());
                        return SolveExpression2(expression);
                    }
                }
            }

            long total = 1;

            for (int i = 0; i < symbols.Length; i+=2)
            {
                total *= long.Parse(symbols[i]);
            }
            return total;
        }

        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        string SolveParans(string expression, bool part2)
        {
            if (!expression.Contains("("))
            {
                return expression;
            }
            else
            {
                int open = expression.LastIndexOf("(");
                int close = expression.Substring(open + 1).IndexOf(")") + open + 1;
                int length = close - open - 1;
                long solved;
                if (part2)
                {
                    solved = SolveExpression2(expression.Substring(open + 1, length));
                }
                else
                {
                    solved = SolveExpression(expression.Substring(open + 1, length));
                }
                expression = expression.Replace(expression.Substring(open, length + 2), solved.ToString());

                if (part2)
                {
                    return SolveParans(expression, true);
                }
                else
                {
                    return SolveParans(expression, false);
                }
            }
        }
	}
}
