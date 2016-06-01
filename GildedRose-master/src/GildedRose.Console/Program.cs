using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
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

                item.SellIn--;

                if (IsInverseAging(item))
                {
                    IncrementItemQuality(item);
                    continue;
                }

                if (IsSteppedInverseAging(item))
                {
                    UpdateSteppedInverseAgingItemQuality(item);
                    continue;
                }

                if (IsConjuredItem(item))
                {
                    UpdateConjuredItemQuality(item);
                    continue;
                }

                UpdateStandardItemQuality(item);
            }
        }

        private static bool IsConjuredItem(Item item)
        {
            return item.Name.StartsWith("Conjured");
        }

        private static bool IsLegendary(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private static bool IsInverseAging(Item item)
        {
            return item.Name == "Aged Brie";
        }

        private static bool IsSteppedInverseAging(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static void UpdateStandardItemQuality(Item item)
        {
            var amount = HasExpired(item) ? 2 : 1;

            DecrementItemQuality(item, amount);
        }

        private static void UpdateSteppedInverseAgingItemQuality(Item item)
        {
            if (HasExpired(item))
            {
                item.Quality = 0;
                return;
            }

            var amount = 1;
            if (item.SellIn < 10) amount++;
            if (item.SellIn < 5) amount++;

            IncrementItemQuality(item, amount);
        }

        private static void UpdateConjuredItemQuality(Item item)
        {
            var amount = HasExpired(item) ? 4 : 2;

            DecrementItemQuality(item, amount);
        }

        private static void IncrementItemQuality(Item item)
        {
            if (item.Quality < 50) item.Quality++;
        }

        private static void IncrementItemQuality(Item item, int amount)
        {
            for (var i = 0; i < amount; i++) IncrementItemQuality(item);
        }

        private static void DecrementItemQuality(Item item, int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                DecrementItemQuality(item);
            }
        }

        private static void DecrementItemQuality(Item item)
        {
            if (item.Quality > 0) item.Quality--;
        }

        private static bool HasExpired(Item item)
        {
            return item.SellIn < 0;
        }
    }
}
