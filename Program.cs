﻿using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DiscordRPG
{
    class Program
    {
        public static DiscordSocketClient _client;
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("test");
            await BotInit();
            Console.ReadLine();
        }

        /// <summary>
        /// Initiates the bot
        /// </summary>
        /// <returns>Nothing</returns>
        private static async Task BotInit() //starts the bot and initiates all handlers
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig() { AlwaysDownloadUsers = true });
            
            string token = ReadFile("BotKey.txt");//Reads the token from file

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await _client.SetStatusAsync(UserStatus.Online);

            _client.MessageReceived += MessageHandler;//Whenever a message is heard, push it to the message handler
            _client.ReactionAdded += ReactionHandler;//Whenever a reaction is added, push it to the reaction handler
            _client.ReactionRemoved += ReactionHandler;//Whenever a reaction is removed, push it to the reaction handler

            Console.WriteLine("Initiated!");
        }

        /// <summary>
        /// Reads a file with the given filename
        /// </summary>
        /// <param name="fileName">The name of the file to read</param>
        /// <returns>A string with the contents of the file</returns>
        private static string ReadFile(string fileName)
        {
            var filePath = Path.GetFullPath(fileName);

            string output = File.ReadAllText(filePath);
            
            return output;
        }

        /// <summary>
        /// Deals with Reactions
        /// </summary>
        /// <param name="trash1">Useless but needed</param>
        /// <param name="channel">The channel the reaction comes from</param>
        /// <param name="reaction">The reaction</param>
        /// <returns>Task.CompletedTask</returns>
        private static Task ReactionHandler(Cacheable<IUserMessage, ulong> trash1, ISocketMessageChannel channel, SocketReaction reaction)
        {
            var emote = reaction.Emote;
            var message = reaction.Message.Value;
            var reacter = reaction.User.Value;
            var author = reaction.Message.Value.Author;

            return Task.CompletedTask;
        }

        /// <summary>
        /// Deals with Messages
        /// </summary>
        /// <param name="message">The message that was sent</param>
        /// <returns>Task.CompletedTask</returns>
        private static Task MessageHandler(SocketMessage message)
        {
            var author = message.Author;
            var channel = message.Channel;

            return Task.CompletedTask;
        }
    }
}