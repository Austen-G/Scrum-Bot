using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

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
        [Command("Greetings"), Alias("Hi", "Hello", "Hey", "Yo"), Summary("Commant to greet people back if they say greet the bot")]
        public async Task Greeting() => await ReplyAsync("Oh hey there!");

        /**
         *  Repeats what follows the command back in the channel.
         *      [Remainder]string text - text to be echoed.
         */
        [Command("Echo"), Alias("echo")]
        public async Task Echo([Remainder]string text) => await ReplyAsync(text);
    }

    /**
         *  Sends a list of commands that can be used
         */
    [Command("Help")]
    public async Task Echo()
    {
        // Get reminders
        try
        {
            using (StreamReader sr = File.OpenText("Help.txt"))
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
