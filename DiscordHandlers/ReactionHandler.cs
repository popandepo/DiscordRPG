using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DiscordRPG
{
    class ReactionHandler
    {
        public static Task Send(Cacheable<IUserMessage, ulong> trash1, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (!Program._client.GetUser(reaction.UserId).IsBot)
            {

                var emote = reaction.Emote;
                var reacter = Program._client.GetUser(reaction.UserId);
                var author = reaction.Message.Value.Author;
                //var channel = reaction.Channel;

            }
            return Task.CompletedTask;
        }
    }
}
