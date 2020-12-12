using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day12 : ASolution
    {
        string[] instructions;

        public Day12() : base(12, 2020, "")
        {
            instructions = Input.SplitByNewline();
        }

        protected override string SolvePartOne()
        {
            int upDirection = 0;
            int rightDirection = 1;

            int upValue = 0;
            int rightValue = 0;

            foreach (string instruction in instructions)
            {
                int value = int.Parse(instruction.Substring(1));
                switch (instruction[0])
                {
                    case 'F':
                        upValue += upDirection * value;
                        rightValue += rightDirection * value;
                        break;
                    
                    case 'N':
                        upValue += value;
                        break;
                    
                    case 'E':
                        rightValue += value;
                        break;
                    
                    case 'S':
                        upValue -= value;
                        break;
                    
                    case 'W':
                        rightValue -= value;
                        break;
                    
                    default:
                        if (value == 180)
                        {
                            rightDirection *= -1;
                            upDirection *= -1;
                        }
                        else
                        {
                            if (instruction[0] == 'L')
                            {
                                if (upDirection == 1 && rightDirection == 0)
                                {
                                    if (value == 90)
                                    {
                                        upDirection = 0;
                                        rightDirection = -1;
                                    }
                                    else if (value == 270)
                                    {
                                        upDirection = 0;
                                        rightDirection = 1;
                                    }
                                }
                                else if (upDirection == 0 && rightDirection == 1)
                                {
                                    if (value == 90)
                                    {
                                        upDirection = 1;
                                        rightDirection = 0;
                                    }
                                    else if (value == 270)
                                    {
                                        upDirection = -1;
                                        rightDirection = 0;
                                    }
                                }
                                else if (upDirection == -1 && rightDirection == 0)
                                {
                                    if (value == 90)
                                    {
                                        upDirection = 0;
                                        rightDirection = 1;
                                    }
                                    else if (value == 270)
                                    {
                                        upDirection = 0;
                                        rightDirection = -1;
                                    }
                                }
                                else if (upDirection == 0 && rightDirection == -1)
                                {
                                    if (value == 90)
                                    {
                                        upDirection = -1;
                                        rightDirection = 0;
                                    }
                                    else if (value == 270)
                                    {
                                        upDirection = 1;
                                        rightDirection = 0;
                                    }
                                }
                            }
                            else if (instruction[0] == 'R')
                            {
                                if (upDirection == 1 && rightDirection == 0)
                                {
                                    if (value == 90)
                                    {
                                        upDirection = 0;
                                        rightDirection = 1;
                                    }
                                    else if (value == 270)
                                    {
                                        upDirection = 0;
                                        rightDirection = -1;
                                    }
                                }
                                else if (upDirection == 0 && rightDirection == 1)
                                {
                                    if (value == 90)
                                    {
                                        upDirection = -1;
                                        rightDirection = 0;
                                    }
                                    else if (value == 270)
                                    {
                                        upDirection = 1;
                                        rightDirection = 0;
                                    }
                                }
                                else if (upDirection == -1 && rightDirection == 0)
                                {
                                    if (value == 90)
                                    {
                                        upDirection = 0;
                                        rightDirection = -1;
                                    }
                                    else if (value == 270)
                                    {
                                        upDirection = 0;
                                        rightDirection = 1;
                                    }
                                }
                                else if (upDirection == 0 && rightDirection == -1)
                                {
                                    if (value == 90)
                                    {
                                        upDirection = 1;
                                        rightDirection = 0;
                                    }
                                    else if (value == 270)
                                    {
                                        upDirection = -1;
                                        rightDirection = 0;
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            int distance = Math.Abs(upValue) + Math.Abs(rightValue);
            return distance.ToString();
        }

        protected override string SolvePartTwo()
        {
            int upValue = 1;
            int rightValue = 10;

            int shipValueUp = 0;
            int shipValueRight = 0;

            foreach (string instruction in instructions)
            {
                int value = int.Parse(instruction.Substring(1));
                switch (instruction[0])
                {
                    case 'F':
                        shipValueUp += upValue * value;
                        shipValueRight += rightValue * value;
                        break;
                    
                    case 'N':
                        upValue += value;
                        break;
                    
                    case 'E':
                        rightValue += value;
                        break;
                    
                    case 'S':
                        upValue -= value;
                        break;
                    
                    case 'W':
                        rightValue -= value;
                        break;
                    
                    case 'L':
                        if (value == 90)
                        {
                            int temp = upValue;
                            upValue = rightValue;
                            rightValue = temp * -1;
                        }
                        else if (value == 180)
                        {
                            upValue *= -1;
                            rightValue *= -1;
                        }
                        else if (value == 270)
                        {
                            int temp = upValue;
                            upValue = rightValue * -1;
                            rightValue = temp;
                        }
                        break;
                    case 'R':
                        if (value == 90)
                        {
                            int temp = upValue;
                            upValue = rightValue * -1;
                            rightValue = temp;
                        }
                        else if (value == 180)
                        {
                            upValue *= -1;
                            rightValue *= -1;
                        }
                        else if (value == 270)
                        {
                            int temp = upValue;
                            upValue = rightValue;
                            rightValue = temp * -1;
                        }
                        break;
                }
            }
            int distance = Math.Abs(shipValueUp) + Math.Abs(shipValueRight);
            return distance.ToString();
        }
    }
}
