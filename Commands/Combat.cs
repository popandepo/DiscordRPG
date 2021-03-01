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
            var enemy = new EnemyList();

            var player = UserTools.IsRegistered(Context.User.Id);
            player.Combat = new DiscordRPG.Combat(player, enemy.Goblin, enemy.Slime);

            if (player.HasReadTutorial)
            {
                player.LastMessage = Context.User.SendMessageAsync(Text.GetCombat(player)).Result;
                player.AddEmote(Emote.MainCombat.ToArray());
            }
            else
            {
                player.LastMessage = Context.User.SendMessageAsync(Text.GetCombat(player)).Result;
                player.AddEmote(Emote.FirstMainCombat.ToArray());
            }

        }
    }
}
