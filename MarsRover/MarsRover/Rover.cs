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
                position = ExecuteInstruction(position, command);
            }

            return position;
        }

        private static string ExecuteInstruction(string position, Command command)
        {
            var heading = HeadingMap[position.Last()];

            if (command == Command.Right)
            {
                heading = SpinRight(heading);
            }

            if (command == Command.Left)
            {
                heading = SpinLeft(heading);
            }

            return "0 0 " + heading.ToString().First();
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

            throw new InvalidOperationException();
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