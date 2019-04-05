using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Discord;
using Discord.Commands;

namespace ScrumBot.Core.Commands
{
    public class ListReminders : ModuleBase<SocketCommandContext>
    {
        [Command("ListReminders"), Alias("RemList"), Summary("List all reminders")]
        public async Task RemList()
        {
            if (Context.User.IsBot)
            {
                await ReplyAsync("TESTING .ListReminders");
            }

            // Get reminders
            ReadAndWrite rw = new ReadAndWrite();
            String text = rw.ReadFile("ReminderList");

            var eb = new EmbedBuilder();
            eb.WithColor(Color.Orange);
            eb.WithAuthor("ScrumBot");
            eb.WithTitle("ListReminders");
            eb.WithDescription("Lists all pending reminders.");
            eb.WithFooter("Thank you!");
            eb.AddField("Reminders", text, true);

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }
    }
}
