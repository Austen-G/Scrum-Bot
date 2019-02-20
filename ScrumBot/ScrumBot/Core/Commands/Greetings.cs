using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Discord;
using Discord.Commands;

namespace ScrumBot.Core.Commands
{
    public class Greetings : ModuleBase<SocketCommandContext>
    {
        [Command("Greetings"), Alias("Hi", "Hello", "Hey", "Yo"), Summary("Commant to greet people back if they say greet the bot")]
        public async Task Greeting()
        {
            await Context.Channel.SendMessageAsync("Oh hey there!");
        }
    }
}
