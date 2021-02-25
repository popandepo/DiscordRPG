#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

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
