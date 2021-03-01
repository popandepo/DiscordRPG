﻿using System.Collections.Generic;

namespace DiscordRPG
{
    public interface IEnemy : ICreature
    {
        string Name { get; set; }
        int Attack { get; set; }
        int Defense { get; set; }
        int Health { get; set; }
        int Bonus { get; set; }
        int Pulls { get; set; }
        List<ILootables> Loot { get; set; }

        List<ILootables> Pull();
    }
}
