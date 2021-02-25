using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace DiscordRPG.Commands
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("Test")] // RequireUserPermission(permission)
        [Alias("TEST", "test", "tEST")]
        [Summary("")]
        public async Task TestAsync()
        {
            var player = UserTool.IsRegistered(Context.User.Id);
            if (player is null) return;
            await MessageHandler.SendMessageAsync(player, "I recieved a test order, responding as ordered!");
            Console.WriteLine($"{player.Hashname} sent a test message");
        }
    }
}
