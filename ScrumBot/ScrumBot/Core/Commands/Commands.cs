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
        [Command("CreateJob"), Alias("createJob"), Summary("Allows the user to create a job for their project")]
        public async Task CreateJob([Remainder]string param)
        {
            string[] args = param.Split('~'); // Parses parameters using '~' delimiter.
            
            if (Context.User.IsBot)
            {
                await ReplyAsync("TESTING .CreateJob");
            }
            
            // Provides the syntax to create a task
            if (args.Length < 3)
            {
                var eb = new EmbedBuilder();

                eb.WithColor(Color.Orange);
                eb.WithTitle("CreateJob");
                eb.WithAuthor("ScrumBot");
                eb.WithDescription("Creates a job for a given user, with the following criteria:");
                eb.AddField(".CreateJob", "Command name");
                eb.AddField("<title>", "Title of the task");
                eb.AddField("<developer>", "Name of developer assigned to task");
                eb.AddField("<description>", "Description of the task");
                eb.WithFooter("Thank you!");

                await Context.Channel.SendMessageAsync("", false, eb.Build());
            } else {
                Job job = new Job(args[0], args[1], args[2]);
                jobs.Add(job);

                var eb = new EmbedBuilder();

                eb.WithColor(Color.Orange);
                eb.WithTitle("Job Created Successfully!");
                eb.WithAuthor("ScrumBot");
                eb.WithDescription("Job '" + args[0] + "' created and saved successfully.");
                eb.AddField("Title:", args[0]);
                eb.AddField("Developer:", args[1]);
                eb.AddField("Description:", args[2]);
                eb.WithFooter("Thank you!");

                await Context.Channel.SendMessageAsync("", false, eb.Build());
            }
        }
    }
}
