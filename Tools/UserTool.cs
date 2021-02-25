#nullable enable

namespace DiscordRPG
{
    public class UserTool
    {

        public static Player? IsRegistered(ulong id)
        {
            return Program.players.Find(i => i.ID == id);
        }
    }
}
