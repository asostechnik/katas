using NUnit.Framework;
using FluentAssertions;

namespace Bowling.UnitTests
{
    public class GameTests
    {
        [TestFixture]
        public class GameShould
        {
            [TestCase(new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0)]
            [TestCase(new[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 1)]
            [TestCase(new[] { 5, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 12)]
            [TestCase(new[] { 1, 2, 5, 5, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 17)]
            [TestCase(new[] { 10, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 14)]
            [TestCase(new[] { 10, 0, 10, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 60)]
            [TestCase(new[] { 5, 5, 10, 0, 10, 0, 5, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 77)]
            [TestCase(new[] { 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 10 }, 300)]
            public void Calculate_Score(int[] rolls, int expectedScore)
            {
                //arrange
                var game = new Game();

                //act
                var score = game.CalculateScore(rolls);

                //aasert
                score.Should().Be(expectedScore);
            }
        }
    }
}
