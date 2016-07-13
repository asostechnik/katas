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

        public string ExecuteInstructions(string instructions, string startLocation = "2 2")
        {
            string position = startLocation+" " +"N";
            foreach (var instruction in instructions)
            {
                var command = CommandMap[instruction];
                position = ExecuteCommand(position, command, startLocation);
            }

            return position;
        }

        private static string ExecuteCommand(string position, Command command, string startLocation)
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

            if (command == Command.Move)
            {
                startLocation = Move(heading, currentLocationX, currentLocationY);
            }

            return startLocation + " " + heading.ToString().First();
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
}