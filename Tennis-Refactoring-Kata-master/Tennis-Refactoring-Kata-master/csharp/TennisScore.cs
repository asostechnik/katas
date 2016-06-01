namespace Tennis
{
    public class TennisScore
    {
        public int Score { get; private set; }

        public void AddPoint()
        {
            Score++;
        }

        public override string ToString()
        {
            switch (Score)
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
                    return "";
            }
        }
    }
}