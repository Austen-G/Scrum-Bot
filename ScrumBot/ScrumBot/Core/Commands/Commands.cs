using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using ScrumBot.Core.HelperData;

namespace ScrumBot.Core.Commands
{
    public class Job
    {
        private string title;
        private string developer;
        private string description;
        private status jobStatus;
        private DateTime dateCreated;
        private DateTime dateLastModified;
        private DateTime dateFinished;


        public Job( string title, string developer, string description )
        {
            this.description = description;
            this.developer = developer;
            this.description = description;
            this.jobStatus = status.NOT_STARTED;
            dateCreated = DateTime.Now;
        }

        public Job( ) { }

        public void SetTitle( string title )
        {
            this.title = title;
        }

        public string GetTitle( )
        {
            return title;
        }

        public void SetDeveloper( string developer )
        {
            this.developer = developer;
        }

        public string GetDeveloper( )
        {
            return developer;
        }

        public void SetDescription( string description )
        {
            this.description = description;
        }

        public string GetDescription( )
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

    public class Commands : ModuleBase<SocketCommandContext>
    {
        List<Story> tasks = new List<Story>();

        [Command("CreateTask"), Alias("createTask"), Summary("Allows the user to create a task for their project")]
        public async Task createTask(string title, string developer, string description)
        {
            Story currStory = new Story(title, developer, description, 0);
            tasks.Add(currStory);

            await Context.Channel.SendMessageAsync("Created story titled: " + title + "' for '" + developer + "' with the following description: '" + description + "'." + "' at Date: '" + currStory.getDateCreated() + "' with status: '" + currStory.getStatus());
        }

    }
}
