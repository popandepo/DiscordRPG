using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPG.Commands
{
    public class Combat : ModuleBase<SocketCommandContext>
    {
        [Command("Combat")] // RequireUserPermission(permission)
        [Alias("combat")]
        [Summary("")]
        public async Task CombatAsync()
        {
            var player = UserTools.IsRegistered(Context.User.Id);
            player.Combat = new DiscordRPG.Combat(EnemyList.Goblin,EnemyList.Slime);

            await Context.User.SendMessageAsync(Text.GetCombat(player));
        }
    }
}
