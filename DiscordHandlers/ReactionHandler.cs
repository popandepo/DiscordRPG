using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DiscordRPG
{
    public class ReactionHandler
    {
        public static async Task Send(Cacheable<IUserMessage, ulong> trash1, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (!Program._client.GetUser(reaction.UserId).IsBot)
            {
                var emote = reaction.Emote;
                var reacter = Program._client.GetUser(reaction.UserId);
                //var channel = reaction.Channel;

                Player player = UserTools.IsRegistered(reacter.Id);

                if (emote.Name == Emote.QuestionMark.Name && player.HasReadTutorial == false)
                {
                    await player.User.SendMessageAsync(Text.Tutorial(player));
                    player.HasReadTutorial = true;
                    await player.LastMessage.DeleteAsync();
                    player.LastMessage = player.User.SendMessageAsync(Text.GetCombat(player)).Result;
                    await player.LastMessage.AddReactionsAsync(Emote.MainCombat.ToArray());
                }

                if (emote.Name == Emote.Flag.Name)
                {
                    foreach (var item in player.ExpectedEmotes)
                    {
                        var users = player.LastMessage.GetReactionUsersAsync(item, 2).FlattenAsync().Result;

                        foreach (var user in users)
                        {
                            if (user.Id == player.ID && item.Name != Emote.Flag.Name)
                            {
                                player.EmoteHolder.Add(item);
                            }
                        }
                    }
                    player.EmoteAct();
                }

            }
            //return Task.CompletedTask;
        }
    }
}
