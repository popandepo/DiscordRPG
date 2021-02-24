using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscordRPG
{
    class Player : IPlayer
    {


        public ulong ID { get; set; }
        public SocketUser User { get; set; }
        public string Hashname { get; set; }
        public int Health { get; set; }
        public int MHealth { get; set; }
        public int Bp { get; set; }
        public int Money { get; set; }
        public string State { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public List<ISkill> Skills { get; set; }
        public List<IEquipment> CEquipment { get; set; } //Carried
        public List<IEquipment> SEquipment { get; set; } //Stored
        public List<IItem> CItems { get; set; } //Carried
        public List<IItem> SItems { get; set; } //Stored
        public List<IMaterial> CMaterials { get; set; } //Carried
        public List<IMaterial> SMaterials { get; set; } //Stored
        public int NumberOfSkills => Skills.Count();

        //list of skills
        //list of carried equipment
        //list of stored equipment
        //list of carried items
        //list of stored items
        //list of materials
        //a combat class containing everyone in the fight referenced by "player", "friend1", "enemy1", "enemy2" etc.
        
        /// <summary>
        /// Creates a player object
        /// </summary>
        /// <param name="id">The Discord ID of the Player</param>
        public Player(ulong id) //MOVE DEFAULT VALUES TO GETTER-SETTERS WHEN PROJECT IS DONE
        {
            ID = id;
            User = Program._client.GetUser(id);
            Hashname = User.ToString();
            Health = 10;
            MHealth = 10;
            Bp = 0;
            Money = 100;
            State = "IDLE";
            Attack = 5;
            Defence = 5;

            CItems.Add(new Item("Potion",3,10,"POTION",5));
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
