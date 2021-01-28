using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;
namespace DiscordRPG
{
    public class DiscordTools
    {
        public static async Task ReactionHandler(Cacheable<IUserMessage, ulong> message, ISocketMessageChannel channel, SocketReaction reaction)//fires when anyone reacts to a message
        {
            if (!reaction.User.Value.IsBot)
            {
                if (Program.players.Contains(reaction.UserId))
                {
                    await channel.SendMessageAsync("Player detected");
                }
                else
                {
                    await channel.SendMessageAsync("You are not currently playing");
                }

                SocketUser temp = Program._client.GetUser(reaction.UserId);

                int index = Program.group.Add(reaction.UserId, temp, temp.Username, temp.ToString());

                await Program.group.SocketUser[0].SendMessageAsync($"{Program.group.UserName[index]}, who has an ID of {Program.group.ID[index]} has reacted to the message which has the ID {reaction.MessageId} in {reaction.Channel} with {reaction.Emote}");
            }
        }

        public static async Task MessageHandler(SocketMessage message) //fires when anyone sends a message
        {
            if (!message.Author.IsBot)
            {
                int index = Program.group.Add(message.Author.Id, Program._client.GetUser(message.Author.Id), message.Author.Username, message.Author.ToString());

                await Program.group.SocketUser[0].SendMessageAsync($"{message.Author.Username}, who has an ID of {message.Author.Id} has sent the message \"{message.Content}\" with the ID {message.Id} in {message.Channel}");

                if (message.Content.StartsWith('|'))
                {
                    string[] command = message.Content.Split('|');
                    switch (command[1].Trim())
                    {
                        case "say":
                            index = Program.group.Find(message.Author.Id);
                            if (Program.group.IsAdmin[index])
                            {
                                string messageToSend = command[2].Trim();
                                await message.Channel.SendMessageAsync(messageToSend);
                            }
                            else
                            {
                                await message.Channel.SendMessageAsync("fuck you, you're not my dad");
                            }
                            break;

                        case "start test":


                            Program.players.Add(new Player(message.Author.Id));


                            var newMessage = message.Channel.SendMessageAsync("A hostile Goblin appears in front of you, what will you do?\n(press the question mark for information)");
                            await newMessage.Result.AddReactionAsync(Emojis.Sword);
                            await newMessage.Result.AddReactionAsync(Emojis.Shield);
                            await newMessage.Result.AddReactionAsync(Emojis.Wand);
                            await newMessage.Result.AddReactionAsync(Emojis.Bag);
                            await newMessage.Result.AddReactionAsync(Emojis.QuestionMark);
                            await newMessage.Result.AddReactionAsync(Emojis.Flag);
                            break;

                        case "kill":
                            index = Program.group.Find(message.Author.Id);
                            if (Program.group.IsAdmin[index])
                            {
                                Program.SafeExit();
                            }
                            await message.Channel.SendMessageAsync($"I'm sorry {message.Author.Username}. I can't let you do that");
                            break;
                        default:
                            Console.WriteLine("a message has been recieved");
                            break;
                    }
                }
            }
        }

        public static async Task<Task> Broadcast(string message) //sends a message to the default channel in all servers
        {
            var temp = Program._client.Guilds;
            foreach (var guild in temp)
            {
                await guild.DefaultChannel.SendMessageAsync(message);
            }
            return Task.CompletedTask;
        }

        public static async Task<Task> InitUserStorage() //starts the user storage
        {
            //Broadcast("I'm online! Harvesting...");
            await Program._client.DownloadUsersAsync(Program._client.Guilds);
            Program.group = new UserStorage();
            Console.WriteLine("Users are downloaded!");
            Program.userStorageInit = true;
            return Task.CompletedTask;
        }

        public static string WriteOrReadFile(string fileName) //reads or writes a file
        {
            string token;

            if (File.Exists(fileName))
            {
                token = File.ReadAllText(fileName);
            }
            else
            {
                Console.WriteLine("Internal BotID missing, please provide BotID");
                token = Console.ReadLine();
                File.WriteAllText(fileName, token);
            }

            return token;
        }
    }
}
