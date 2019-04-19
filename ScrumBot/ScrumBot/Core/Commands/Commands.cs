﻿using System;
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
        /**
         *  Defines a task based on given parameters, and adds it to jobs.
         *      [Remainder]string param - Entire substring after the command and space.
         */
        [Command("CreateJob"), Alias("CreateProject"), Summary("Allows the user to create a job for their project")]
        public async Task CreateJob([Remainder]string param)
        {
            string[] args = param.Split('~'); // Parses parameters using '~' delimiter.
            Job job = null;

            if (Context.User.IsBot)
            {
                await ReplyAsync("TESTING .CreateJob");
            }

            var eb = new EmbedBuilder();
            eb.WithColor(Color.Orange);
            eb.WithAuthor("ScrumBot");
            eb.WithFooter("Thank you!");

            // Provides the syntax to create a task
            if (args.Length < 3)
            {
                eb.WithTitle("CreateJob");
                eb.WithDescription("Creates a job for a given user, with the following criteria:");
                eb.AddField(".CreateJob", "Command name");
                eb.AddField("<title>", "Title of the task");
                eb.AddField("<developer>", "Name of developer assigned to task");
                eb.AddField("<description>", "Description of the task");

                await Context.Channel.SendMessageAsync("", false, eb.Build());
            } else {
                job = new Job(args[0], args[1], args[2]); // Creates new job object

                eb.WithTitle("Job Created Successfully!");
                eb.WithDescription("Job '" + args[0] + "' created and saved successfully.");
                eb.AddField("Title:", args[0]);
                eb.AddField("Developer:", args[1]);
                eb.AddField("Description:", args[2]);

                await Context.Channel.SendMessageAsync("", false, eb.Build());
            }
        }

        [Command("CreateStory"), Alias("createStory", "Createstory", "createstory")]
        public async Task CreateStory([Remainder]string param)
        {
            string[] args = param.Split('~');
            Story story = null;

            if (Context.User.IsBot)
            {
                await ReplyAsync("TESTING .CreateStory");
            }

            var eb = new EmbedBuilder();
            eb.WithColor(Color.Orange);
            eb.WithAuthor("ScrumBot");
            eb.WithFooter("Thank you!");

            if (args.Length < 4)
            {
                eb.WithTitle("CreateStory");
                eb.WithDescription("Creates a user story for a given user during a given sprint.");
                eb.AddField(".CreateStory", "Command name");
                eb.AddField("<title>", "Title of user story");
                eb.AddField("<developer>", "Developer assigned to user story");
                eb.AddField("<description>", "Description of user story");
                eb.AddField("<sprint>", "Sprint number");

                await Context.Channel.SendMessageAsync("", false, eb.Build());
            } else
            {
                story = new Story(args[0], args[1], args[2], Convert.ToInt32(args[3]));


                eb.WithTitle("User Story created successfully!");
                eb.WithDescription("Story: '" + args[0] + "' created and saved successfully.");
                eb.AddField("Title:", args[0]);
                eb.AddField("Developer:", args[1]);
                eb.AddField("Description:", args[2]);
                eb.AddField("Sprint:", args[3]);

                await Context.Channel.SendMessageAsync("", false, eb.Build());
            }
        }

        [Command("CreateTask"), Alias("createTask", "Createtask", "createtask")]
        public async Task CreateTask([Remainder]string param)
        {
            string[] args = param.Split('~');
            sTask task = null;

            if (Context.User.IsBot)
            {
                await ReplyAsync("TESTING .CreateTask");
            }

            var eb = new EmbedBuilder();
            eb.WithColor(Color.Orange);
            eb.WithAuthor("ScrumBot");
            eb.WithFooter("Thank you!");

            if (args.Length < 5)
            {
                eb.WithTitle("CreateTask");
                eb.WithDescription("Creates a task within a given story, which has a particular due date.");
                eb.AddField(".CreateTask", "Command name");
                eb.AddField("<title>", "Title of the task");
                eb.AddField("<developer>", "Developer assigned to task");
                eb.AddField("<description>", "Description of the task");
                eb.AddField("<story>", "The story, of which, the task is a part.");
                eb.AddField("<dueDate>", "The date that this particular task is due.");

                await Context.Channel.SendMessageAsync("", false, eb.Build());
            } else
            {
                var story = new Story();
                task = new sTask(args[0], args[1], args[2], story, DateTime.Parse(args[4]));

                eb.WithTitle("Task created successfully!");
                eb.WithDescription("Task: '" + args[0] + "' created and saved successfully.");
                eb.AddField("Title:", args[0]);
                eb.AddField("Developer:", args[1]);
                eb.AddField("Description:", args[2]);
                eb.AddField("Story:", args[3]);
                eb.AddField("Due Date:", args[4]);

                await Context.Channel.SendMessageAsync("", false, eb.Build());
            }
        }
        [Command("UpdateJobStatus"), Alias("UpdateStatus", "Status")]
        public async Task UpdateJobStatus([Remainder]string param)
        {
            // Expecting format .UpdateStatus <SprintNum~JobName~JOB_STATUS>
            //string[] args = param.Split('~'); // Parse input into an array of args
            //if (args.Length < 3)
            //{
            //    await Context.Channel.SendMessageAsync("Too few input arguments");
            //}
            //else
            //{
            //    Job update = changeStatus(args[0], args[1]); // Finds the job by name and changes its status
            //}
        }

        [Command("Startup")]
        public async Task Startup(string projectName)
        {
            if (projectName == null)
            {
                await ReplyAsync("No project specified. Please enter the project name");
            }
            else
            {
                await Startup(projectName);
            }
        }



        [Command("TestMethod")]
        public async Task testFile(string fileName)
        {
            ReadAndWrite rw = new ReadAndWrite();
            rw.CreateEmptyFile(fileName);
        }
    }
}
