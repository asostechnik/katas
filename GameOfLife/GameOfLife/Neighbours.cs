using System.Collections.Concurrent;

namespace GameOfLife
{
    public class Neighbours : ConcurrentBag<Cell>
    {
    }
}