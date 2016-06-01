using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private readonly TennisScore _player1Score = new TennisScore();
        private readonly TennisScore _player2Score = new TennisScore();

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Score.AddPoint();
            else
                _player2Score.AddPoint();
        }

        public string GetScore()
        {
            if (_player1Score.Score == _player2Score.Score)
            {
                return ConvertEqualScore();
            }

            if (_player1Score.Score >= 4 || _player2Score.Score >= 4)
            {
                return ConvertWinningScore();
            }

            return $"{_player1Score}-{_player2Score}";
        }

        private string ConvertEqualScore()
        {
            return (_player1Score.Score < 3)
                ? $"{_player1Score}-All"
                : "Deuce";
        }

        private string ConvertWinningScore()
        {
            var winningPlayer = (_player1Score.Score > _player2Score.Score)
                ? "player1"
                : "player2";

            var scoreDifference = Math.Abs(_player1Score.Score - _player2Score.Score);
            return scoreDifference == 1
                ? "Advantage " + winningPlayer
                : "Win for " + winningPlayer;
        }
    }
}