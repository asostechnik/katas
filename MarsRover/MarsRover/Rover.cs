using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MarsRover
{
    public class Rover
    {
        private static readonly Dictionary<char, Command> CommandMap = new Dictionary<char, Command>()
        {
            {'L', Command.Left},
            {'R', Command.Right},
            {'M', Command.Move}
        };

        private static readonly Dictionary<char, Heading> HeadingMap = new Dictionary<char, Heading>()
        {
            {'N', Heading.North},
            {'E', Heading.East},
            {'S', Heading.South},
            {'W', Heading.West}
        };

        private static readonly Dictionary<Heading, Heading> SpinLeftFrom = new Dictionary<Heading, Heading>()
        {
            {Heading.North, Heading.West},
            {Heading.West, Heading.South},
            {Heading.South, Heading.East},
            {Heading.East, Heading.North},
        };

        private static readonly Dictionary<Heading, Heading> SpinRightFrom = new Dictionary<Heading, Heading>
        {
            {Heading.North, Heading.East},
            {Heading.East, Heading.South},
            {Heading.South, Heading.West},
            {Heading.West, Heading.North}
        };

        public string ExecuteInstructions(string instructions)
        {
            string position = "2 2"+" " +"N";
            foreach (var instruction in instructions)
            {
                var command = CommandMap[instruction];
                position = ExecuteCommand(position, command);
            }

            return position;
        }

        private static string ExecuteCommand(string position, Command command)
        {
            var positionParts = position.Split(' ');
            var currentLocationX = positionParts[0];
            var currentLocationY = positionParts[1];
            var heading = HeadingMap[positionParts[2].Single()];

            if (command == Command.Right)
            {
                heading = SpinRightFrom[heading];
            }

            if (command == Command.Left)
            {
                heading = SpinLeftFrom[heading];
            }

            string newLocation = "2 2";
            if (command == Command.Move)
            {
                if (heading == Heading.North)
                {
                    newLocation = MoveNorth(int.Parse(currentLocationX), int.Parse(currentLocationY));
                }

                if (heading == Heading.East)
                {
                    newLocation = MoveEast(int.Parse(currentLocationX), int.Parse(currentLocationY));
                }
            }

            return newLocation + " " + heading.ToString().First();
        }

        private static string MoveNorth(int currentLocationX, int currentLocationY)
        {
            return $"{currentLocationX} {currentLocationY + 1}";
        }

        private static string MoveEast(int currentLocationX, int currentLocationY)
        {
            return $"{currentLocationX + 1} {currentLocationY}";
        }
    }
}