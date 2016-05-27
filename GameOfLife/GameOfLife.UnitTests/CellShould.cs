using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace GameOfLife.UnitTests
{
    [TestFixture]
    public class CellShould
    {
        [Test]
        public void Die_With_0_Live_Neighbours()
        {
            var neighbours = new Neighbours();
            var cell = new LiveCell(neighbours);

            var cellState = cell.Tick();

            Assert.That(cellState, Is.TypeOf<DeadCell>());
        }

        [Test]
        public void Die_With_1_Live_Neighbours()
        {
            var neighbours = new Neighbours();
            neighbours.Add(new LiveCell(null));
            var cell = new LiveCell(neighbours);

            var cellState = cell.Tick();

            Assert.That(cellState, Is.TypeOf<DeadCell>());
        }

        [Test]
        public void Die_With_1_Live_Neighbour_And_1_Dead_Neighbour()
        {
            var neighbours = new Neighbours();
            neighbours.Add(new LiveCell(null));
            neighbours.Add(new DeadCell(null));
            var cell = new LiveCell(neighbours);

            var cellState = cell.Tick();

            Assert.That(cellState, Is.TypeOf<DeadCell>());
        }

        [Test]
        public void Remain_Live_With_2_Live_Neighbours()
        {
            var neighbours = new Neighbours();
            neighbours.Add(new LiveCell(null));
            neighbours.Add(new LiveCell(null));
            var cell = new LiveCell(neighbours);

            var cellState = cell.Tick();

            Assert.That(cellState, Is.TypeOf<LiveCell>());
        }

        [Test]
        public void Survive_With_3_Live_Neighbours()
        {
            var neighbours = new Neighbours();
            neighbours.Add(new LiveCell(null));
            neighbours.Add(new LiveCell(null));
            neighbours.Add(new LiveCell(null));
            var cell = new LiveCell(neighbours);

            var cellState = cell.Tick();

            Assert.That(cellState, Is.TypeOf<LiveCell>());
        }

        [Test]
        public void Die_With_4_Live_Neighbours()
        {
            var neighbours = new Neighbours();
            neighbours.Add(new LiveCell(null));
            neighbours.Add(new LiveCell(null));
            neighbours.Add(new LiveCell(null));
            neighbours.Add(new LiveCell(null));
            var cell = new LiveCell(neighbours);

            var cellState = cell.Tick();

            Assert.That(cellState, Is.TypeOf<DeadCell>());
        }

        [Test]
        public void Come_Back_To_Life_With_Three_Live_Neighbours()
        {
            var neighbours = new Neighbours();
            neighbours.Add(new LiveCell(null));
            neighbours.Add(new LiveCell(null));
            neighbours.Add(new LiveCell(null));

            var cell = new DeadCell(neighbours);

            var cellState = cell.Tick();

            Assert.That(cellState, Is.TypeOf<LiveCell>());
        }

       
    }
}
