using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPG.Modules
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("Test")] // RequireUserPermission(permission)
        [Alias("TEST", "test")]
        [Summary("")]
        public async Task TestAsync()
        {
            var player = Program.players.Find(i => i.ID == Context.User.Id);
            if (player is null) return;
            await MessageHandler.SendMessageAsync(player, "I recieved a test order, responding as ordered!");
            Console.WriteLine($"{player.Hashname} sent a test message");
        }
    }
}
