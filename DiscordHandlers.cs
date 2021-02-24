using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DiscordRPG
{
    public class DiscordHandlers
    {

        /// <summary>
        /// Deals with Messages
        /// </summary>
        /// <param name="message">The message that was sent</param>
        /// <returns>Task.CompletedTask</returns>
        public static Task MessageHandler(SocketMessage message)
        {
            if (message.Content.Contains("!"))
            {
                var author = message.Author;
                var channel = message.Channel;
                var command = message.Content.ToLower();
                if (command.Contains("!join")) //Separate commands into a command handler and find an intelligent way to deal with it
                {
                    Program.players.Add(new Player(author.Id));
                }
                else if (command.Contains("!leave"))
                {
                    foreach (var player in Program.players)
                    {
                        if (player.ID == author.Id)
                        {
                            Program.players.Remove(player);
                        }
                    }
                }
                else if (command.Contains("!test")) //REMOVE AFTER TESTING IS DONE
                {
                    author.SendMessageAsync("I recieved a test order, responding as ordered!");
                }

            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Deals with Reactions
        /// </summary>
        /// <param name="trash1">Useless but needed</param>
        /// <param name="channel">The channel the reaction comes from</param>
        /// <param name="reaction">The reaction</param>
        /// <returns>Task.CompletedTask</returns>
        public static Task ReactionHandler(Cacheable<IUserMessage, ulong> trash1, ISocketMessageChannel channel, SocketReaction reaction)
        {
            var emote = reaction.Emote;
            var message = reaction.Message.Value;
            var reacter = reaction.User.Value;
            var author = reaction.Message.Value.Author;
            //var channel = reaction.Channel;

            return Task.CompletedTask;
        }
    }
}