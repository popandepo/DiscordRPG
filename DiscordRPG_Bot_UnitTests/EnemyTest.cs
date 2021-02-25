using DiscordRPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DiscordRPG_Bot_UnitTests
{
    public class EnemyTest
    {


        [Fact]
        public void EnemyPullCumulativeChanceTest()
        {
            Enemy testGoblin = new Enemy("Goblin", new List<string> { "Forest" }, 10, 10, 10, 3, new Material("Goblin ear", 2, 1, "Normal", 50), new Material("Goblin ear", 1, 1, "Normal", 50));
            var result = testGoblin.Pull();
            Assert.True(result.Count() == 3);
            foreach (var item in result)
            {
                Assert.Equal("Material", item.GetType().Name);
            }
        }


    }
}
