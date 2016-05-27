using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GildedRose.Console;
using GildedRose.Tests.Extensions;
using Xunit;

namespace GildedRose.Tests
{
    public class ProgamTests
    {
        public class ProgramShould
        {
            private const string StandardItem = "Standard Item";
            private const string MaturingItem = "Aged Brie";
            private const string LegendaryItem = "Sulfuras, Hand of Ragnaros";

            [Fact]
            public void Calculate_quality_even_if_there_are_no_items()
            {
                var program = new Program { Items = new List<Item>() };

                Action updateQuality = () => program.UpdateQuality();

                updateQuality.ShouldNotThrow();
            }

            [Fact]
            public void Calculate_quality_for_an_item_with_standard_aging_rules()
            {
                const int startingQuality = 1;
                const int reducedByOne = 0;
                const int oneDay = 1;

                var standardItem = new Item { Name = StandardItem, SellIn = oneDay, Quality = startingQuality };
                var program = new Program { Items = new List<Item> { standardItem } };

                program.UpdateQuality();


                standardItem.Quality.Should().Be(reducedByOne);
            }

            [Theory]
            [InlineData(StandardItem, 1)]
            [InlineData(MaturingItem, 1)]
            [InlineData(LegendaryItem, 1)]
            [InlineData(StandardItem, 0)]
            [InlineData(MaturingItem, 0)]
            [InlineData(LegendaryItem, 0)]
            [InlineData(StandardItem, -1)]
            [InlineData(MaturingItem, -1)]
            [InlineData(LegendaryItem, -1)]
            public void Not_reduce_quality_below_zero(string itemName, int numberOfDaysToSellIn)
            {
                const int zeroQuality = 0;

                var program = TestProgramBuilder
                    .Create()
                    .WithNewItem(itemName)
                    .ToSellIn(numberOfDaysToSellIn)
                    .WithQuality(zeroQuality)
                    .Build();

                program.UpdateQuality();

                program.Items.Single().Quality.Should().BeGreaterOrEqualTo(zeroQuality);
            }

            [Fact]

            public void Calculate_quality_for_an_item_with_inverse_aging_rules()
            {
                const int oneDay = 1;
                const int initialQuality = 1;
                const int increasedByOne = initialQuality+1;

                var program = TestProgramBuilder
                    .Create()
                    .WithNewItem(MaturingItem)
                    .ToSellIn(oneDay)
                    .WithQuality(initialQuality)
                    .Build();

                program.UpdateQuality();

                program.Items.Single().Quality.Should().Be(increasedByOne);
            }

            [Fact]
            public void Calculate_quality_of_legendary_items_as_eighty()
            {
                const int zeroDays = 0;
                const int legendaryQuality = 80;

                var program = TestProgramBuilder
                    .Create()
                    .WithNewItem(LegendaryItem)
                    .ToSellIn(zeroDays)
                    .WithQuality(legendaryQuality)
                    .Build();

                program.UpdateQuality();

                program.Items.Single().Quality.Should().Be(legendaryQuality);
            }

            [Fact]
            public void Not_reduce_sell_in_days_of_legendary_items()
            {
                const int oneDay = 1;
                const int legendaryQuality = 80;

                var program = TestProgramBuilder
                    .Create()
                    .WithNewItem(LegendaryItem)
                    .ToSellIn(oneDay)
                    .WithQuality(legendaryQuality)
                    .Build();

                program.UpdateQuality();

                program.Items.Single().SellIn.Should().Be(oneDay);
            }
        }
    }
}