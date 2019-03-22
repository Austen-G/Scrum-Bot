using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using Discord;
using Discord.Commands;

namespace ScrumBot.Core.Commands
{
    /**
     * Greetings class contains simple communcation commands.
     */
    public class Greetings : ModuleBase<SocketCommandContext>
    {
        /**
         * Replies to simple greeting commands.
         */
        [Command("Greetings"), Alias("Hi", "Hello", "Hey", "Yo"), Summary("Command to greet people back if they say greet the bot")]
        public async Task Greeting() => await ReplyAsync("Oh hey there!");

        /**
         *  Repeats what follows the command back in the channel.
         *      [Remainder]string text - text to be echoed.
         */
        [Command("Echo"), Alias("echo")]
        public async Task Echo([Remainder]string text) => await ReplyAsync(text);

        /**
         *  Sends a list of commands that can be used
         */
        [Command("Help"), Summary("Returns a list of commands that can be used")]
        public async Task Help()
        {
            ReadAndWrite rw = new ReadAndWrite();
            String text = rw.ReadFile("Help");
            await ReplyAsync(text);
        }
    }
}
