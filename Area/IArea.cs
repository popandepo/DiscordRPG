using System.Collections.Generic;

namespace DiscordRPG
{
    interface IArea
    {
        string Name { get; set; }
        int Length { get; set; }
        List<Enemy> Enemies { get; set; }
    }
}
