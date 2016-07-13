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
            [TestCase("", "2 2 N")]
            [TestCase("", "1 1 N", "1 1 N")]
            [TestCase("LLLL", "2 2 N")]
            [TestCase("LLL", "2 2 E")]
            [TestCase("LL", "2 2 S")]
            [TestCase("L", "2 2 W")]
            [TestCase("R", "2 2 E")]
            [TestCase("RR", "2 2 S")]
            [TestCase("RRR", "2 2 W")]
            [TestCase("RRRR", "2 2 N")]
            [TestCase("M", "2 3 N")]
            [TestCase("MM", "2 4 N")]
            [TestCase("RM", "3 2 E")]
            [TestCase("LM", "1 2 W")]
            [TestCase("LLM", "2 1 S")]
            public void Move_to_position_specified_by_instructions(string instructions, string expectedPosition, string startLocation = "2 2 N")
            {
                var rover = new Rover();

                var position = rover.ExecuteInstructions(instructions, startLocation);

                position.Should().Be(expectedPosition);
            }
        }
    }
}
