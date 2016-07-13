using System;
using System.Collections.Generic;
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

        public string ExecuteInstructions(string instructions, string startPosition = "2 2 N")
        {
            foreach (var instruction in instructions)
            {
                var command = CommandMap[instruction];
                startPosition = ExecuteCommand(startPosition, command);
            }

            return startPosition;
        }

        private static string ExecuteCommand(string position, Command command)
        {
            var parsedPosition = new Position(position);
            var heading = parsedPosition.Heading;

            if (command == Command.Right)
            {
                heading = SpinRightFrom[heading];
            }

            if (command == Command.Left)
            {
                heading = SpinLeftFrom[heading];
            }

            var newLocation = position.Substring(0,3);
            if (command == Command.Move)
            {
                newLocation = Move(position);
            }

            return newLocation + " " + heading.ToString().First();
        }

        private static string Move(string position)
        {
            var positionParts = position.Split(' ');
            var heading = Position.HeadingMap[positionParts[2].Single()];

            return Move(heading, positionParts[0], positionParts[1]);
        }

        private static string Move(Heading currentHeading, string currentLocationX, string currentLocationY)
        {
            var newLocationX = int.Parse(currentLocationX);
            var newLocationY = int.Parse(currentLocationY);

            switch (currentHeading)
            {
                case Heading.North:
                    newLocationY++;
                    break;
                case Heading.East:
                    newLocationX++;
                    break;
                case Heading.West:
                    newLocationX--;
                    break;
                case Heading.South:
                    newLocationY--;
                    break;
            }

            return $"{newLocationX} {newLocationY}";
        }
    }

    internal class Position
    {
        public Position(string position)
        {
            this.Heading = HeadingMap[position[4]];
        }

        public Heading Heading { get; private set; }

        public static readonly Dictionary<char, Heading> HeadingMap = new Dictionary<char, Heading>()
        {
            {'N', Heading.North},
            {'E', Heading.East},
            {'S', Heading.South},
            {'W', Heading.West}
        };
    }
}