namespace GameOfLife
{
    public abstract class Cell
    {
        protected readonly Neighbours _neighbours;

        protected Cell(Neighbours neighbours)
        {
            _neighbours = neighbours;
        }

        public abstract Cell Tick();
    }
}