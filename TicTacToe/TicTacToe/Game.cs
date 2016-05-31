using System;

namespace TicTacToe
{
    public class Game
    {
        private string square1x1;

        public void DrawForO(int x, int y)
        {
            if (square1x1 == null)
            throw new Exception();

            if (square1x1 != null)
                throw new InvalidOperationException();
        }

        public void DrawForX(int x, int y)
        {
            square1x1 = "X";
        }
    }
}
