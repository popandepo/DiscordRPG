using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPG.Modules
{
    public class Edit : ModuleBase<SocketCommandContext>
    {
        [Command("Edit")] // RequireUserPermission(permission)
        [Alias("edit", "EDIT", "eDIT")]
        [Summary("")]
        public async Task EditAsync(string content, [Remainder] string extra=null)
        {
            Console.WriteLine("Function does not appear to work atm");
            var player = UserTool.IsRegistered(Context.User.Id);
            if (player is null) return;
            await MessageHandler.EditMessageAsync(player, content);
            Console.WriteLine($"{player.Hashname} edited a message");
            if (!(extra is null))
            {
                // Do something if given extra arguments
            }
        }
    }
}
