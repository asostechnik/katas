using FluentAssertions;
using NUnit.Framework;

namespace Solver.Tests
{
    public class CellGroupTests
    {
        [TestFixture]
        public class A_Cell_Group_Should
        {
            [Test]
            public void Pass_Validation_If_All_Cells_Have_Unique_Values()
            {
                //arrange
                var cell1 = CreateCell(1, 1);
                var cell2 = CreateCell(2, 2);
                var cell3 = CreateCell(3, 3);
                var cell4 = CreateCell(4, 4);
                var cell5 = CreateCell(5, 5);
                var cell6 = CreateCell(6, 6);
                var cell7 = CreateCell(7, 7);
                var cell8 = CreateCell(8, 8);
                var cell9 = CreateCell(9, 9);

                var cellGroup = new CellGroup(cell1, cell2, cell3, cell4, cell5, cell6, cell7, cell8, cell9);

                //act
                var validationResult = cellGroup.ValidateCellValues();

                //assert
                validationResult.Should().BeTrue();
            }

            [Test]
            public void Fail_Validation_If_All_Cells_Do_Not_Have_Unique_Values()
            {
                //arrange
                var cell1 = CreateCell(1, 1);
                var cell2 = CreateCell(2, 2);
                var cell3 = CreateCell(3, 3);
                var cell4 = CreateCell(4, 4);
                var cell5 = CreateCell(5, 5);
                var cell6 = CreateCell(6, 6);
                var cell7 = CreateCell(7, 7);
                var cell8 = CreateCell(8, 8);
                var cell9 = CreateCell(1, 1);

                var cellGroup = new CellGroup(cell1, cell2, cell3, cell4, cell5, cell6, cell7, cell8, cell9);

                //act
                var validationResult = cellGroup.ValidateCellValues();

                //assert
                validationResult.Should().BeTrue();
            }

            [Test]
            public void Fail_Validation_If_Any_Cells_Are_Empty()
            {
                //arrange
                var cell1 = CreateCell(1, 1);
                var cell2 = CreateCell(2, 2);
                var cell3 = CreateCell(3, 3);
                var cell4 = CreateCell(4, 4);
                var cell5 = CreateCell(5, 5);
                var cell6 = CreateCell(6, 6);
                var cell7 = CreateCell(7, 7);
                var cell8 = CreateCell(8, 8);
                var cell9 = CreateCell(9);

                var cellGroup = new CellGroup(cell1, cell2, cell3, cell4, cell5, cell6, cell7, cell8, cell9);

                //act
                var validationResult = cellGroup.ValidateCellValues();

                //assert
                validationResult.Should().BeTrue();
            }

            private static Cell CreateCell(int answer, int? value = null)
            {
                var cell = new Cell(answer);
                if (value.HasValue)
                    cell.SetValue(value.Value);

                return cell;
            }
        }
    }
}