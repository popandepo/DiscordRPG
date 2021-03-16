﻿using Discord;
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
        public int BpToUse { get; set; }
        public int Money { get; set; }
        public State State { get; set; }
        public State ReturnState { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public Armor CEquipment { get; set; } //Carried
        public List<Equipment> SEquipment { get; set; } //Stored
        public List<Item> CItems { get; set; } //Carried
        public List<Item> SItems { get; set; } //Stored
        public List<Material> CMaterials { get; set; } //Carried
        public List<Material> SMaterials { get; set; } //Stored
        public Combat Combat { get; set; }
        public List<IEmote> ExpectedEmotes { get; set; }
        public List<string> ExpectedString { get; set; }
        public List<int> ExpectedNumber { get; set; }
        public List<IEmote> RecievedEmotes { get; set; }
        public List<int> RecievedNumbers { get; set; }
        public Area Area { get; set; }
        public List<Area> UnlockedAreas { get; set; }


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
            State = State.Idle;
            ReturnState = State;
            Area = new Area(AreaList.Tutorial);
            Attack = 0;
            Defense = 0;

            HasReadTutorial = false;

            CEquipment = new Armor(EquipmentList.leatherCap, EquipmentList.leatherVest, EquipmentList.leatherGloves, EquipmentList.leatherBelt, EquipmentList.leatherPants, EquipmentList.leatherSword, EquipmentList.leatherShield);
            UpdateStats();

            CItems = new List<Item>();

            CItems.Add(new Item(ItemList.lowPotion));
            CItems.Add(new Item(ItemList.lowPotion));
            CItems.Add(new Item(ItemList.lowPotion));

            SItems = new List<Item>();

            CMaterials = new List<Material>();
            SMaterials = new List<Material>();

            SortList();

            ExpectedEmotes = new List<IEmote>();
            RecievedEmotes = new List<IEmote>();

            RecievedNumbers = new List<int>();

            UnlockedAreas = new List<Area>();

            UnlockedAreas.Add(new Area(AreaList.Tutorial));

            Combat = new Combat();
            //Skills = starter skills (maybe nothing, maybe a low-level heal ability or something)
        }


        /// <summary>
        /// Shows the main combat screen
        /// </summary>
        public void ShowMainCombat()
        {
            LastMessage = User.SendMessageAsync(Text.GetCombat(this)).Result;
            LastMessage.AddReactionsAsync(Emote.MainCombat.ToArray());
            ExpectedEmotes = new List<IEmote>(Emote.MainCombat);
        }

        /// <summary>
        ///Shows the main home screen 
        /// </summary>
        public void ShowHome()
        {
            LastMessage = User.SendMessageAsync(Text.GetHome(this)).Result;
            LastMessage.AddReactionsAsync(Emote.Home.ToArray());
            ExpectedEmotes = new List<IEmote>(Emote.Home);
        }

        /// <summary>
        /// Uses the item in the position of the previously recieved number
        /// </summary>
        public void UseItem()
        {
            string emotes = "";

            Item item = new Item(ItemList.lowPotion);

            foreach (var emote in RecievedEmotes)
            {
                emotes += emote.Name;
            }

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
                item = CItems[RecievedNumbers[0] - 1];
                CItems[RecievedNumbers[0] - 1].Amount -= 1;
                List<Item> itemsToRemove = new List<Item>();
                foreach (var itm in CItems)
                {
                    if (itm.Amount == 0)
                    {
                        itemsToRemove.Add(itm);
                    }
                }
                foreach (var itm in itemsToRemove)
                {
                    CItems.Remove(itm);
                }
            }
            UpdateStats();

            switch (item.Type)
            {
                case "Potion":
                    if (Health + item.Attributes[0] > MaxHealth) //if you can take the damage
                    {
                        Health = MaxHealth;
                    }
                    else if (Health + item.Attributes[0] <= MaxHealth) //if you would die
                    {
                        Health += item.Attributes[0];
                    }
                    break;
                default:
                    break;
            }
        }

        public void AttackEnemies()
        {
            string emotes = "";

            RecievedNumbers.Clear();

            foreach (var emote in RecievedEmotes)
            {
                emotes += emote.Name;
            }

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
                for (int i = 0; i < RecievedNumbers.Count; i++)
                {
                    Combat.Enemies[RecievedNumbers[i] - 1].Damage(Attack += (Attack * BpToUse) / RecievedNumbers.Count);
                }
            }
            UpdateStats();
        }

        /// <summary>
        /// Attacks a single enemy using the first number in RecievedEmotes
        /// </summary>
        public void AttackEnemy()
        {
            string emotes = "";
            foreach (var emote in RecievedEmotes)
            {
                emotes += emote.Name;
            }

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
            }
            UpdateStats();
        }

        /// <summary>
        /// Checks if the player wants to return to a previous screen, if so: does it
        /// </summary>
        /// <param name="emotes">The string of emotes to check</param>
        /// <returns>True if player wants to return</returns>
        public bool ReturnCheck()
        {
            string emotes = "";

            foreach (var emote in RecievedEmotes)
            {
                emotes += emote.Name;
            }

            if (emotes.Contains(Emote.TurnBack.Name))
            {
                RecievedEmotes.Clear();
                State = ReturnState;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Clears all emote storages
        /// </summary>
        public void ClearBuffer()
        {
            RecievedNumbers.Clear();
            ExpectedEmotes.Clear();
            RecievedEmotes.Clear();
        }

        public void UnlockArea(Area area)
        {
            bool existing = false;
            switch (area.Name)
            {
                case "Tutorial":
                    foreach (var unlocked in UnlockedAreas)
                    {
                        if (unlocked.Name == "Forest")
                        {
                            existing = true;
                        }
                    }
                    if (!existing)
                    {
                        UnlockedAreas.Add(new Area(AreaList.Forest));
                    }
                    break;

                case "Forest":
                    existing = false;
                    foreach (var unlocked in UnlockedAreas)
                    {
                        if (unlocked.Name == "Desert")
                        {
                            existing = true;
                        }
                    }
                    if (!existing)
                    {
                        UnlockedAreas.Add(new Area(AreaList.Forest));
                    }
                    break;

                default:
                    break;
            }
        }

        public void Restore()
        {
            Health = MaxHealth;
            Bp = 0;

            UpdateStats();
        }

        /// <summary>
        /// Sends emotes to the player based on the related amount in target
        /// </summary>
        /// <param name="target">What to look for.
        /// Enemies
        /// Items</param>
        public void GetNum(string target)
        {
            if (target == "Bp")
            {
                ExpectedEmotes.Clear();
                LastMessage = User.SendMessageAsync("How many BP do you want to use?").Result;

                List<IEmote> emotes = new List<IEmote>();

                for (int i = 1; i <= Bp; i++)
                {
                    emotes.Add(Emote.Numbers[i]);
                }

                emotes.Add(Emote.TurnBack);
                emotes.Add(Emote.Flag);

                LastMessage.AddReactionsAsync(emotes.ToArray());
                foreach (var item in emotes)
                {
                    ExpectedEmotes.Add(item);
                }
                RecievedEmotes.Clear();
            }
            else if (target == "Enemies")
            {

                ExpectedEmotes.Clear();
                LastMessage = User.SendMessageAsync(Text.GetEnemy(this)).Result;

                List<IEmote> emotes = new List<IEmote>();

                for (int i = 1; i <= Combat.Enemies.Count; i++)
                {
                    emotes.Add(Emote.Numbers[i]);
                }

                emotes.Add(Emote.TurnBack);
                emotes.Add(Emote.Flag);

                LastMessage.AddReactionsAsync(emotes.ToArray());
                foreach (var item in emotes)
                {
                    ExpectedEmotes.Add(item);
                }
                RecievedEmotes.Clear();
            }
            else if (target == "EnemiesM")
            {

                ExpectedEmotes.Clear();
                LastMessage = User.SendMessageAsync(Text.GetEnemies(this)).Result;

                List<IEmote> emotes = new List<IEmote>();

                for (int i = 1; i <= Combat.Enemies.Count; i++)
                {
                    emotes.Add(Emote.Numbers[i]);
                }

                emotes.Add(Emote.TurnBack);
                emotes.Add(Emote.Flag);

                LastMessage.AddReactionsAsync(emotes.ToArray());
                foreach (var item in emotes)
                {
                    ExpectedEmotes.Add(item);
                }
                RecievedEmotes.Clear();
            }
            else if (target == "Items")
            {

                ExpectedEmotes.Clear();
                //LastMessage = User.SendMessageAsync(Text.GetItems(this)).Result;

                List<IEmote> emotes = new List<IEmote>();

                for (int i = 1; i <= CItems.Count; i++)
                {
                    emotes.Add(Emote.Numbers[i]);
                }

                emotes.Add(Emote.TurnBack);
                emotes.Add(Emote.Flag);

                LastMessage.AddReactionsAsync(emotes.ToArray());
                foreach (var item in emotes)
                {
                    ExpectedEmotes.Add(item);
                }
                RecievedEmotes.Clear();
            }
            else if (target == "Areas")
            {
                ExpectedEmotes.Clear();

                List<IEmote> emotes = new List<IEmote>();

                for (int i = 1; i <= UnlockedAreas.Count; i++)
                {
                    emotes.Add(Emote.Numbers[i]);
                }

                emotes.Add(Emote.TurnBack);
                emotes.Add(Emote.Flag);

                LastMessage.AddReactionsAsync(emotes.ToArray());
                foreach (var item in emotes)
                {
                    ExpectedEmotes.Add(item);
                }
                RecievedEmotes.Clear();
            }
        }

        public void SendMessage(string message, bool reactionary, params IEmote[] emotes)
        {
            if (reactionary)
            {
                LastMessage = User.SendMessageAsync(message).Result;
                AddEmote(emotes);
            }
            else
            {
                User.SendMessageAsync(message);
            }
        }

        /// <summary>
        /// Add emotes to the list of expected emotes and send it to the last message
        /// </summary>
        /// <param name="emotes">The emotes to add</param>
        public void AddEmote(params IEmote[] emotes)
        {
            ExpectedEmotes.AddRange(emotes);
            LastMessage.AddReactionsAsync(emotes);
        }

        /// <summary>
        /// Gives a list of loot to the player
        /// </summary>
        /// <param name="loot">The list of loot to give to the player</param>
        public async System.Threading.Tasks.Task RecieveLootAsync(List<ILootables> loot)
        {
            foreach (var item in loot)
            {
                if (item.Identifier == "Item")
                {
                    CItems.Add(new Item((Item)item));
                }
                else if (item.Identifier == "Material")
                {
                    CMaterials.Add(new Material((Material)item));
                }
            }

            SortList();

            string output = "You looted:\n";
            foreach (var item in loot)
            {
                output += $"{item.Amount} {item.Name}\n";
            }
            await User.SendMessageAsync(output);
        }

        /// <summary>
        /// Sorts and compresses lists (CItems, CMaterials and SItems, SMaterials)
        /// </summary>
        public void SortList()
        {
            List<ILootables> itemHolder = new List<ILootables>();
            List<ILootables> materialHolder = new List<ILootables>();

            foreach (var item in CItems)
            {
                itemHolder.Add(item);
            }

            itemHolder = Tools.MySort(itemHolder);

            CItems.Clear();

            foreach (var item in itemHolder)
            {
                CItems.Add((Item)item);
            }

            itemHolder.Clear();


            foreach (var material in CMaterials)
            {
                materialHolder.Add(material);
            }
            materialHolder = Tools.MySort(materialHolder);

            CMaterials.Clear();

            foreach (var material in materialHolder)
            {
                CMaterials.Add((Material)material);
            }

            materialHolder.Clear();



            foreach (var item in SItems)
            {
                itemHolder.Add(item);
            }

            itemHolder = Tools.MySort(itemHolder);

            SItems.Clear();

            foreach (var item in itemHolder)
            {
                SItems.Add((Item)item);
            }

            itemHolder.Clear();

            foreach (var material in SMaterials)
            {
                materialHolder.Add(material);
            }
            materialHolder = Tools.MySort(materialHolder);

            SMaterials.Clear();

            foreach (var material in materialHolder)
            {
                SMaterials.Add((Material)material);
            }

            materialHolder.Clear();
        }

        /// <summary>
        /// Update Attack and Defense to their base stats based on worn equipment
        /// </summary>
        public void UpdateStats()
        {
            Defense = 0;
            Attack = 0;

            Defense += CEquipment.Head.Defense;
            Defense += CEquipment.Chest.Defense;
            Defense += CEquipment.Arms.Defense;
            Defense += CEquipment.Waist.Defense;
            Defense += CEquipment.Legs.Defense;

            Attack += CEquipment.Weapon.Attack;
        }

        /// <summary>
        /// Damage the player
        /// </summary>
        /// <param name="incDamage">Incoming damage</param>
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

        /// <summary>
        /// hurt the player
        /// </summary>
        /// <param name="damage">Incoming damage</param>
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

        /// <summary>
        /// Kill the player
        /// </summary>
        private void Kill()
        {
            State = State.Dead;
        }

        /// <summary>
        /// Make a string of all information related to the player so it can be looked at or stored
        /// </summary>
        /// <returns>A string of all information related to the player</returns>
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
            //System.Console.WriteLine(output);
            return output;
        }
    }
}
