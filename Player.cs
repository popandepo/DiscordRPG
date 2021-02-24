using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPG
{
    class Player
    {
        ulong ID { get; set; }
        string Hashname { get; set; }
        int Health { get; set; }
        int Bp { get; set; }
        string State { get; set; }
        int Attack { get; set; } //TEMPORARY
        int Defence { get; set; } //TEMPORARY
        //list of skills
        //list of carried equipment
        //list of stored equipment
        //list of carried items
        //list of stored items
        //list of materials
        //a combat class containing everyone in the fight referenced by "player", "friend1", "enemy1", "enemy2" etc.


    }
}
