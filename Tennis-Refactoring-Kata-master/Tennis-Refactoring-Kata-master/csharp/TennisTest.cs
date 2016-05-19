using System;
using NUnit.Framework;

namespace Tennis
{
    [TestFixture(0, 0, "Love-All")]
    [TestFixture(1, 1, "Fifteen-All")]
    [TestFixture(2, 2, "Thirty-All")]
    [TestFixture(3, 3, "Deuce")]
    [TestFixture(4, 4, "Deuce")]
    [TestFixture(1, 0, "Fifteen-Love")]
    [TestFixture(0, 1, "Love-Fifteen")]
    [TestFixture(2, 0, "Thirty-Love")]
    [TestFixture(0, 2, "Love-Thirty")]
    [TestFixture(3, 0, "Forty-Love")]
    [TestFixture(0, 3, "Love-Forty")]
    [TestFixture(4, 0, "Win for player1")]
    [TestFixture(0, 4, "Win for player2")]
    [TestFixture(2, 1, "Thirty-Fifteen")]
    [TestFixture(1, 2, "Fifteen-Thirty")]
    [TestFixture(3, 1, "Forty-Fifteen")]
    [TestFixture(1, 3, "Fifteen-Forty")]
    [TestFixture(4, 1, "Win for player1")]
    [TestFixture(1, 4, "Win for player2")]
    [TestFixture(3, 2, "Forty-Thirty")]
    [TestFixture(2, 3, "Thirty-Forty")]
    [TestFixture(4, 2, "Win for player1")]
    [TestFixture(2, 4, "Win for player2")]
    [TestFixture(4, 3, "Advantage player1")]
    [TestFixture(3, 4, "Advantage player2")]
    [TestFixture(5, 4, "Advantage player1")]
    [TestFixture(4, 5, "Advantage player2")]
    [TestFixture(15, 14, "Advantage player1")]
    [TestFixture(14, 15, "Advantage player2")]
    [TestFixture(6, 4, "Win for player1")]
    [TestFixture(4, 6, "Win for player2")]
    [TestFixture(16, 14, "Win for player1")]
    [TestFixture(14, 16, "Win for player2")]
    [TestFixture(1, 1, "Fifteen-All")]
    [TestFixture(2, 2, "Thirty-All")]
    [TestFixture(3, 3, "Deuce")]
    [TestFixture(1, 0, "Fifteen-Love")]
    [TestFixture(2, 0, "Thirty-Love")]
    [TestFixture(3, 0, "Forty-Love")]
    [TestFixture(0, 1, "Love-Fifteen")]
    [TestFixture(0, 2, "Love-Thirty")]
    [TestFixture(0, 3, "Love-Forty")]
    public class TennisTest
    {
        private const string Player1Name = "player1";
        private const string Player2Name = "player2";
        private readonly int _player1Score;
        private readonly int _player2Score;
        private readonly string _expectedScore;

        public TennisTest(int player1Score, int player2Score, string expectedScore)
        {
            _player1Score = player1Score;
            _player2Score = player2Score;
            _expectedScore = expectedScore;
        }

        public void CheckAllScores(ITennisGame game)
        {
            var highestScore = Math.Max(_player1Score, _player2Score);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < _player1Score)
                    game.WonPoint(Player1Name);
                if (i < _player2Score)
                    game.WonPoint(Player2Name);
            }
            Assert.AreEqual(_expectedScore, game.GetScore());
        }

        [Test]
        public void CheckTennisGame1()
        {
            var game = new TennisGame1(Player1Name, Player2Name);
            CheckAllScores(game);
        }

        [Test]
        public void CheckTennisGame2()
        {
            var game = new TennisGame2(Player1Name, Player2Name);
            CheckAllScores(game);
        }

        [Test]
        public void TennisGame2ShouldAddScoreForPlayer1()
        {
            var game = new TennisGame2(Player1Name, Player2Name);

            game.SetP1Score(1);
            game.SetP1Score(1);

            Assert.That(game.Player1Score, Is.EqualTo(2));
        }

        [Test]
        public void TennisGame2ShouldAddScoreForPlayer2()
        {
            var game = new TennisGame2(Player1Name, Player2Name);

            game.SetP2Score(1);
            game.SetP2Score(1);

            Assert.That(game.Player2Score, Is.EqualTo(2));
        }

        [Test]
        public void CheckTennisGame3()
        {
            var game = new TennisGame3(Player1Name, Player2Name);
            CheckAllScores(game);
        }
    }
}