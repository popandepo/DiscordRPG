using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPG.Modules
{
    public class Leave : ModuleBase<SocketCommandContext>
    {
        [Command("Leave")] // RequireUserPermission(permission)
        [Alias("LEAVE", "leave")]
        [Summary("")]
        public async Task LeaveAsync()
        {
            var player = Program.players.Find(i => i.ID == Context.User.Id);
            if (player is null || !Context.IsPrivate) return; //If player does not exist or it is not a DirectMessage, do nothing
            Console.WriteLine($"{player.Hashname} has left");
            Program.players.Remove(player);
            await Context.Channel.SendMessageAsync($"Goodbye {Context.User.Username}");
        }
    }
}
