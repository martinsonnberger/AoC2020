using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day08 : ASolution
    {
        string[,] instructions;
        public Day08() : base(08, 2020, "")
        {
            string[] lines = Input.Split("\n");

            instructions = new string[lines.Length, 3];
            for (int i = 0; i < instructions.GetLength(0); i++)
            {
                instructions[i, 0] = lines[i].Split(" ")[0];
                instructions[i, 1] = lines[i].Split(" ")[1];
            }
        }

        protected override string SolvePartOne()
        {
            return Run();
        }

        string Run()
        {
            int acc = 0;
            
            for (int i = 0; i < instructions.GetLength(0); i++)
            {
                if (instructions[i,2] == "1")
                {
                    return acc + " false";
                }
                else if (instructions[i,0] == "acc")
                {
                    acc += int.Parse(instructions[i,1]);
                }
                else if (instructions[i,0] == "jmp")
                {
                    i += int.Parse(instructions[i,1]) - 1;
                }
                instructions[i, 2] = "1";
            }
            return acc + " true";
        }

        protected override string SolvePartTwo()
        {
            
            for (int i = 0; i < instructions.GetLength(0); i++)
            {
                for (int j = 0; j < instructions.GetLength(0); j++)
                {
                    instructions[j, 2] = null;
                }
                string old = instructions[i, 0];
                if (instructions[i, 0] == "jmp")
                {
                    instructions[i, 0] = "nop";
                }
                else if (instructions[i, 0] == "nop")
                {
                    instructions[i, 0] = "jmp";
                }
                string run = Run();
                if (bool.Parse(run.Split(" ")[1]))
                {
                    return run;
                }
                instructions[i,0] = old;
            }
            return "false";
        }
    }
}
