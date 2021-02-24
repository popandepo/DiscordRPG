using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG
{
    class Battle
    {
        /// <summary>
        /// Uses an Item
        /// </summary>
        /// <param name="playerID">The ID of the player to use the item on</param>
        /// <param name="item">The item to use</param>
        public void UseItem(ulong playerID,Item item)
        {
            switch (item.Type)
            {
                case "POTION":
                    foreach (var player in Program.players)
                    {
                        if (player.ID == playerID)
                        {
                            AddHealth(player, item.Attributes[0]);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Adds health to a player
        /// </summary>
        /// <param name="player">The player to add health to</param>
        /// <param name="item">The amount to add</param>
        public static void AddHealth(Player player, int amount)
        {
            player.Health += amount;
            if (player.Health>player.MHealth)
            {
                player.Health = player.MHealth;
            }
        }
    }
}
