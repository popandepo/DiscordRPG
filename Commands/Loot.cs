using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPG.Commands
{
    public class Loot : ModuleBase<SocketCommandContext>
    {
        [Command("Loot")] // RequireUserPermission(permission)
        [Alias("Loot")]
        [Summary("")]
        public async Task LootAsync()
        {
            var player = UserTool.IsRegistered(Context.User.Id);
            if (player is null) return;
            List<ILootables> loot = new List<ILootables>();
            loot.Add(new Item("testitem", 1, 1, "TEST", 1));
            loot.Add(new Material("testmaterial", 1, 1, "Normal"));

            Console.WriteLine($"{player.Hashname} looted some stuff");

            player.RecieveLoot(loot);
            await MessageHandler.SendMessageAsync(player, "You just looted some stuff"); // CHANGE ME
        }
    }
}
