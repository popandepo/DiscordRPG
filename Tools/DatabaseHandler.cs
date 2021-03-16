#nullable enable
using DiscordRPG.Models;
using System;
using System.Threading.Tasks;

namespace DiscordRPG
{
    public class DatabaseHandler
    {
        public bool JsonMode { get; set; } = false;
        public DatabaseHandler()
        {

        }

        public Task AddUserToDatabase(Player player)
        {
            //if (IsInDatabase(player)) return Task.CompletedTask;
            using (var db = new EFContext())
            {
                var lookup = db.Players.Find((ulong)player.ID);
                if (!(lookup is null)) // There is probably a better way to do this...
                {
                    if (lookup.Id == player.ID) return Task.CompletedTask;
                }
                PlayerModel playerModel = new PlayerModel();
                playerModel.Id = player.ID;
                playerModel.Hashname = player.Hashname;
                playerModel.Health = player.Health;
                playerModel.MaxHealth = player.MaxHealth;
                playerModel.Bp = player.Bp;
                playerModel.Money = player.Money;
                playerModel.Attack = player.Attack;
                playerModel.Defense = player.Defense;
                /*
                playerModel.Skills = player.Skills;
                playerModel.CEquipment = player.CEquipment;
                playerModel.SEquipment = player.SEquipment;
                playerModel.CItems = player.CItems;
                playerModel.SItems = player.SItems;
                playerModel.CMaterials = player.CMaterials;
                playerModel.SMaterials = player.SMaterials;
                */
                db.Players.Add(playerModel);
                db.SaveChanges();
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets a player object from the database if found. Else return null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Player>? GetUserFromDatabase(ulong id)
        {
            Player? player = null;
            using (var db = new EFContext())
            {
                var result = db.Players.Find(id);
                if (result is null) return null;
                player = new Player(result.Id)
                {
                    Hashname = result.Hashname,
                    Health = result.Health,
                    MaxHealth = result.MaxHealth,
                    Bp = result.Bp,
                    Money = result.Money,
                    Attack = result.Attack,
                    Defense = result.Defense
                };
                Console.WriteLine(result.Hashname);
            }
            return Task.FromResult(player);
        }

        /// <summary>
        /// Method must check if the player already exists in database, if an entry with the provided ID exists in the database, update the entry with new values. 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Task UpdatePlayerInDatabase(Player player)
        {
            return Task.CompletedTask;
        }

        public bool IsInDatabase(Player player)
        {
            using (var db = new EFContext())
            {
                var res = db.Players.Find(player.ID);
                if (res is null) return false;
                Console.WriteLine($"Player {res.Hashname} found!");
                return true;
            }
        }
    }
}
