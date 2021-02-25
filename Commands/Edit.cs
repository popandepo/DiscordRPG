﻿using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace DiscordRPG.Commands
{
    public class Edit : ModuleBase<SocketCommandContext>
    {
        [Command("Edit")] // RequireUserPermission(permission)
        [Alias("edit", "EDIT", "eDIT")]
        [Summary("")]
        public async Task EditAsync(string content, [Remainder] string extra = null)
        {
            Console.WriteLine("Function does not appear to work atm");
            var player = UserTools.IsRegistered(Context.User.Id);
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
