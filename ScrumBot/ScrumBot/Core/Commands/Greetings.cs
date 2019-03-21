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
            // Get commands
            try
            {
                ReadAndWrite rw = new ReadAndWrite();
                using (StreamReader sr = File.OpenText(rw.getPath("Help")))
                {
                    string text;
                    while ((text = sr.ReadLine()) != null)
                    {
                        // Send response
                        await Context.Channel.SendMessageAsync(text);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
