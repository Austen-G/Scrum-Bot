using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using ScrumBot.Core;

namespace ScrumBot.Core.Commands
{
   

    /**
     * Commands class contains all of the commands for the bot.
     */
    public class Commands : ModuleBase<SocketCommandContext>
    {
        List<Job> jobs = new List<Job>(); // A collection for all the jobs to add in a session.

        /**
         *  Defines a task based on given parameters, and adds it to jobs.
         *      [Remainder]string param - Entire substring after the command and space.
         */
        [Command("CreateTask"), Alias("createTask"), Summary("Allows the user to create a task for their project")]
        public async Task CreateTask([Remainder]string param)
        {
            string[] args = param.Split('~'); // Parses parameters using '~' delimiter.
            // Provides the syntax to create a task
            if (args.Length < 3)
            {
                var eb = new EmbedBuilder();

                eb.WithColor(Color.Orange);
                eb.WithTitle("CreateTask");
                eb.WithAuthor("ScrumBot");
                eb.WithDescription("Creates a task for a given user, with the following criteria:");
                eb.AddField(".CreateTask", "Command name");
                eb.AddField("<title>", "Title of the task");
                eb.AddField("<developer>", "Name of developer assigned to task");
                eb.AddField("<description>", "Description of the task");
                eb.AddField("[jobStatus]", "(0) NOT_STARTED, (1) IN_PROGRESS, (2) NEEDS_TESTING, (3) IN_TESTING, (4) DONE, (5) COMPLETE");
                eb.WithFooter("Thank you!");

                await Context.Channel.SendMessageAsync("", false, eb.Build());
            }
            else
            {
                Story story = new Story(args[0], args[1], args[2], Convert.ToInt32(args[3]));

                var eb = new EmbedBuilder();

                eb.WithColor(Color.Orange);
                eb.WithTitle("Task Created Successfully!");
                eb.WithAuthor("ScrumBot");
                eb.WithDescription("Task '" + args[0] + "' created and saved successfully.");
                eb.AddField("Title:", args[0]);
                eb.AddField("Developer:", args[1]);
                eb.AddField("Description:", args[2]);
                eb.AddField("Job Status:", args[3]);
                eb.WithFooter("Thank you!");

                await Context.Channel.SendMessageAsync("", false, eb.Build());
            }
        }
    }
}
