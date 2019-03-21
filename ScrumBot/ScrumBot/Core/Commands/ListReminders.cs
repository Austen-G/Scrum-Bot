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


            try
            {
                ReadAndWrite rw = new ReadAndWrite();
                using (StreamReader sr = File.OpenText(rw.getPath("ReminderList")))
                {
                    string text;
                    while ((text = sr.ReadLine()) != null)
                    {
                        // Send response
                        await Context.Channel.SendMessageAsync(text);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
