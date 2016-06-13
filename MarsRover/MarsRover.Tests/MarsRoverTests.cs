using FluentAssertions;
using NUnit.Framework;

namespace MarsRover.Tests
{
    public class MarsRoverTests
    {
        [TestFixture]
        public class RoverShould
        {
            [Test]
            public void Point_east_when_turned_right_from_north()
            {
                var rover = new Rover();

                var position = rover.ExecuteInstructions("R");

                position.Should().Be("0 0 E");
            }

            [Test]
            public void Point_west_when_turned_left_from_north()
            {
                var rover = new Rover();

                var position = rover.ExecuteInstructions("L");

                position.Should().Be("0 0 W");
            }

            [Test]
            public void Point_south_when_turned_left_twice_from_north()
            {
                var rover = new Rover();

                var position = rover.ExecuteInstructions("LL");

                position.Should().Be("0 0 S");
            }

            [Test]
            public void Point_east_when_turned_left_thrice_from_north()
            {
                var rover = new Rover();

                var position = rover.ExecuteInstructions("LLL");

                position.Should().Be("0 0 E");
            }
        }
    }
}
