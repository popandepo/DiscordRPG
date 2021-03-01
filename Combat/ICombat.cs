using System.Collections.Generic;

namespace DiscordRPG
{
    interface ICombat
    {
        List<Enemy> Enemies { get; set; }
        int Turn { get; set; }

    }
}
