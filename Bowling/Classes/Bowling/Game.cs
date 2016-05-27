using System.Linq;

namespace Bowling
{
    public class Frame
    {
        private readonly int _firstRoll;
        private int _secondRoll;

        public Frame(int firstRoll, int secondRoll)
        {
            _firstRoll = firstRoll;
            _secondRoll = secondRoll;
        }

        public bool IsStrike()
        {
            return _firstRoll == 10;
        }
    }

    public class Game
    {
        private int[] _rolls;

        public int CalculateScore(int[] rolls)
        {
            _rolls = rolls;

            var score = 0;

            for (var roll = 0; roll < _rolls.Length; roll += 2)
            {
                var frame = new Frame(rolls[roll], rolls[roll+1]);

                var additionalScore = 0;

                if (frame.IsStrike() && !IsExtraRoll(roll + 2))
                {
                    additionalScore = FrameScore(roll, 2);

                    if (IsStrike(roll + 2) && !IsExtraRoll(roll + 2))
                    {
                        additionalScore += _rolls[roll + 4];
                    }
                }

                if (IsSpare(roll))
                {
                    additionalScore = _rolls[roll + 2];
                }

                score += FrameScore(roll) + additionalScore;
            }

            return score;
        }

        private int FrameScore(int roll, int rollOffset = 0)
        {
            return _rolls[roll + rollOffset] + _rolls[roll + rollOffset + 1];
        }

        private bool IsSpare(int roll)
        {
            return !IsStrike(roll) && (_rolls[roll] + _rolls[roll + 1]) == 10;
        }

        private bool IsStrike(int roll)
        {
            return !IsExtraRoll(roll) && _rolls[roll] == 10;
        }

        private static bool IsExtraRoll(int roll)
        {
            return roll > 19;
        }
    }
}