using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Linq;

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





        static void Eightteen(List<string> input)
		{
			long sum = 0;
			long superSum = 0;
			foreach (var item in input)
			{
				if (item != "")
				{
					sum += long.Parse(Maths(item));
					superSum += long.Parse(SuperMaths(item));
				}
			}
			Console.WriteLine(sum);
			Console.WriteLine(superSum);
			/*Console.WriteLine(Maths("1 + 2 * 3 + 4 * 5 + 6"));
			Console.WriteLine(Maths("1 + (2 * 3) + (4 * (5 + 6))"));*/
		}

		static string Maths(string how)
		{
			const string reg = @"(\d+) *([\+\*]) *(\d+)";
			Regex regex = new Regex(reg, RegexOptions.Compiled);
			while (true)
			{
				if (how.Contains("("))
				{
					int leftP = how.IndexOf('(');
					int rightP = -1;
					int level = 0;
					for (int i = leftP; i < how.Length; i++)
					{
						if (how[i] == '(')
						{
							level++;
						}
						else if (how[i] == ')')
						{
							level--;
						}
						if (level == 0)
						{
							rightP = i;
							break;
						}
					}
					if (rightP != -1 && level == 0)
					{
						string rep = Maths(how.Substring(leftP + 1, rightP - leftP - 1));
						how = how.Substring(0, leftP) + rep + how.Substring(rightP + 1);
						;
					}
				}
				else
				{

					Match match = regex.Match(how);
					if (match.Success)
					{
						long res = 0;
						switch (match.Groups[2].Value)
						{
							case "+":
								res = long.Parse(match.Groups[1].Value) + long.Parse(match.Groups[3].Value);
								break;
							case "*":
								res = long.Parse(match.Groups[1].Value) * long.Parse(match.Groups[3].Value);
								break;
							default:
								break;
						}
						how = regex.Replace(how, res.ToString(), 1);
					}
					else
					{
						break;
					}
				}
			}
			return how;
		}


		static string SuperMaths(string how)
		{
			const string reg = @"(\d+) *([\+]) *(\d+)";
			const string reg2 = @"(\d+) *([\*]) *(\d+)";
			Regex regex = new Regex(reg, RegexOptions.Compiled);
			Regex regex2 = new Regex(reg2, RegexOptions.Compiled);
			while (true)
			{
				if (how.Contains("("))
				{
					int leftP = how.IndexOf('(');
					int rightP = -1;
					int level = 0;
					for (int i = leftP; i < how.Length; i++)
					{
						if (how[i] == '(')
						{
							level++;
						}
						else if (how[i] == ')')
						{
							level--;
						}
						if (level == 0)
						{
							rightP = i;
							break;
						}
					}
					if (rightP != -1 && level == 0)
					{
						string rep = SuperMaths(how.Substring(leftP + 1, rightP - leftP - 1));
						how = how.Substring(0, leftP) + rep + how.Substring(rightP + 1);
					}
				}
				else
				{

					Match match = regex.Match(how);
					Match match2 = regex2.Match(how);
					if (match.Success)
					{
						long res = 0;
						switch (match.Groups[2].Value)
						{
							case "+":
								res = long.Parse(match.Groups[1].Value) + long.Parse(match.Groups[3].Value);
								break;
							default:
								break;
						}
						how = regex.Replace(how, res.ToString(), 1);
					}
					else if (match2.Success)
					{
						long res = 0;
						switch (match2.Groups[2].Value)
						{
							case "*":
								res = long.Parse(match2.Groups[1].Value) * long.Parse(match2.Groups[3].Value);
								break;
							default:
								break;
						}
						how = regex2.Replace(how, res.ToString(), 1);
					}
					else
					{
						break;
					}
				}
			}
			return how;
		}
	}
    
}
