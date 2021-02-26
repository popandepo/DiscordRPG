using Discord;
using Discord.Commands;
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
            player.Combat = new DiscordRPG.Combat(player, EnemyList.Goblin, EnemyList.Slime);

            player.LastMessage = Context.User.SendMessageAsync(Text.GetCombat(player)).Result;
            player.AddEmote(Emote.Sword, Emote.Shield, Emote.Wand, Emote.Bag, Emote.Flag);

        }
    }
}
