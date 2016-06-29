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

        public string ExecuteInstructions(string instructions)
        {
            var position = "0 0 N";
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
                heading = SpinRight(heading);
            }

            if (command == Command.Left)
            {
                heading = SpinLeft(heading);
            }

            string newLocation = "0 0";
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

        private static Heading SpinLeft(Heading orientation)
        {
            if (orientation == Heading.North)
            {
                return Heading.West;
            }

            if (orientation == Heading.West)
            {
                return Heading.South;
            }

            if (orientation == Heading.South)
            {
                return Heading.East;
            }

            if (orientation == Heading.East)
            {
                return Heading.North;
            }

            return Heading.NotSet;
        }

        private static Heading SpinRight(Heading orientation)
        {
            if (orientation == Heading.North)
            {
                return Heading.East;
            }

            if (orientation == Heading.East)
            {
                return Heading.South;
            }

            if (orientation == Heading.South)
            {
                return Heading.West;
            }

            if (orientation == Heading.West)
            {
                return Heading.North;
            }

            throw new InvalidOperationException();
        }
    }
}