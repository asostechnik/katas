using System;
using FluentAssertions;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class MarsRoverTests
    {
        [TestFixture]
        public class RoverShould
        {
            [TestCase("LLLL", "0 0 N")]
            [TestCase("LLL", "0 0 E")]
            [TestCase("LL", "0 0 S")]
            [TestCase("L", "0 0 W")]
            [TestCase("R", "0 0 E")]
            [TestCase("", "0 0 N")]
            [TestCase("M", "0 1 N")]
            public void Move_to_position_specified_by_instructions(string instructions, string expectedPosition)
            {
                var rover = new Rover();

                var position = rover.ExecuteInstructions(instructions);

                position.Should().Be(expectedPosition);
            }
        }
    }
}
