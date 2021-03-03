using Discord;
using Discord.WebSocket;
using System.Collections.Generic;

namespace DiscordRPG
{
    public class Player : IPlayer
    {


        public ulong ID { get; set; }
        public bool HasReadTutorial { get; set; }
        public IUserMessage LastMessage { get; set; }
        public SocketUser User { get; set; }
        public string Hashname { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Bp { get; set; }
        public int Money { get; set; }
        public string State { get; set; }
        public int Attack { get; set; } //TEMPORARY
        public int Defense { get; set; } //TEMPORARY
        //public List<Skill> Skills { get; set; }
        public List<Equipment> CEquipment { get; set; } //Carried
        public List<Equipment> SEquipment { get; set; } //Stored
        public List<Item> CItems { get; set; } //Carried
        public List<Item> SItems { get; set; } //Stored
        public List<Material> CMaterials { get; set; } //Carried
        public List<Material> SMaterials { get; set; } //Stored
        public Combat Combat { get; set; }
        //public int NumberOfSkills => Skills.Count();
        public List<IEmote> ExpectedEmotes { get; set; }
        public List<string> ExpectedString { get; set; }
        public List<int> ExpectedNumber { get; set; }
        public List<IEmote> RecievedEmotes { get; set; }
        public List<int> RecievedNumbers { get; set; }
        public Area Area { get; set; }


        //list of skills

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
            MaxHealth = 10;
            Bp = 0;
            Money = 100;
            State = "";
            Attack = 0;
            Defense = 0;

            HasReadTutorial = false;

            CEquipment = EquipmentList.leather;
            UpdateStats();

            CItems = new List<Item>();
            CItems.Add(new Item(ItemList.lowPotion));

            SItems = new List<Item>();

            CMaterials = new List<Material>();
            SMaterials = new List<Material>();

            ExpectedEmotes = new List<IEmote>();
            RecievedEmotes = new List<IEmote>();

            RecievedNumbers = new List<int>();

            Combat = new Combat();
            //Skills = starter skills (maybe nothing, maybe a low-level heal ability or something)
        }

        public void Act()
        {
            LastMessage = User.SendMessageAsync(Text.GetCombat(this)).Result;
            LastMessage.AddReactionsAsync(Emote.MainCombat.ToArray());
            ExpectedEmotes = Emote.MainCombat;
        }
        public void EmoteAct()
        {
            string emotes = "";

            foreach (var emote in RecievedEmotes)
            {
                emotes += emote.Name;
            }
            RecievedEmotes.Clear();

            if (emotes.Contains(Emote.Sword.Name))
            {
                if (emotes.Contains(Emote.Zap.Name))
                {

                }
                else
                {
                    GetNum();
                }

            }

            for (int i = 0; i < Emote.Numbers.Length; i++)
            {
                IEmote number = Emote.Numbers[i];

                if (emotes.Contains(number.Name))
                {
                    RecievedNumbers.Add(i);
                }
            }
            if (State == "GET SINGLE TARGET" && RecievedNumbers.Count > 0)
            {
                Combat.Enemies[RecievedNumbers[0] - 1].Damage(Attack);

                if (Combat.Enemies[RecievedNumbers[0] - 1].Health == 0)
                {
                    RecieveLoot(Combat.Enemies[RecievedNumbers[0] - 1].Kill());
                }

                ClearBuffer();
                Act();

            }
        }

        public void AttackEnemy()
        {
            string emotes = "";
            foreach (var emote in RecievedEmotes)
            {
                emotes += emote.Name;
            }
            RecievedEmotes.Clear();

            for (int i = 0; i < Emote.Numbers.Length; i++)
            {
                IEmote number = Emote.Numbers[i];

                if (emotes.Contains(number.Name))
                {
                    RecievedNumbers.Add(i);
                }
            }
            if (RecievedNumbers.Count > 0)
            {
                Combat.Enemies[RecievedNumbers[0] - 1].Damage(Attack);

                if (Combat.Enemies[RecievedNumbers[0] - 1].Health == 0)
                {
                    //User.SendMessageAsync($"You killed {Combat.Enemies[RecievedNumbers[0] - 1].Name} and recieved:");
                    RecieveLoot(Combat.Enemies[RecievedNumbers[0] - 1].Kill());
                }

                ClearBuffer();
            }
        }

        private void ClearBuffer()
        {
            RecievedNumbers.Clear();
            ExpectedEmotes.Clear();
            RecievedEmotes.Clear();
        }

        public void GetNum()
        {
            LastMessage = User.SendMessageAsync(Text.GetEnemy(this)).Result;
            ExpectedEmotes.Clear();

            List<IEmote> emotes = new List<IEmote>();

            for (int i = 1; i <= Combat.Enemies.Count; i++)
            {
                emotes.Add(Emote.Numbers[i]);
            }
            emotes.Add(Emote.Flag);
            LastMessage.AddReactionsAsync(emotes.ToArray());
            foreach (var item in emotes)
            {
                ExpectedEmotes.Add(item);
            }
        }

