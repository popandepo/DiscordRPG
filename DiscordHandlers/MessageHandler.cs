using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DiscordRPG
{
    public class MessageHandler
    {

        /// <summary>
        /// Deals with Messages
        /// </summary>
        /// <param name="message">The message that was sent</param>
        /// <returns>Task.CompletedTask</returns>
        public static Task Send(SocketMessage message)
        {
            if (!message.Author.IsBot)
            {

                if (message.Content.Contains("!"))
                {
                    var author = message.Author;
                    var channel = message.Channel;
                    var command = message.Content.ToLower();

                    //CommandHandler.Send(author.Id, message.Content);
                }
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// Edits the LastMessage in a player
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="message">The new message</param>
        public static void EditMessage(Player player, string message)
        {
            player.LastMessage.ModifyAsync(m => { m.Content = message; });
        }

        /// <summary>
        /// Sends a message to a player and stores it in LastMessage
        /// </summary>
        /// <param name="player">The player to send a message to</param>
        /// <param name="message">The message to send</param>
        public static void SendMessage(Player player, string message)
        {
            player.LastMessage = player.User.SendMessageAsync(message).Result;
        }

        public static Task SendMessageAsync(Player player, string message)
        {
            player.LastMessage = player.User.SendMessageAsync(message).Result;
            return Task.CompletedTask;
        }

        public static Task EditMessageAsync(Player player, string message)
        {
            player.LastMessage.ModifyAsync(m => { m.Content = message; });
            return Task.CompletedTask;
        }
    }
}