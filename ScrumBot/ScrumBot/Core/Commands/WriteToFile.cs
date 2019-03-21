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
        ReadAndWrite writer = new ReadAndWrite();

        [Command("CreateFile")]
        public async Task CreateFile(params String[] stringArray)
        {
            writer.Write(stringArray[0], stringArray[1]);
        }

        [Command("EditFile")]
        public async Task EditFile(params String[] stringArray)
        {
            writer.Edit(stringArray[0], stringArray[1], stringArray[2]);
        }
    }
}
