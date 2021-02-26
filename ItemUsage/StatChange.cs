namespace DiscordRPG
{
    internal class StatChange
    {

        /// <summary>
        /// Adds health to a player
        /// </summary>
        /// <param name="player">The player to add health to</param>
        /// <param name="item">The amount to add</param>
        public static void AddHealth(Player player, int amount)
        {
            player.Health += amount;
            if (player.Health > player.MaxHealth)
            {
                player.Health = player.MaxHealth;
            }
        }
    }
}