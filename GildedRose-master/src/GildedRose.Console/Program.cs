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
                const string agedBrie = "Aged Brie";
                const string backstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";

                if (IsLegendary(item))
                    continue;

                if (item.Name != agedBrie && item.Name != backstagePassesToATafkal80EtcConcert)
                {
                    DecrementItemQualityIfGreaterThanZero(item);
                }
                else
                {
                    IncrementItemQualityIfLessThanFifty(item);

                    if (item.Name == backstagePassesToATafkal80EtcConcert)
                        {
                            if (item.SellIn < 11)
                            {
                                IncrementItemQualityIfLessThanFifty(item);
                            }

                            if (item.SellIn < 6)
                            {
                                IncrementItemQualityIfLessThanFifty(item);
                            }
                        }
                }

                item.SellIn = item.SellIn - 1;

                if (item.SellIn < 0)
                {
                    if (item.Name != agedBrie)
                    {
                        if (item.Name != backstagePassesToATafkal80EtcConcert)
                        {
                            DecrementItemQualityIfGreaterThanZero(item);
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                }
            }
        }

        private static void IncrementItemQualityIfLessThanFifty(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private static void DecrementItemQualityIfGreaterThanZero(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        private static bool IsLegendary(Item item)
        {
            const string sulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

            return item.Name == sulfurasHandOfRagnaros;
        }
    }
}
