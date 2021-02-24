using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Linq;

namespace DiscordRPG
{
    class Player : IPlayer
    {


        public ulong ID { get; set; }
        public IUserMessage LastMessage { get; set; }
        public SocketUser User { get; set; }
        public string Hashname { get; set; }
        public int Health { get; set; }
        public int MHealth { get; set; }
        public int Bp { get; set; }
        public int Money { get; set; }
        public string State { get; set; }
        public int Attack { get; set; } //TEMPORARY
        public int Defence { get; set; } //TEMPORARY
        public List<Skill> Skills { get; set; }
        public List<IEquipment> CEquipment { get; set; } //Carried
        public List<IEquipment> SEquipment { get; set; } //Stored
        public List<Item> CItems { get; set; } //Carried
        public List<Item> SItems { get; set; } //Stored
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

            CItems = new List<Item>();
            CItems.Add(new Item("Potion", 3, 10, "POTION", 5));

            SItems = new List<Item>();

            SMaterials = new List<IMaterial>();

            //CEquipment = starter equipment
            //SEquipment = nothing

            //CItems = starter items
            //SItems = nothing

            //Materials = nothing

            //Skills = starter skills (maybe nothing, maybe a low-level heal ability or something)

            //Combat = nothing
        }
        public void RecieveLoot(List<ILootables> loot)
        {
            foreach (var item in loot)
            {
                if (item.Identifier == "Item")
                {
                    SItems.Add((Item)item);
                    User.SendMessageAsync($"You looted {item.Amount} {item.Name}");
                }
                else if (item.Identifier == "Material")
                {
                    SMaterials.Add((Material)item);
                    User.SendMessageAsync($"You looted {item.Amount} {item.Name}");
                }
            }
        }
    }
}
