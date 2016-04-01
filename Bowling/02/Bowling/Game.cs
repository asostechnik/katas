namespace Bowling
{
    public class Game
    {
        private const int MaxFrames = 10;

        private Frame[] _frames;

        private int _firstExtraRoll;
        private int _secondExtraRoll;

        public int CalculateScore(int[] rolls)
        {
            ParseRollsIntoFrames(rolls);

            var score = 0;
            for (var frameIndex = 0; frameIndex < MaxFrames; frameIndex++)
            {
                var frame = _frames[frameIndex];
                var frameScore = frame.Score;

                if (frame.IsStrike)
                {
                    if (IsLastFrameInGame(frameIndex))
                    {
                        frameScore += _firstExtraRoll + _secondExtraRoll;
                    }
                    else
                    {
                        frameScore += _frames[frameIndex + 1].Score;

                        if (IsNextFrameAStrike(frameIndex))
                        {
                            if (IsSecondToLastFrameInGame(frameIndex))
                            {
                                frameScore += _firstExtraRoll;
                            }
                            else
                            {
                                frameScore += _frames[frameIndex + 2].FirstRollScore;
                            }
                        }
                    }
                }

                if (frame.IsSpare)
                {
                    frameScore += IsLastFrameInGame(frameIndex)
                        ? _firstExtraRoll
                        : _frames[frameIndex + 1].FirstRollScore;
                }

                score += frameScore;
            }

            return score;
        }

        private bool IsNextFrameAStrike(int frameIndex)
        {
            return _frames[frameIndex + 1].IsStrike;
        }

        private static bool IsSecondToLastFrameInGame(int frameIndex)
        {
            return frameIndex == MaxFrames - 2;
        }

        private static bool IsLastFrameInGame(int frameIndex)
        {
            return frameIndex == MaxFrames - 1;
        }

        private void ParseRollsIntoFrames(int[] rolls)
        {
            _frames = new Frame[MaxFrames];

            var frame = 0;
            for (var roll = 0; roll < rolls.Length && frame < 10; roll += 2)
            {
                _frames[frame] = new Frame
                {
                    FirstRollScore = rolls[roll],
                    SecondRollScore = rolls[roll + 1]
                };
                frame++;
            }

            if (rolls.Length > 20) _firstExtraRoll = rolls[20];

            if (rolls.Length > 21) _secondExtraRoll = rolls[21];
        }
    }
}