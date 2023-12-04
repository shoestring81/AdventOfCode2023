using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public class Day2Game
    {
        public int ID { get; set; }

        public List<Day2Roll> Rolls { get; set; } = new List<Day2Roll>();

        public Day2Game(string line)
        {
            var gameTokens = line.Trim().Split(":");

            var header = gameTokens[0];
            var headerTokens = header.Split(" ");
            this.ID = int.Parse(headerTokens[1]);
            
            var rolls = gameTokens[1];
            var rollTokens = rolls.Split(";");

            foreach (var rollToken in rollTokens)
            {
                //Console.WriteLine($"{ID}: {rollToken}");
                var roll = new Day2Roll();

                var colorTokens = rollToken.Split(",");
                foreach (var colorToken in colorTokens)
                {
                    var colorSubToken = colorToken.Trim().Split(" ");
                    switch (colorSubToken[1])
                    {
                        case "red":
                            roll.Red = int.Parse(colorSubToken[0]);
                            break;
                        case "blue":
                            roll.Blue = int.Parse(colorSubToken[0]);
                            break;
                        case "green":
                            roll.Green = int.Parse(colorSubToken[0]);
                            break;
                    }
                }

                Rolls.Add(roll);
            }
        }

        public bool IsValid(int maxRed, int maxBlue, int maxGreen)
        {
            foreach (var roll in Rolls)
            {
                if (!roll.IsValid(maxRed, maxBlue, maxGreen))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetPower()
        {
            int minRed = 0, minBlue = 0, minGreen = 0;

            foreach (var roll in Rolls)
            {
                if (roll.Red > minRed)
                {
                    minRed = roll.Red;
                }

                if (roll.Blue > minBlue)
                {
                    minBlue = roll.Blue;
                }

                if (roll.Green > minGreen)
                {
                    minGreen = roll.Green;
                }
            }

            return minRed * minBlue * minGreen;
        }
    }

    public class Day2Roll
    {
        public int Red { get; set; }

        public int Blue { get; set; }

        public int Green { get; set; }

        public bool IsValid(int maxRed, int maxBlue, int maxGreen)
        {
            return Red <= maxRed && Blue <= maxBlue && Green <= maxGreen;
        }
    }
}
