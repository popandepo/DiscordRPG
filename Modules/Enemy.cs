using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRPG.Modules
{
    public class EnemyGoblin : ModuleBase<SocketCommandContext>
    {
        [Command("EnemyGoblin")] // RequireUserPermission(permission)
        [Alias("enemygoblin", "ENEMYGOBLIN", "eNEMYgOBLIN")]
        [Summary("")]
        public async Task EnemyGoblinAsync()
        {
            var player = UserTool.IsRegistered(Context.User.Id);
            if (player is null) return;
            Enemy testGoblin = new Enemy("Goblin", new List<string> { "Forest" }, 10, 10, 10, 10, new Material("Goblin Club", 2, 1, "Normal", 20), new Material("Goblin Foot", 1, 1, "Normal", 50), new Material("Goblin Ear", 1, 1, "Normal", 80));
            string output = "You recieved: \n";
            testGoblin.Pull().ForEach(i => output += $"{i.Name}\n");
            await MessageHandler.SendMessageAsync(player, output);
        }
    }
}
