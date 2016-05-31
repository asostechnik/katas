using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        private const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
        private const string AgedBrie = "Aged Brie";

        public IList<Item> Items;

        private static void Main()
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

            };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (IsLegendary(item))
                    continue;

                if (IsInverseAging(item))
                {
                    UpdateConstantInverseAgingItemQuality(item);
                }
                else if (IsSteppedInverseAging(item))
                {
                    UpdateSteppedInverseAgingItemQuality(item);
                }
                else
                {
                    UpdateStandardItemQuality(item);
                }

                item.SellIn--;
            }
        }

        private static bool IsSteppedInverseAging(Item item)
        {
            return item.Name == BackstagePassesToATafkal80EtcConcert;
        }

        private static bool IsInverseAging(Item item)
        {
            return item.Name == AgedBrie;
        }

        private static void UpdateSteppedInverseAgingItemQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
                return;
            }

            UpdateConstantInverseAgingItemQuality(item);

            if (item.SellIn < 11)
            {
                UpdateConstantInverseAgingItemQuality(item);
            }

            if (item.SellIn < 6)
            {
                UpdateConstantInverseAgingItemQuality(item);
            }
        }

        private static void UpdateConstantInverseAgingItemQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private static void UpdateStandardItemQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }

            if (item.Quality > 0 && item.SellIn <= 0)
            {
                item.Quality--;
            }
        }

        private static bool IsLegendary(Item item)
        {
            const string sulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

            return item.Name == sulfurasHandOfRagnaros;
        }
    }
}
