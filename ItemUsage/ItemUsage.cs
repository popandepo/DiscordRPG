namespace DiscordRPG
{
    class ItemUsage
    {
        /// <summary>
        /// Uses an Item
        /// </summary>
        /// <param name="playerID">The ID of the player to use the item on</param>
        /// <param name="item">The item to use</param>
        public void UseItem(ulong playerID, Item item)
        {
            switch (item.Type)
            {
                case "POTION":
                    foreach (var player in Program.players)
                    {
                        if (player.ID == playerID)
                        {
                            StatChange.AddHealth(player, item.Attributes[0]);
                        }
                    }
                    break;
            }
        }
    }
}
