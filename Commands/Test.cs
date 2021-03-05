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
            var player = UserTools.IsRegistered(Context.User.Id);
            if (player is null) return;
            Console.WriteLine($"{player.Hashname} sent a test message");
            //Console.WriteLine();
            //MessageHandler.SendMessage(player, JSONhandler.ObjectToJson(player));
            //await UserTools.SaveUsersToJSON();
            await Program.DbHandler.AddUserToDatabase(player);
        }
    }
}
