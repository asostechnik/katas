using System;

namespace Solver
{
    public class Cell
    {
        public int? Value { get; private set; }
        public int Answer { get; private set; }

        public Cell(int correctAnswer)
        {
            if (!CheckVaueIsInRange(correctAnswer))
                throw new ArgumentOutOfRangeException(nameof(correctAnswer));

            Answer = correctAnswer;
        }

        public void SetValue(int value)
        {
            if (!CheckVaueIsInRange(value))
                throw new ArgumentOutOfRangeException(nameof(value));

            Value = value;
        }

        public void ClearValue()
        {
            Value = null;
        }

        public bool CheckValueIsInCellGroups(int value)
        {
            
        }

        private bool CheckVaueIsInRange(int value)
        {
            return value >= 1 & value <= 9;
        }

    }
}
