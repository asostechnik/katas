using FluentAssertions;

using NUnit.Framework;

namespace Bowling.UnitTests
{
    public class FrameTests
    {
        [TestFixture]
        public class FrameShould
        {
            [Test]
            public void Store_two_roll_scores()
            {
                //arrange
                var frame = new Frame();

                //act
                frame.FirstRollScore = 1;
                frame.SecondRollScore = 2;

                //assert
                frame.FirstRollScore.Should().Be(1);
                frame.SecondRollScore.Should().Be(2);
            }

            [Test]
            public void Add_roll_scores_together_to_give_frame_score()
            {
                //arrange
                var frame = new Frame { FirstRollScore = 1, SecondRollScore = 2 };

                //act
                var frameScore = frame.Score;

                //assert
                frameScore.Should().Be(3);
            }

            [Test]
            public void Be_a_strike_if_first_roll_score_is_10()
            {
                //arrange
                var frame = new Frame();

                //act
                frame.FirstRollScore = 10;

                //assert
                frame.IsStrike.Should().BeTrue();
            }

            [Test]
            public void Be_a_spare_if_frame_score_is_10()
            {
                //arrange
                var frame = new Frame();

                //act
                frame.FirstRollScore = 1;
                frame.SecondRollScore = 9;

                //assert
                frame.IsSpare.Should().BeTrue();
            }
        }
    }
}
