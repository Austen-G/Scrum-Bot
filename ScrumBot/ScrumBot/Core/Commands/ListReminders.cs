using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Collections;

using Discord;
using Discord.Commands;

namespace ScrumBot.Core.Commands
{
    public class ListReminders : ModuleBase<SocketCommandContext>
    {
        [Command("ListReminders"), Alias("RemList"), Summary("List all reminders")]
        public async Task RemList()
        {
            try
            {
                // Read all reminders into an array
                ReadAndWrite rw = new ReadAndWrite();
                ArrayList reminders = new ArrayList();
                using (StreamReader file = File.OpenText(rw.getPath(@"Reminders\ReminderList")))
                {
                    while (!file.EndOfStream)
                        reminders.Add(await file.ReadLineAsync());
                }

                // Foreach reminder
                foreach (Object obj in reminders)
                {
                    // Read in reminder data
                    string fileName = @"Reminders\" + obj;
                    Console.WriteLine(fileName);
                    String name = rw.ReadSection(fileName, "Name");
                    Console.WriteLine(name);
                    String message = rw.ReadSection(fileName, "Message");
                    DateTime expires = DateTime.Parse( rw.ReadSection(fileName, "Time Expires") );
                    String users = rw.ReadSection(fileName, "Target Users");

                    // Print it as an embed
                    var eb = new EmbedBuilder();
                    eb.WithColor(Color.Orange);
                    eb.WithTitle("New Reminder:");
                    eb.WithDescription(message);
                    eb.AddField("Reminder Name:", name, true);
                    eb.AddField("For time:", "(" + expires + ")", true);
                    eb.AddField("Will notify: ", users, false);
                    eb.WithFooter("Reminder logged!");
                    await Context.Channel.SendMessageAsync("", false, eb.Build());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