        public void AddEmote(params IEmote[] emotes)
        {
            ExpectedEmotes.AddRange(emotes);
            LastMessage.AddReactionsAsync(emotes);
        }

        /// <summary>
        /// Gives a list of loot to the player
        /// </summary>
        /// <param name="loot">The list of loot to give to the player</param>
        public void RecieveLoot(List<ILootables> loot)
        {
            foreach (var item in loot)
            {
                if (item.Identifier == "Item")
                {
                    CItems.Add((Item)item);
                }
                else if (item.Identifier == "Material")
                {
                    CMaterials.Add((Material)item);
                }
            }
            CItems = MySort(CItems);
            CMaterials = MySort(CMaterials);
            string output = "You looted:\n";
            foreach (var item in loot)
            {
                output += $"{item.Amount} {item.Name}\n";
            }
            User.SendMessageAsync(output);
        }

        private List<Item> MySort(List<Item> listToSort)
        {
            //listToSort.Sort();
            int occurences = 0;
            Item recieving = null;
            List<Item> output = new List<Item>();

            foreach (var adding in listToSort)
            {
                foreach (var existing in output)
                {
                    if (adding.Name == existing.Name)
                    {
                        occurences += 1;
                        recieving = existing;
                    }
                }
                if (occurences == 0)
                {
                    output.Add(new Item(adding));
                }
                else
                {
                    foreach (var result in output)
                    {
                        if (result.Name == recieving.Name)
                        {
                            result.Amount += recieving.Amount;
                        }
                    }
                }
            }

            return output;
        }

        private List<Material> MySort(List<Material> listToSort)
        {
            //listToSort.Sort();
            int occurences = 0;
            Material recieving = null;
            List<Material> output = new List<Material>();

            foreach (var adding in listToSort)
            {
                foreach (var existing in output)
                {
                    if (adding.Name == existing.Name)
                    {
                        occurences += 1;
                        recieving = existing;
                    }
                }
                if (occurences == 0)
                {
                    output.Add(new Material(adding));
                }
                else
                {
                    foreach (var result in output)
                    {
                        if (result.Name == recieving.Name)
                        {
                            result.Amount += recieving.Amount;
                        }
                    }
                }
            }

            return output;
        }

        public void UpdateStats()
        {
            Defense = 0;
            Attack = 0;
            foreach (var equipment in CEquipment)
            {
                if (equipment.EquipmentType == "Armor")
                {
                    Defense += equipment.Defense;
                }
                else if (equipment.EquipmentType == "Weapon")
                {
                    Attack += equipment.Attack;
                }
            }

        }

        public void Damage(int incDamage) //10
        {
            int negatePoint = incDamage * -1; //-10
            int floorCap = incDamage / 2; //5

            int totalDamage = incDamage - Defense;

            if (totalDamage <= negatePoint) //if total damage is less than negate point
            {
                //no damage recieved
            }
            else if (totalDamage > negatePoint && totalDamage <= floorCap) //if total damage is between negate point and floor cap
            {
                Hurt(floorCap);
            }
            else if (totalDamage > floorCap) //if total damage is above floor cap
            {
                Hurt(totalDamage);
            }
        }

        private void Hurt(int damage)
        {
            if (Health > damage) //if you can take the damage
            {
                Health -= damage;
            }
            else if (Health < damage) //if you would die
            {
                Health = 0;
                Kill();
            }
        }

        private void Kill()
        {
            State = "DEAD";
        }

        public override string ToString()
        {
            string output = $"{{\"ID\":{ID}, \"Hashname\":{Hashname}, \"Health\":{Health}, \"MHealth\":{MaxHealth}, \"Bp\":{Bp}, \"Money\":{Money}, \"State\":{State}, \"Attack\":{Attack}, \"Defense\":{Defense},";
            /*
            output += "\"CItems\":{";
            foreach (var item in CItems)
            {
                output += item.ToString();
            }
            output += "},";

            output += "\"SItems\":{";
            foreach (var item in SItems)
            {
                output += item.ToString();
            }
            output += "},";

            output += "\"CMaterials\":{";
            if (CMaterials.Count() != 0 && !(CMaterials is null))
            {
                CMaterials.ForEach(i => output += i);
            }
            output += "},";

            output += "\"SMaterials\":{";
            if (SMaterials.Count() != 0 && !(SMaterials is null))
            {
                SMaterials.ForEach(i => output += i);
            }
            output += "},";

            output += "\"CEquipment\":{";
            if (CEquipment.Count() != 0 && !(CEquipment is null))
            {
                CEquipment.ForEach(i => output += i);
            }
            output += "},";

            output += "\"SEquipment\":{";
            if (SEquipment.Count() != 0 && !(SEquipment is null))
            {
                SEquipment.ForEach(i => output += i);
            }*/
            output += "}";//}";
            System.Console.WriteLine(output);
            return output;
        }
    }
}
