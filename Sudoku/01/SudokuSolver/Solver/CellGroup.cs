using System.Linq;

namespace Solver
{
    public class CellGroup
    {
        public Cell Cell1 => _cells[0];
        public Cell Cell2 => _cells[1];
        public Cell Cell3 => _cells[2];
        public Cell Cell4 => _cells[3];
        public Cell Cell5 => _cells[4];
        public Cell Cell6 => _cells[5];
        public Cell Cell7 => _cells[6];
        public Cell Cell8 => _cells[7];
        public Cell Cell9 => _cells[8];

        private readonly Cell[] _cells = new Cell[9];

        public CellGroup(Cell cell1, Cell cell2, Cell cell3, Cell cell4, Cell cell5, Cell cell6, Cell cell7, Cell cell8, Cell cell9)
        {
            _cells[0] = cell1;
            _cells[1] = cell2;
            _cells[2] = cell3;
            _cells[3] = cell4;
            _cells[4] = cell5;
            _cells[5] = cell6;
            _cells[6] = cell7;
            _cells[7] = cell8;
            _cells[8] = cell9;
        }


        public bool ValidateCellValues()
        {
            return _cells.Distinct().Count() == 9;
        }
    }
}
