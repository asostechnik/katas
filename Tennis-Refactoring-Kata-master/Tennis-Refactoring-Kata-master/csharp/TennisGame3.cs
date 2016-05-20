namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int _player1Score;
        private int _player2Score;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame3(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            if (_player1Score < 4 && _player2Score < 4 && (_player1Score + _player2Score < 6))
            {
                string[] scoreNames = { "Love", "Fifteen", "Thirty", "Forty" };

                return _player1Score == _player2Score
                    ? $"{scoreNames[_player1Score]}-All"
                    : $"{scoreNames[_player1Score]}-{scoreNames[_player2Score]}";
            }

            if (_player1Score == _player2Score)
            {
                return "Deuce";
            }

            var winningPlayer = _player1Score > _player2Score
                ? _player1Name
                : _player2Name;

            return (_player1Score - _player2Score) * (_player1Score - _player2Score) == 1
                ? "Advantage " + winningPlayer
                : "Win for " + winningPlayer;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                _player1Score += 1;
            }
            else
            {
                _player2Score += 1;
            }
        }
    }
}