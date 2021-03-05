using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace DiscordRPG.Commands
{
    public class Join : ModuleBase<SocketCommandContext>
    {
        [Command("join")] // RequireUserPermission(permission)
        [Alias("JOIN", "Join", "jOIN")]
        [Summary("")]
        public async Task JoinAsync()
        {
            if (!(Program.players.Find(p => p.ID == Context.User.Id) is null) && !(Program.holding.Find(h => h.ID == Context.User.Id) is null))
            {
                Console.WriteLine("You are already registered");
                return;
            } // If the player is already registered, break out
            var player = new Player(Context.User.Id);
            Program.holding.Add(player); // Add the player to players
            Console.WriteLine($"{player.Hashname} has been added");
            await MessageHandler.SendMessageAsync(player, $"You have been added to the list of players, please use this channel for any future messages\n{Text.Tutorial(player)}");
            player.State = "BEGIN BATTLE";
            await Program.DbHandler.AddUserToDatabase(player);
        }
    }
}
