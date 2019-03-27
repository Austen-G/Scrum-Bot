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
            var eb = new EmbedBuilder();

            eb.WithColor(Color.Orange);
            eb.WithAuthor("ScrumBot");
            eb.WithTitle("Create Reminder");
            eb.WithDescription("Creates a reminder for the current user");
            eb.AddField("Reminder Name:", stringArray[0], true);
            eb.AddField("Created at:", "(" + time + ")", true);
            eb.AddField("User: ", user, true);
            eb.WithFooter("Thank you!");

            await Context.Channel.SendMessageAsync("", false, eb.Build());

            // Log reminder
            try
            {
                ReadAndWrite rw = new ReadAndWrite();
                using (StreamWriter sw = File.AppendText(rw.getPath("ReminderList")))
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
