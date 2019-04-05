using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Discord;
using Discord.Commands;

namespace ScrumBot.Core.Commands
{
    /* Command to create a reminder
     * 
     * Reminders by their name to Reminders\ReminderList.txt
     * Full reminder is created as a new file Reminders\ReminderName.txt with separated sections for each feild of data
     * 
     * Command format
     * .Reminder <Reminder name>~<Reminder message>~<Days.Hours:MinutesFromNow>~<TargetUser1><MoreUsers>...
     */
    public class Reminder : ModuleBase<SocketCommandContext>
    {
        [Command("Reminder"), Alias("Rem"), Summary("Create a new reminder")]
        public async Task CreateRem([Remainder]string param)
        {
            // Parse all input data
            string[] args = param.Split('~'); // Parses parameters using '~' delimiter
            if (args.Length >= 4)
            {
                string name = args[0];                                       // Reminder name (must be unique)
                string message = args[1];                                    // Reminder message text
                var timeCreated = DateTime.Now;                              // Time it was created
                var timeExpires = DateTime.Now.Add(TimeSpan.Parse(args[2])); // Time it will expire (Now + Days.Hours:Minutes)
                var createdBy = Context.User.Mention;                        // User who created the reminder
                string targetUsers = args[3];                                // Users to be notified when reminder expires

                // Send response as pretty embed
                var eb = new EmbedBuilder();
                eb.WithColor(Color.Orange);
                eb.WithTitle("New Reminder:");
                eb.WithDescription(message);
                eb.AddField("Reminder Name:", name, true);
                eb.AddField("For time:", "(" + timeExpires + ")", true);
                eb.AddField("Will notify: ", targetUsers, false);
                eb.WithFooter("Reminder logged!");
                await Context.Channel.SendMessageAsync("", false, eb.Build());

                // Log reminder
                try
                {
                    // Add reminder name to ReminderList.txt
                    ReadAndWrite rw = new ReadAndWrite();
                    using (StreamWriter sw = File.AppendText(rw.getPath(@"Reminders\ReminderList")))
                    {
                        await sw.WriteLineAsync(name);
                    }

                    // Create new reminder file
                    string fileName = @"Reminders\" + name;
                    rw.CreateFileWithTitle(fileName, name);
                    StreamWriter file = rw.openTextToWrite(fileName);
                    rw.addSection(file, "Name", name);
                    rw.addSection(file, "Message", message);
                    rw.addSection(file, "Time created", timeCreated.ToString());
                    rw.addSection(file, "Time Expires", timeExpires.ToString());
                    rw.addSection(file, "Created By", createdBy);
                    rw.addSection(file, "Target Users", targetUsers);
                    rw.closeText(file);
           
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            } else
            {
                // Too few args. Print an error
                await Context.Channel.SendMessageAsync("Oops! That's not enough input arguments for this command. Try:\n" +
                    ".Reminder <Reminder name>~<Reminder message>~<Days.Hours:MinutesFromNow>~<TargetUser1>~<MoreUsers...");
            }
        }
    }
}
