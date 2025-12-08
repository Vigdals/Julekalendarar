using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Julekalendarar
{
    public class Day1
    {
        public static int Solve(string[] lines, bool debug = false)
        {
            int dialPosition = 50;
            int timesAtZero = 0;
            const int dialSize = 100;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                char direction = line[0];
                int steps = int.Parse(line.Substring(1));

                int delta = direction == 'R' ? steps : -steps;

                dialPosition = (dialPosition + delta) % dialSize;
                if (dialPosition < 0)
                    dialPosition += dialSize;

                if (dialPosition == 0)
                    timesAtZero++;
                    if (debug)
                {
                    Console.WriteLine($"Moved {direction}{steps}, new position: {dialPosition}");
                }
            }

            return timesAtZero;
        }
        public static int SolvePartTwo(string[] lines, bool debug = false)
        {
            int dialPosition = 50;
            int timesPastZero = 0;
            const int dialSize = 100;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                char direction = line[0];
                int steps = int.Parse(line.Substring(1));

                // If direction is 'R', delta is set to steps (positive movement). If 'L', delta is negative.
                int delta = direction == 'R' ? steps : -steps;

                dialPosition = (dialPosition + delta) % dialSize;
                if (dialPosition < 0)
                    dialPosition += dialSize;

                if (dialPosition == 0)
                    timesPastZero++;
                    
                if (debug)
                {
                    Console.WriteLine($"Moved {direction}{steps}, new position: {dialPosition}");
                }
            }

            return timesPastZero;
        }
    }
}