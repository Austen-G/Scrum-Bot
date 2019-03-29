using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Discord;
using Discord.Commands;
using System.IO;

namespace ScrumBot.Core.Commands
{
    public class WriteToFile : ModuleBase<SocketCommandContext>
    {
        ReadAndWrite rw = new ReadAndWrite();

        [Command("CreateFile")]
        public async Task CreateFile([Remainder]String param)
        {
            String[] args = param.Split("~");

            var eb = new EmbedBuilder();

            eb.WithColor(Color.Orange);
            eb.WithAuthor("ScrumBot");
            eb.WithTitle("CreateFile");
            eb.WithDescription("Creates a file with the given textual information.");
            eb.WithFooter("Thank you!");

            if (args.Length < 2)
            {
                eb.AddField("Incorrect syntax!", ".CreateFile <filename>~<text>", true);
            }
            else
            {
                rw.Write(args[0], args[1]);
                eb.AddField("File '" + args[0] + "' created successfully!", args[1], true);
            }

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }

        [Command("Edit")]
        public async Task EditFile([Remainder]String param)
        {
            String[] args = param.Split("~");

            var eb = new EmbedBuilder();

            eb.WithColor(Color.Orange);
            eb.WithAuthor("ScrumBot");
            eb.WithTitle("EditFile");
            eb.WithDescription("Appends a file at a given section of text.");
            eb.WithFooter("Thank you!");

            if(args.Length < 3)
            {
                eb.AddField("Incorrect syntax!", ".EditFile <filename>~<section>~<newText>", true);
            }
            else
            {
                rw.EditSection(args[0], args[1], args[2]);
                eb.AddField("File '" + args[0] + "' edited successfully!", "'" + args[2] + "' added at section: " + args[1]);
            }

            await Context.Channel.SendMessageAsync("", false, eb.Build());
        }
    }
}
