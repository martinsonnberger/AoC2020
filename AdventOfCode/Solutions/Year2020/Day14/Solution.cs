using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AdventOfCode.Solutions.Year2020
{

    class Day14 : ASolution
    {
        string[] lines;
        public Day14() : base(14, 2020, "")
        {
            lines = Input.SplitByNewline();
        }

        protected override string SolvePartOne()
        {
            ulong[] memory = new ulong[100000];
            string mask = "";
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(" = ");
                if (line[0] == "mask")
                {
                    mask = line[1];
                }
                else
                {
                    ulong adress = ulong.Parse(line[0].Substring(4, line[0].Length - 5));
                    ulong value = ulong.Parse(line[1]);
                    string binary = Convert.ToString((long) value, 2).PadLeft(36, '0');
                    char[] finalValue = new char[36];

                    for (int j = 0; j < binary.Length; j++)
                    {
                        if (mask[j] == 'X')
                        {
                            finalValue[j] = binary[j];
                        }
                        else
                        {
                            finalValue[j] = mask[j];
                        }
                    }
                    string stringValue = new string(finalValue);

                    memory[adress] = Convert.ToUInt64(stringValue, 2);
                }
            }
            ulong sum = 0;
            for (int i = 0; i < memory.Length; i++)
            {
                sum += memory[i];
            }
        
            return sum.ToString();
        }

        protected override string SolvePartTwo()
        {
            var memory = new Dictionary<ulong, ulong>();
            adresses = new List<ulong>();
            string mask = "";
            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(" = ");
                if (line[0] == "mask")
                {
                    mask = line[1];
                }
                else
                {
                    adresses.Clear();
                    ulong adress = ulong.Parse(line[0].Substring(4, line[0].Length - 5));
                    ulong value = ulong.Parse(line[1]);
                    string binaryAdress = Convert.ToString((long) adress, 2).PadLeft(36, '0');
                    char[] adressFloating = new char[36];

                    for (int j = 0; j < adressFloating.Length; j++)
                    {
                        if (mask[j] == '0')
                        {
                            adressFloating[j] = binaryAdress[j];
                        }
                        else
                        {
                            adressFloating[j] = mask[j];
                        }
                    }
                    AllAdresses(new string(adressFloating));
                    foreach (var item in adresses)
                    {
                        memory[item] = value;
                    }
                }
            }
            
            ulong sum = 0;

            foreach (var item in memory)
            {
                sum += item.Value;
            }
            
            return sum.ToString();
        }

        List<ulong> adresses;

        void AllAdresses(string floatingAdress)
        {
            if (floatingAdress.Contains('X') == false)
            {
                adresses.Add(Convert.ToUInt64(floatingAdress, 2));
                return;
            }
            else
            {
                string first = ReplaceFirst(floatingAdress, "X", "0");
                string second = ReplaceFirst(floatingAdress, "X", "1");
                AllAdresses(first);
                AllAdresses(second);
            }
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
    }
}
