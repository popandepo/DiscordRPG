using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace DiscordRPG.Commands
{
    public class Add : ModuleBase<SocketCommandContext>
    {
        [Command("Add")] // RequireUserPermission(permission)
        [Alias("add")]
        [Summary("")]
        public async Task AddAsync(string content, [Remainder] string extra = null)
        {
            if (Context.User.Id == 235921495291854850)
            {
                try
                {
                    SocketUser user = Program._client.GetUser(Convert.ToUInt64(content));

                    if (!(Program.players.Find(p => p.ID == user.Id) is null) && !(Program.holding.Find(h => h.ID == user.Id) is null))
                    {
                        Console.WriteLine("You are already registered");
                        return;
                    } // If the player is already registered, break out
                    var player = new Player(user.Id);
                    Program.holding.Add(player); // Add the player to players
                    Console.WriteLine($"{player.Hashname} has been added");
                    await MessageHandler.SendMessageAsync(player, $"You have been added to the list of players, please use this channel for any future messages\n{Text.Tutorial(player)}");
                    player.State = State.Begin_battle;
                    await Program.DbHandler.AddUserToDatabase(player);

                }
                catch
                {

                }
            }
        }
    }
}
