using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using ScrumBot.Core;
using ScrumBot.Core.HelperData;

namespace ScrumBot.Core.Commands
{
    /**
     * Commands class contains all of the commands for the bot.
     */

    public class Commands : ModuleBase<SocketCommandContext>
    {
        public ScrumBoard sb = new ScrumBoard();
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
                sb.addToNotStarted(story);

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
        [Command("UpdateStoryStatus"), Alias("UpdateStatus", "Status")]
        public async Task UpdateStatus([Remainder]string param)
        {
            //Expecting format .UpdateStatus <StoryName~OldStatus~NewStatus>
            string[] args = param.Split('~'); // Parse input into an array of args
            if (args.Length < 3)
            {
                await Context.Channel.SendMessageAsync("Too few input arguments. Try: .UpdateStatus <StoryName~OldStatus~NewStatus>");
            }
            else
            {
                status oldStatus;
                status newStatus;

                switch (args[1])
                {
                    case "NOT_STARTED":
                        oldStatus = status.NOT_STARTED;
                        break;
                    case "IN_PROGRESS":
                        oldStatus = status.IN_PROGRESS;
                        break;
                    case "NEEDS_TESTING":
                        oldStatus = status.NEEDS_TESTING;
                        break;
                    case "IN_TESTING":
                        oldStatus = status.IN_TESTING;
                        break;
                    case "DONE":
                        oldStatus = status.DONE;
                        break;
                    case "COMPLETE":
                        oldStatus = status.COMPLETE;
                        break;
                    default:
                        oldStatus = status.NOT_STARTED;
                        break;
                }
                switch (args[2])
                {
                    case "NOT_STARTED":
                        newStatus = status.NOT_STARTED;
                        break;
                    case "IN_PROGRESS":
                        newStatus = status.IN_PROGRESS;
                        break;
                    case "NEEDS_TESTING":
                        newStatus = status.NEEDS_TESTING;
                        break;
                    case "IN_TESTING":
                        newStatus = status.IN_TESTING;
                        break;
                    case "DONE":
                        newStatus = status.DONE;
                        break;
                    case "COMPLETE":
                        newStatus = status.COMPLETE;
                        break;
                    default:
                        newStatus = status.NOT_STARTED;
                        break;
                }

                bool success = false;

                // Gets a list of all stories with the old status input from the second argument
                List<Story> stories = sb.getList( oldStatus );

                // Find the story input by name
                foreach (Story s in stories)
                {
                    Console.WriteLine("1");
                    if( s.getTitle().Equals(args[0]) )
                    {
                        Console.WriteLine("2");
                        success = sb.changeStatus(s, newStatus);
                        break;
                    }
                }
                if( !success )
                {
                    await Context.Channel.SendMessageAsync("Error: Failed to change status of story " + args[0]);
                } else
                {
                    var eb = new EmbedBuilder();
                    eb.WithColor(Color.Orange);
                    eb.WithAuthor("ScrumBot");
                    eb.WithFooter("Thank you!");
                    eb.WithTitle("Status Changed");
                    eb.WithDescription("Story: " + args[0] + " now has status " + newStatus);

                    await Context.Channel.SendMessageAsync("", false, eb.Build());
                }
            }
        }

        [Command("Startup")]
        public async Task begin(string projectName)
        {
            StartNStop sns = new StartNStop();

            if (projectName == null)
            {
                await ReplyAsync("No project specified. Please enter the project name");
            }
            else
            {
                sns.Startup(projectName);
            }
        }

        [Command("Shutdown")]
        public async Task end()
        {
            StartNStop sns = new StartNStop();

            sns.Shutdown(sns.GetProjectValue());
        }

        [Command("TestMethod")]
        public async Task Test()
        {

            ReadAndWrite rw = new ReadAndWrite();
            StartNStop sns = new StartNStop();
            
            sns.Shutdown(sns.GetProjectValue());

        }    
    }
}
