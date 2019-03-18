using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Discord;
using Discord.Commands;

namespace ScrumBot.Core.Commands
{
    public class Reminder : ModuleBase<SocketCommandContext>
    {
        [Command("Reminder"), Alias("Rem"), Summary("Create a new reminder")]
        public async Task CreateRem(params String[] stringArray)
        {
            // Get the time and user info
            var time = DateTime.Now;
            var user = Context.User.Mention;

            // Send response
            String text = "Reminder '" + stringArray[0] + "' created at time: (" + time + ") by user: " + user;
            await Context.Channel.SendMessageAsync(text);

            // Log reminder
            try
            {
                using (StreamWriter sw = File.AppendText("ReminderList.txt"))
                {
                    await sw.WriteLineAsync(text);
                }
                } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
