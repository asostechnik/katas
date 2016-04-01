namespace Bowling
{
    public class Frame
    {
        public int FirstRollScore { get; set; }

        public int SecondRollScore { get; set; }

        public int Score => FirstRollScore + SecondRollScore;

        public bool IsStrike => FirstRollScore == 10;

        public bool IsSpare => !IsStrike && Score == 10;
    }
}