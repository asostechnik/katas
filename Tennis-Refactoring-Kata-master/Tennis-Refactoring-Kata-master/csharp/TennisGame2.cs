namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        public int Player2Score;
        public int Player1Score;

        public string Player1Result = "";
        public string Player2Result = "";

        private string _player1Name;
        private string _player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            if (Player1Score == Player2Score && Player1Score < 3)
            {
                return $"{ConvertScoreToText(Player1Score)}-All";
            }

            if (Player1Score == Player2Score && Player1Score > 2)
                return "Deuce";

            var winningPlayer = Player1Score > Player2Score 
                ? "player1" 
                : "player2";

            if (Player1Score >= 4 && Player2Score >= 0 && Player1Score - Player2Score >= 2 ||
                Player2Score >= 4 && Player1Score >= 0 && Player2Score - Player1Score >= 2)
            {
                return "Win for " + winningPlayer;
            }

            if (Player1Score > Player2Score && Player2Score >= 3 || 
                Player2Score > Player1Score && Player1Score >= 3)
            {
                return "Advantage " + winningPlayer;
            }

            Player1Result = ConvertScoreToText(Player1Score);
            Player2Result = ConvertScoreToText(Player2Score); ;

            return Player1Result + "-" + Player2Result;
        }

        private static string ConvertScoreToText(int scoreToConvert)
        {
            switch (scoreToConvert)
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
            if (player == "player1")
            {
                Player1Score++;
            }
            else
            {
                Player2Score++;
            }
        }

        public void SetP1Score(int number)
        {
            Player1Score += number;
        }

        public void SetP2Score(int number)
        {
            Player2Score += number;
        }
    }
}