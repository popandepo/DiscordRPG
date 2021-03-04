# DiscordRPG.Commands
Commands can be added by folowing this pattern and adding the file to Commands folder.
```cs
using Discord.Commands;
using System.Threading.Tasks;

namespace DiscordRPG.Commands
{
    public class <CLASS NAME> : ModuleBase<SocketCommandContext>
    {
        [Command("<COMMAND NAME>")] // RequireUserPermission(permission)
        [Alias("<COMMAND ALIASES>")]
        [Summary("")]
        public async Task <COMMAND NAME>Async()
        {

        }
    }
}
```

[Home (ProgramLogic)](https://github.com/popandepo/DiscordRPG/tree/ProgramLogic)

<!-- CHANGE TO THIS!!! (https://github.com/popandepo/DiscordRPG)-->