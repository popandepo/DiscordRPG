using Discord.WebSocket;
using DiscordRPG.Equipment;
using DiscordRPG.Items;
using DiscordRPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscordRPG.Player
{
    class Player : IPlayer
    {


        public ulong ID { get; set; }
        public SocketUser User { get; set; }
        public string Hashname { get; set; }
        public int Health { get; set; }
        public int Bp { get; set; }
        public string State { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public List<ISkill> Skills { get; set; }
        public List<IEquipment> Equipment { get; set; }
        public List<IItem> Items { get; set; }
        public int NumberOfSkills => Skills.Count();

        //list of skills
        //list of carried equipment
        //list of stored equipment
        //list of carried items
        //list of stored items
        //list of materials
        //a combat class containing everyone in the fight referenced by "player", "friend1", "enemy1", "enemy2" etc.
    
        public Player(ulong id)
        {
            ID = id;
            User = Program._client.GetUser(id);
            Hashname = User.ToString();
            Health = 10;
            Bp = 0;
            State = "IDLE";
            Attack = 5;
            Defence = 5;
            
            //CEquipment = starter equipment
            //SEquipment = nothing

            //CItems = starter items
            //SItems = nothing

            //Materials = nothing

            //Skills = starter skills (maybe nothing, maybe a low-level heal ability or something)

            //Combat = nothing
        }
    }
}
