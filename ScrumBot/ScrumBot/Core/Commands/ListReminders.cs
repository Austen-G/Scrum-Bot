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
            // Get reminders
            ReadAndWrite rw = new ReadAndWrite();
            String text = rw.ReadFile("ReminderList");
            await ReplyAsync(text);
        }
    }
}
