using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using Discord;
using Discord.Commands;
using ScrumBot.Core.HelperData;

namespace ScrumBot.Core.Commands
{
    class TreeEditingCommands : ModuleBase<SocketCommandContext>
    {
        /**
         * startup the live project tree
         */

        [Command("Startup"), Alias("startup")]
        public async Task Startup([Remainder]String param)
        {
            if(param.Length != 2)
            {
                await ReplyAsync("incorrect number of param");
            }
        }
    }
}
