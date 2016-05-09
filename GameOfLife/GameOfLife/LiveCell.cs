using System.Linq;

namespace GameOfLife
{
    public class LiveCell : Cell
    {
        public LiveCell(Neighbours neighbours) 
            : base(neighbours)
        {
        }

        public override Cell Tick()
        {
            var liveNeighbours = _neighbours.OfType<LiveCell>().Count();

            if (liveNeighbours < 2 || liveNeighbours > 3)
            {
                return new DeadCell(_neighbours);
            }

            return this;
        }
    }
}