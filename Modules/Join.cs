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
            if (!(Program.players.Find(i => i.ID == Context.User.Id) is null))
            {
                Console.WriteLine("You are already registered");
            } // If the player is already registered, break out
            var player = new Player(Context.User.Id);
            Program.players.Add(player); // Add the player to players
            MessageHandler.SendMessage(player, "You have been added to the list of players, please use this channel for any future messages");
            Console.WriteLine($"{player.Hashname} has been added");
            await Context.Channel.SendMessageAsync("Joining");
        }
    }
}
