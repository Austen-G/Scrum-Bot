using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace ScrumBot.Core.Commands
{
    public class Job
    {
        private string title;
        private string developer;
        private string description;

        public Job( string title, string developer, string description )
        {
            this.description = description;
            this.developer = developer;
            this.description = description;
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
    }

    public class Commands : ModuleBase<SocketCommandContext>
    {
        List<Job> tasks = new List<Job>();

        [Command("CreateTask"), Alias("createTask"), Summary("Allows the user to create a task for their project")]
        public async Task createTask(string title, string developer, string description )
        {
            tasks.Add(new Job(title, developer, description));

            await Context.Channel.SendMessageAsync("Created task titled: '" + title + "' for '" + developer + "' with the following description: '" + description + "'.");
        }
    }
}
