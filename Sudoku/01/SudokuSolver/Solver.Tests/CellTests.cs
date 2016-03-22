using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Solver.Tests
{
    public class CellTests
    {
        [TestFixture]
        public class A_Cell_Should
        {
            private static readonly int[] ValidValues = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            private static readonly int[] InvalidValues = { 0, 10 };

            [TestCaseSource(nameof(ValidValues))]
            public void Store_Any_Valid_Answer(int answer)
            {
                var cell = new Cell(answer);

                cell.Answer.Should().Be(answer);
            }

            [TestCaseSource(nameof(InvalidValues))]
            public void Fail_To_Store_Any_Invalid_Answer(int invalidAnswer)
            {
                Action storeInvalidAnswer = () => { var cell = new Cell(invalidAnswer); };

                storeInvalidAnswer.ShouldThrow<ArgumentOutOfRangeException>();
            }

            [TestCaseSource(nameof(ValidValues))]
            public void Store_Any_Valid_Value(int validValue)
            {
                //arrange
                var anyValidAnswer = ValidValues.First();
                var cell = new Cell(anyValidAnswer);

                //act
                cell.SetValue(validValue);

                //assert
                cell.Value.Should().Be(validValue);
            }

            [TestCaseSource(nameof(InvalidValues))]
            public void Fail_To_Store_Any_Invalid_Value(int invalidValue)
            {
                //arrange
                var anyValidAnswer = ValidValues.First();
                var cell = new Cell(anyValidAnswer);

                //act
                Action storeInvalidValue = () => cell.SetValue(invalidValue);

                //assert
                storeInvalidValue.ShouldThrow<ArgumentOutOfRangeException>();
            }

            [Test]
            public void Should_Allow_Its_Value_To_Be_Cleared()
            {
                //arrange
                var anyValidAnswer = ValidValues.First();
                var cell = new Cell(anyValidAnswer);
                cell.SetValue(anyValidAnswer);

                //act
                cell.ClearValue();

                //assert
                cell.Value.Should().NotHaveValue();
            }

            [Test]
            public void Pass_Check_If_Value_Not_Already_In_Any_CellGroup()
            {
                //arrange
                var cellA1 = new Cell(1);
                var cellB1 = new Cell(2);
                var cellC1 = new Cell(3);
                var cellD1 = new Cell(4);
                var cellE1 = new Cell(5);
                var cellF1 = new Cell(6);
                var cellG1 = new Cell(7);
                var cellH1 = new Cell(8);
                var cellI1 = new Cell(9);

                var cellA2 = new Cell(4);
                var cellB2 = new Cell(5);
                var cellC2 = new Cell(6);

                var cellA3 = new Cell(7);
                var cellB3 = new Cell(8);
                var cellC3 = new Cell(9);

                var cellA4 = new Cell(4);
                var cellA5 = new Cell(5);
                var cellA6 = new Cell(6);

                var cellA7 = new Cell(7);
                var cellA8 = new Cell(8);
                var cellA9 = new Cell(9);

                var square = new CellGroup(cellA1, cellB1, cellC1, cellA2, cellB2, cellC2, cellA3, cellB3, cellC3);
                var row = new CellGroup(cellA1, cellB1, cellC1, cellD1, cellE1, cellF1, cellG1, cellH1, cellI1);
                var column = new CellGroup(cellA1, cellA2, cellA3, cellA4, cellA5, cellA6, cellA7, cellA8, cellA9);

                var 
            }
        }
    }
}