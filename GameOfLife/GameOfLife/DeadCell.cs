using System.Linq;

namespace GameOfLife
{
    public class DeadCell : Cell
    {
        public DeadCell(Neighbours neighbours) 
            : base(neighbours)
        {
        }

        public override Cell Tick()
        {
            var liveNeighbours = _neighbours.OfType<LiveCell>().Count();

            if (liveNeighbours == 3)
            {
                return new LiveCell(_neighbours);
            }

            return this;
        }
    }
}