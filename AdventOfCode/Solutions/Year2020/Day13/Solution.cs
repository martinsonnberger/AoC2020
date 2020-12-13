using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Solutions.Year2020
{

    class Day13 : ASolution
    {
        int myTimestamp;

        public Day13() : base(13, 2020, "")
        {
            myTimestamp = int.Parse(Input.SplitByNewline()[0]);
        }

        protected override string SolvePartOne()
        {
            int[] busses = Input.SplitByNewline()[1].ToIntArray(",");
            Dictionary<int,int> nextDepartures = new Dictionary<int, int>();
            foreach (var bus in busses)
            {
                int departure = (int) Math.Ceiling((double) myTimestamp / bus) * bus;
                nextDepartures.Add(bus, departure);
            }
            var min = nextDepartures.OrderBy(x => x.Value).First();
            long result = (min.Value - myTimestamp) * min.Key;
            return result.ToString();
        }

        protected override string SolvePartTwo()
        {
            string[] busIdStrings = Input.SplitByNewline()[1].Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<int> busIds = busIdStrings.Where(s => s != "x").Select(int.Parse).ToList();
            List<int> busIdOffsets = new List<int>(busIds.Count);
            for (int i = 0; i < busIdStrings.Length; i++)
            {       
                if (busIdStrings[i] != "x")
                {
                    busIdOffsets.Add(i % busIds[busIdOffsets.Count]);
                }
            }

            long time = 0;
            long increment = busIds[0];
            int correctBusIndex = 0;
            
            while (true)
            {
                bool found = true;
                for (int i = correctBusIndex + 1; i < busIds.Count; i++)
                {
                    int busId = busIds[i];
                    if (TimeLeft(busId, time) == busIdOffsets[i])
                    {
                        increment *= busId;
                        correctBusIndex = i;
                    }
                    else
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
                time += increment;
                Console.WriteLine(time);
            }
            return time.ToString();
        }

        int TimeLeft(int busId, long time)
        {
            int timeLeft = (int) (time % busId);
            if (timeLeft > 0)
            {
                timeLeft = busId - timeLeft;
            }
            return timeLeft;
        }
    }
}
