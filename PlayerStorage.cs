using System.Collections.Generic;

namespace DiscordRPG
{
    public class PlayerStorage
    {
        public List<Player> Players { get; set; } = new List<Player>();

        public PlayerStorage()
        {
        }
        public int Add(Player input)
        {
            Players.Add(input);
            return Players.IndexOf(input);
        }
        public bool Contains(ulong id)
        {
            foreach (var player in Players)
            {
                if (player.ID == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
