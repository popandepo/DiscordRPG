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
            
            string token = FileManipulation.ReadFile("BotKey.txt");//Reads the token from file

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await _client.SetStatusAsync(UserStatus.Online);

            _client.MessageReceived += DiscordHandlers.MessageHandler;//Whenever a message is heard, push it to the message handler
            _client.ReactionAdded += DiscordHandlers.ReactionHandler;//Whenever a reaction is added, push it to the reaction handler
            _client.ReactionRemoved += DiscordHandlers.ReactionHandler;//Whenever a reaction is removed, push it to the reaction handler

            Console.WriteLine("Initiated!");
        }
    }
}