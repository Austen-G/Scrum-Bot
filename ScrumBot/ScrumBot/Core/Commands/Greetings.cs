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
            /**
            ReadAndWrite rw = new ReadAndWrite();
            String text = rw.ReadFile("Help");
            String[] commands = text.Split("\n");
            */
            var eb = new EmbedBuilder();
            eb.WithColor(Color.Orange);
            eb.WithAuthor("ScrumBot");
            eb.WithTitle("Help");
            eb.WithDescription("Here's a list of the available commands: ");
            eb.AddField(".CreateFile <filename> <text>", "Creates a new file with the given text input", false);
            eb.AddField(".CreateTask <title>~<developer>~<description>~<jobStatus>", "Creates a task for a certain developer with the given text input", false);
            eb.AddField(".Echo <text>", "Repeats text back to user", false);
            eb.AddField(".Edit <filename> <section> <newText>", "Edits an existing file at the given section.", false);
            eb.AddField(".Greetings", "Bot says 'Oh hey there!'", false);
            eb.AddField(".Help", "Lists available commands.", false);
            eb.AddField(".Reminder <title>", "Creates a reminder for an individual.", false);
            eb.AddField(".ListReminders", "Lists all reminders for the entire team.", false);

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }
    }
}
