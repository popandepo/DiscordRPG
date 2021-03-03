using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DiscordRPG.Models;

namespace DiscordRPG.Tools
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
                PlayerModel playerModel = new PlayerModel();
                playerModel.Id = player.ID;
                playerModel.Hashname = player.Hashname;
                playerModel.Health = player.Health;
                playerModel.MHealth = player.MHealth;
                playerModel.Bp = player.Bp;
                playerModel.Money = player.Money;
                playerModel.Attack = player.Attack;
                playerModel.Defense = player.Defense;
                playerModel.Skills = player.Skills;
                playerModel.CEquipment = player.CEquipment;
                playerModel.SEquipment = player.SEquipment;
                playerModel.CItems = player.CItems;
                playerModel.SItems = player.SItems;
                playerModel.CMaterials = player.CMaterials;
                playerModel.SMaterials = player.SMaterials;

                db.Players.Add(playerModel);
                db.SaveChanges();
            }
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
