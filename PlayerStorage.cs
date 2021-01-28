using System.Collections.Generic;

namespace DiscordRPG
{
    public class PlayerStorage
    {
        public List<Player> Players { get; set; } = new List<Player>();

        public bool Search(ulong searchTerm)
        {
            foreach (var player in Players)
            {
                if (player.ID == searchTerm)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
