﻿using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace DiscordRPG.Commands
{
    public class TestDB : ModuleBase<SocketCommandContext>
    {
        [Command("TestDB")] // RequireUserPermission(permission)
        [Alias("TestDB")]
        [Summary("")]
        public async Task TestDBAsync()
        {
            Console.WriteLine("In testdb");
            var userid = Context.User.Id;
            //var p = new Player(userid);
            Console.WriteLine("Going to Get");
            var x = await Program.DbHandler.GetUserFromDatabase(userid);
            Console.WriteLine(x);
        }
    }
}
