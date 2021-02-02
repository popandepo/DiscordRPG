using Discord;

namespace DiscordRPG
{
    public class Player
    {
        public Player(ulong id)
        {
            ID = id;

        }
        public ulong ID { get; set; }

        public IEmote[] ExpectedReactions { get; set; }

    }
}

