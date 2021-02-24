using DiscordRPG.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG.Battle
{
    class Battle
    {
        public void UseItem(ulong playerID,Item item)
        {
            switch (item.Type)
            {
                case "POTION":
                    foreach (var player in Program.players)
                    {
                        if (player.ID == playerID)
                        {
                            AddHealth(player, item);
                        }
                    }
                    break;
            }
        }

        private static void AddHealth(Player.Player player, Item item)
        {
            player.Health += item.Attributes[0];
            if (player.Health>player.MHealth)
            {
                player.Health = player.MHealth;
            }
        }
    }
}
