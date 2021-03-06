﻿using System;
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
        [Command("Help"), Alias("help"), Summary("Returns a list of commands that can be used")]
        public async Task Help()
        {
            /**
            ReadAndWrite rw = new ReadAndWrite();
            String text = rw.ReadFile("Help");
            String[] commands = text.Split("\n");
            */

            if (Context.User.IsBot)
            {
                await ReplyAsync("TESTING .Help");
            }
            
            var eb = new EmbedBuilder();
            eb.WithColor(Color.Orange);
            eb.WithAuthor("ScrumBot");
            eb.WithTitle("Help");
            eb.WithDescription("Here's a list of the available commands: ");
            eb.AddField(".CreateFile <filename> <text>", "Creates a new file with the given text input", true);
            eb.AddField(".CreateJob <Title>~<Developer>~<Description>", "Create a job for the scrumboard", true);
            eb.AddField(".CreateStory <Title>~<Developer>~<Description>~<SprintNumber>", "Create a user story for the scrumboard", true);
            eb.AddField(".CreateTask <title>~<developer>~<description>~<jobStatus>", "Creates a task for a certain developer with the given text input", true);
            eb.AddField(".UpdateStatus <StoryName>~<OldStatus>~<NewStatus>", "Change the status of a user story", true);
            eb.AddField(".Echo <text>", "Repeats text back to user", true);
            eb.AddField(".Edit <filename> <section> <newText>", "Edits an existing file at the given section.", true);
            eb.AddField(".Greetings", "Bot says 'Oh hey there!'", true);
            eb.AddField(".Help", "Lists available commands.", true);
            eb.AddField(".Reminder <Reminder name>~<Reminder message>~<MM/DD/YY HH:MM AM/PM>~<TargetUsers>", "Creates a new reminder.", true);
            eb.AddField(".ListReminders", "Lists all reminders for the entire team.", true);

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }
    }
}
