namespace Bowling
{
    public class Game
    {
        public int CalculateScore(int[] rolls)
        {
            var score = 0;
            for (var roll = 0; roll < rolls.Length; roll += 2)
            {
                var frameScore = rolls[roll] + rolls[roll + 1];
                var additionalScore = 0;

                if (IsStrike(rolls, roll) && !IsExtraRoll(roll + 2))
                {
                    additionalScore = rolls[roll + 2] + rolls[roll + 3];
                    if (IsStrike(rolls, roll + 2) && !IsExtraRoll(roll + 2))
                        additionalScore += rolls[roll + 4];
                }

                if (IsSpare(rolls, roll))
                {
                    additionalScore = rolls[roll + 2];
                }

                score += frameScore + additionalScore;
            }

            return score;
        }

        private static bool IsSpare(int[] rolls, int roll)
        {
            return !IsStrike(rolls, roll) && (rolls[roll] + rolls[roll + 1]) == 10;
        }

        private static bool IsStrike(int[] rolls, int roll)
        {
            return !IsExtraRoll(roll) && rolls[roll] == 10;
        }

        private static bool IsExtraRoll(int roll)
        {
            return roll > 19;
        }
    }
}