using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class ProgamTests
    {
        public class ProgramShould
        {
            private const string StandardItem = "Standard Item";
            private const string ConstantMaturingItem = "Aged Brie";
            public const string SteppedMaturingItem = "Backstage passes to a TAFKAL80ETC concert";
            private const string LegendaryItem = "Sulfuras, Hand of Ragnaros";

            [Fact]
            public void Calculate_quality_even_if_there_are_no_items()
            {
                var program = new Program { Items = new List<Item>() };

                Action updateQuality = () => program.UpdateQuality();

                updateQuality.ShouldNotThrow();
            }

            [Fact]
            public void Reduce_quality_by_one_for_an_item_with_standard_aging_rules_before_the_sell_by_date_has_passed()
            {
                const int startingQuality = 1;
                const int reducedByOne = 0;
                const int oneDay = 1;

                var program = ProgramBuilder
                    .CreateProgram()
                    .WithNewItem(StandardItem)
                    .ToSellIn(oneDay)
                    .WithQuality(startingQuality)
                    .Build();

                program.UpdateQuality();

                QualityOfTheFirstItemIn(program).Should().Be(reducedByOne);
            }

            [Fact]
            public void Reduce_quality_by_two_for_an_item_with_standard_aging_rules_after_the_sell_by_date_has_passed()
            {
                const int initialQuality = 2;
                const int reducedByTwo = initialQuality - 2;
                const int sellByDatePassed = -1;

                var program = ProgramBuilder
                    .CreateProgram()
                    .WithNewItem(StandardItem)
                    .ToSellIn(sellByDatePassed)
                    .WithQuality(initialQuality)
                    .Build();

                program.UpdateQuality();

                QualityOfTheFirstItemIn(program).Should().Be(reducedByTwo);
            }

            [Theory]
            [InlineData(StandardItem, 1)]
            [InlineData(StandardItem, 0)]
            [InlineData(StandardItem, -1)]
            public void Not_reduce_quality_below_zero(string itemName, int numberOfDaysToSellIn)
            {
                const int zeroQuality = 0;

                var program = ProgramBuilder
                    .CreateProgram()
                    .WithNewItem(itemName)
                    .ToSellIn(numberOfDaysToSellIn)
                    .WithQuality(zeroQuality)
                    .Build();

                program.UpdateQuality();

                QualityOfTheFirstItemIn(program).Should().BeGreaterOrEqualTo(zeroQuality);
            }

            [Fact]

            public void Increase_quality_for_an_item_with_inverse_aging_rules()
            {
                const int oneDay = 1;
                const int initialQuality = 1;
                const int increasedByOne = initialQuality + 1;

                var program = ProgramBuilder
                    .CreateProgram()
                    .WithNewItem(ConstantMaturingItem)
                    .ToSellIn(oneDay)
                    .WithQuality(initialQuality)
                    .Build();

                program.UpdateQuality();

                QualityOfTheFirstItemIn(program).Should().Be(increasedByOne);
            }

            [Fact]
            public void Increase_quality_by_one_for_an_item_with_stepped_inverse_aging_rules_which_has_more_than_ten_days_to_sell_in()
            {
                const int moreThanTenDays = 11;
                const int initialQuality = 1;
                const int increasedByOne = initialQuality + 1;

                var program = ProgramBuilder
                    .CreateProgram()
                    .WithNewItem(SteppedMaturingItem)
                    .ToSellIn(moreThanTenDays)
                    .WithQuality(initialQuality)
                    .Build();

                program.UpdateQuality();

                QualityOfTheFirstItemIn(program).Should().Be(increasedByOne);
            }

            [Theory]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(9)]
            [InlineData(10)]
            public void Increase_quality_by_two_for_an_item_with_stepped_inverse_aging_rules_which_has_six_to_ten_days_to_sell_in(int sixToTenDays)
            {
                const int initialQuality = 1;
                const int increasedByTwo = initialQuality + 2;

                var program = ProgramBuilder
                    .CreateProgram()
                    .WithNewItem(SteppedMaturingItem)
                    .ToSellIn(sixToTenDays)
                    .WithQuality(initialQuality)
                    .Build();

                program.UpdateQuality();

                QualityOfTheFirstItemIn(program).Should().Be(increasedByTwo);
            }

            [Theory]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            public void Increase_quality_by_three_for_an_item_with_stepped_inverse_aging_rules_which_has_one_to_five_days_to_sell_in(int oneToFiveDays)
            {
                const int initialQuality = 1;
                const int increasedByThree = initialQuality + 3;

                var program = ProgramBuilder
                    .CreateProgram()
                    .WithNewItem(SteppedMaturingItem)
                    .ToSellIn(oneToFiveDays)
                    .WithQuality(initialQuality)
                    .Build();

                program.UpdateQuality();

                QualityOfTheFirstItemIn(program).Should().Be(increasedByThree);
            }

            [Theory]
            [InlineData(0)]
            [InlineData(-1)]
            public void Decrease_quality_to_zero_for_an_item_with_stepped_inverse_aging_rules_which_has_zero_or_less_days_to_sell_in(int zeroOrLessDays)
            {
                const int initialQuality = 1;
                const int zeroQuality = 0;

                var program = ProgramBuilder
                    .CreateProgram()
                    .WithNewItem(SteppedMaturingItem)
                    .ToSellIn(zeroOrLessDays)
                    .WithQuality(initialQuality)
                    .Build();

                program.UpdateQuality();

                QualityOfTheFirstItemIn(program).Should().Be(zeroQuality);
            }

            [Fact]
            public void Not_increase_quality_over_fifty_for_an_item_with_inverse_aging_rules()
            {
                const int oneDay = 1;
                const int maximumQuality = 50;

                var program = ProgramBuilder
                    .CreateProgram()
                    .WithNewItem(ConstantMaturingItem)
                    .ToSellIn(oneDay)
                    .WithQuality(maximumQuality)
                    .Build();

                program.UpdateQuality();

                QualityOfTheFirstItemIn(program).Should().Be(maximumQuality);
            }

            [Fact]
            public void Not_update_quality_of_legendatry_items()
            {
                const int zeroDays = 0;
                const int legendaryQuality = 80;

                var program = ProgramBuilder
                    .CreateProgram()
                    .WithNewItem(LegendaryItem)
                    .ToSellIn(zeroDays)
                    .WithQuality(legendaryQuality)
                    .Build();

                program.UpdateQuality();

                QualityOfTheFirstItemIn(program).Should().Be(legendaryQuality);
            }

            [Fact]
            public void Not_update_sell_in_days_of_legendary_items()
            {
                const int oneDay = 1;
                const int legendaryQuality = 80;

                var program = ProgramBuilder
                    .CreateProgram()
                    .WithNewItem(LegendaryItem)
                    .ToSellIn(oneDay)
                    .WithQuality(legendaryQuality)
                    .Build();

                program.UpdateQuality();

                program.Items.Single().SellIn.Should().Be(oneDay);
            }

            private static int QualityOfTheFirstItemIn(Program program)
            {
                return program.Items.First().Quality;
            }
        }
    }
}