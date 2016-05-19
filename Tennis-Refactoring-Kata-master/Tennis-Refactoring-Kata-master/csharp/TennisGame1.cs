using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _player1Score;
        private int _player2Score;

        public TennisGame1(string player1Name, string player2Name)
        {
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Score += 1;
            else
                _player2Score += 1;
        }

        public string GetScore()
        {
            if (_player1Score == _player2Score)
            {
                return ConvertEqualScoreToText(_player1Score);
            }

            if (_player1Score >= 4 || _player2Score >= 4)
            {
                return ConvertWinningScoreToText(_player1Score, _player2Score);
            }

            return $"{ConvertScoreToText(_player1Score)}-{ConvertScoreToText(_player2Score)}";
        }

        private static string ConvertEqualScoreToText(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }

        private static string ConvertWinningScoreToText(int score1, int score2)
        {
            var winningPlayer = (score1 > score2)
                ? "player1"
                : "player2";

            var scoreDifference = Math.Abs(score1 - score2);
            return scoreDifference == 1
                ? "Advantage " + winningPlayer
                : "Win for " + winningPlayer;
        }

        private static string ConvertScoreToText(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    return null;
            }
        }
    }
}