using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using ScrumBot.Core.HelperData;

namespace ScrumBot.Core.Commands
{
    /**
     * Job class is an object containing basic data about a particular job
     */
    public class Job
    {
        private string title;
        private string developer;
        private string description;
        private status jobStatus;
        private DateTime dateCreated;
        private DateTime dateLastModified;
        private DateTime dateFinished;


        public Job(string title, string developer, string description)
        {
            this.description = description;
            this.developer = developer;
            this.description = description;
            this.jobStatus = status.NOT_STARTED;
            dateCreated = DateTime.Now;
        }

        public Job() { }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetDeveloper(string developer)
        {
            this.developer = developer;
        }

        public string GetDeveloper()
        {
            return developer;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }
        public DateTime getDateCreated()
        {
            return dateCreated;
        }
        public status getStatus()
        {
            return jobStatus;
        }
        public DateTime getDateLastModified()
        {
            return dateLastModified;
        }
        public DateTime getDateFinished()
        {
            return dateFinished;
        }

    }

    public class Story : Job
    {
        private int sprintNum;
        private DateTime sprintEndDate;

        public Story(string title, string developer, string description, int sprint) : base(title, developer, description)
        {
            sprintNum = sprint;
        }

        public Story() { }
    }

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
                await ReplyAsync("CreateTask <task>~<developer>~<description>");
                return;
            }
            else
            {
                jobs.Add(new Job(args[0], args[1], args[2])); // Adds it to jobs
                // Mentions user in reply if user is not a bot
                if (!Context.User.IsBot)
                    await ReplyAsync(Context.User.Mention + " Task: '" + args[0] + "', Developer: '" + args[1] + "', Description: '" + args[2] + "'.");
                else
                    await ReplyAsync("Task: '" + args[0] + "', Developer: '" + args[1] + "', Description: '" + args[2] + "'.");
                // Replies to the user, confirming the task.
            }
        }
    }
}
