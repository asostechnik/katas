using System;
using System.Drawing;
using NUnit.Framework;

namespace TicTacToeCalisthenics.UnitTests
{
    [TestFixture]
    public class GameShould
    {

        [Test]
        public void Not_allow_O_to_start()
        {
            var game = new Game();

            Assert.Throws<Exception>(() => game.Draw(Mark.O, GridSquare.Square1));
        }

        [Test]
        public void Not_allow_draw_on_drawn_square()
        {
            var game = new Game();
            game.Draw(Mark.X, GridSquare.Square1);

            Assert.Throws<Exception>(() => game.Draw(Mark.O, GridSquare.Square1));
        }

        [Test]
        public void Not_allow_X_to_draw_twice()
        {
            var game = new Game();
            game.Draw(Mark.X, GridSquare.Square1);

            Assert.Throws<Exception>(() => game.Draw(Mark.X, GridSquare.Square2));
        }

        [Test]
        public void Not_allow_O_to_draw_twice()
        {
            var game = new Game();
            game.Draw(Mark.X, GridSquare.Square3);
            game.Draw(Mark.O, GridSquare.Square1);

            Assert.Throws<Exception>(() => game.Draw(Mark.O, GridSquare.Square2));
        }

        [Test]
        public void Declare_win_for_same_three_marks_in_first_row()
        {
            var game = new Game();
            var gameState = game.Draw(Mark.X, GridSquare.Square1);
            gameState = game.Draw(Mark.O, GridSquare.Square4);
            gameState = game.Draw(Mark.X, GridSquare.Square2);
            gameState = game.Draw(Mark.O, GridSquare.Square5);
            gameState = game.Draw(Mark.X, GridSquare.Square3);

            Assert.AreEqual(gameState, GameState.Win);
        }
    }
}
