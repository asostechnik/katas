using System;
using System.Linq;

namespace TicTacToeCalisthenics
{
    public class Game
    {
        private readonly Mark[] _marks = new Mark[9];

        private Mark _lastMarkDrawn;

        public GameState Draw(Mark mark, GridSquare square)
        {
            if (_lastMarkDrawn == Mark.Empty && mark == Mark.O)
            {
                throw new Exception();
            }

            if (_marks[(int)square] != Mark.Empty)
            {
                throw new Exception();
            }

            if (_lastMarkDrawn == mark)
            {
                throw new Exception();
            }

            _marks[(int)square] = mark;
            _lastMarkDrawn = mark;

            if (_marks.Take(3).All(m => m == mark))
            {
                return GameState.Win;
            }

            return GameState.Undefined;
        }
    }

    public enum GameState
    {
        Undefined,
        Win
    }
}