using System;
using NUnit.Framework;

namespace Tennis
{
    [TestFixture]
    public class TennisGame1Should : TennisTests
    {
        private static object[] TestData => TennisTestCaseData.GetTestCases(new TennisGame1("player1", "player2"));

        [TestCaseSource(nameof(TestData))]
        public void ConvertScoresToResults(ITennisGame game, int player1Score, int player2Score, string expectedScore)
        {
            CheckAllScores(game, player1Score, player2Score, expectedScore);
        }
    }

    [TestFixture]
    public class TennisGame2Should : TennisTests
    {
        private static object[] TestData => TennisTestCaseData.GetTestCases(new TennisGame2("player1", "player2"));

        [TestCaseSource(nameof(TestData))]
        public void ConvertScoresToResults(ITennisGame game, int player1Score, int player2Score, string expectedScore)
        {
            CheckAllScores(game, player1Score, player2Score, expectedScore);
        }
    }

    [TestFixture]
    public class TennisGame3Should : TennisTests
    {
        private static object[] TestData => TennisTestCaseData.GetTestCases(new TennisGame3("player1", "player2"));

        [TestCaseSource(nameof(TestData))]
        public void ConvertScoresToResults(ITennisGame game, int player1Score, int player2Score, string expectedScore)
        {
            CheckAllScores(game, player1Score, player2Score, expectedScore);
        }
    }

    public class TennisTests
    {
        protected void CheckAllScores(ITennisGame game, int player1Score, int player2Score, string expectedScore)
        {
            var highestScore = Math.Max(player1Score, player2Score);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < player1Score)
                    game.WonPoint("player1");
                if (i < player2Score)
                    game.WonPoint("player2");
            }
            Assert.AreEqual(expectedScore, game.GetScore());
        }
    }
}