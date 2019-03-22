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
        public async Task CreateFile(params String[] stringArray)
        {
            if (stringArray.Length != 3)
            {
                await ReplyAsync("Incorrect number of parameters:");
            }
            rw.Write(stringArray[0], stringArray[1]);
            await ReplyAsync("File Edited");
        }

        [Command("Edit")]
        public async Task EditFile(params String[] stringArray)
        {
            if(stringArray.Length != 3)
            {
                await ReplyAsync("Incorrect number of parameters: .Edit filename section newText");
            }
            rw.EditSection(stringArray[0], stringArray[1], stringArray[2]);
            await ReplyAsync("File Edited");
        }
    }
}
