using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private const string Player1 = "player1";
        private const string Player2 = "player2";

        private int _player2Score;
        private int _player1Score;

        private string _player1Result = "";
        private string _player2Result = "";

        public string GetScore()
        {
            if (_player1Score == _player2Score)
            {
                return ConvertEqualScore();
            }

            if (_player1Score >= 4 || _player2Score >= 4)
            {
                return ConvertWinningScore();
            }

            return SetResultsAndConvertToScore();
        }

        private string ConvertWinningScore()
        {
            var winningPlayer = _player1Score > _player2Score
                ? Player1
                : Player2;

            var scoreDifference = Math.Abs(_player1Score - _player2Score);

            return scoreDifference == 1 
                ? "Advantage " + winningPlayer 
                : "Win for " + winningPlayer;
        }

        private string SetResultsAndConvertToScore()
        {
            _player1Result = ConvertScoreToText(_player1Score);
            _player2Result = ConvertScoreToText(_player2Score);

            return $"{_player1Result}-{_player2Result}";
        }

        private string ConvertEqualScore()
        {
            return _player1Score < 3 
                ? $"{ConvertScoreToText(_player1Score)}-All" 
                : "Deuce";
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

        public void WonPoint(string player)
        {
            if (player == Player1)
            {
                _player1Score++;
            }
            else
            {
                _player2Score++;
            }
        }

        public void SetP1Score(int number)
        {
            _player1Score += number;
        }

        public void SetP2Score(int number)
        {
            _player2Score += number;
        }
    }
}