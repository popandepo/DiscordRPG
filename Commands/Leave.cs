using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace DiscordRPG.Commands
{
    public class Leave : ModuleBase<SocketCommandContext>
    {
        [Command("Leave")] // RequireUserPermission(permission)
        [Alias("LEAVE", "leave")]
        [Summary("")]
        public async Task LeaveAsync()
        {
            var player = UserTool.IsRegistered(Context.User.Id);
            if (player is null || !Context.IsPrivate) return; //If player does not exist or it is not a DirectMessage, do nothing
            Console.WriteLine($"{player.Hashname} has left");
            Program.players.Remove(player);
            await Context.Channel.SendMessageAsync($"Goodbye {Context.User.Username}");
        }
    }
}
