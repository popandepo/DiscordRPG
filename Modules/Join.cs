using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPG.Modules
{
    public class Join : ModuleBase<SocketCommandContext>
    {
        [Command("join")] // RequireUserPermission(permission)
        [Alias("JOIN", "Join", "jOIN")]
        [Summary("")]
        public async Task JoinAsync()
        {
            await Context.Channel.SendMessageAsync("Joining");
        }
    }
}
