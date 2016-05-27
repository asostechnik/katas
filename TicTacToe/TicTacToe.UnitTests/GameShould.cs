using System;
using NUnit.Framework;

namespace TicTacToe.UnitTests
{
    [TestFixture]
    public class GameShould
    {
        [Test]
        public void Not_Allow_O_To_Start()
        {
            var game = new Game();
            Assert.Throws<Exception>(() => game.DrawForO(1, 1));
        }

        [Test]
        public void Allow_X_To_Start()
        {
            var game = new Game();
            Assert.DoesNotThrow(() => game.DrawForX(1, 1));
        }

        [Test]
        public void Not_Allow_Move_Onto_Drawn_Square()
        {
            var game = new Game();

            game.DrawForX(1, 1);

            Assert.Throws<InvalidOperationException>(() => game.DrawForO(1, 1));
        }


    }
}
