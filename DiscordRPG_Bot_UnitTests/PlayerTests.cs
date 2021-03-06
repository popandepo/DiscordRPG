using DiscordRPG;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DiscordRPG_Bot_UnitTests
{
    public class PlayerTests
    {
        private List<ILootables> loot = new List<ILootables> {
                new Item("TestItem1", "",10, 30, "test", 20),
                new Item("TestItem1", "",10, 30, "test", 20),
                new Item("TestItem1", "",10, 30, "test", 20),
                new Item("TestItem1", "",10, 30, "test", 20),
                new Material("Iron Ingot", 3, 50, "normal"),
                new Material("Iron Ingot", 3, 50, "normal"),
                new Material("Mithril Ingot", 1, 5, "epic"),
                new Material("Steel Ingot", 2, 15, "rare"),
                new Material("Cloth", 3, 50, "normal")
            };

        [Fact]
        public void SortLootablesTest()
        {
            /*
             * Check that the player Mysort function compresses the given Ilootables and returns only unique with accumulated amounts
             */
            var l = Tools.MySort(loot);
            var expect = 40;
            var result = l.Find(i => i.Name == "TestItem1").Amount;
            Assert.Equal(expect, result);
            Assert.True(l.Count() == 5);
        }


        [Fact]
        public void OutputIsSortedByNameTest()
        {
            /*Check that the returned list is sorted alphabetically*/
            var l = Tools.MySort(loot);
            var letters = new List<char>() { 'C', 'I', 'M', 'S', 'T' };
            var result = l.Select(i => i.Name[0]).ToList();
            Assert.Equal(letters, result);
        }


    }
}
