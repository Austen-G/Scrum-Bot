using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using ScrumBot.Core;

namespace ScrumBot.Core.Commands
{
    class Meetings : ModuleBase<SocketCommandContext>
    {
        /**
         * sets up a list of topics for a meeting
         */
        [Command("MeetingHelp")]
        public async Task Meeting([Remainder]String param)
        {
            if (param.Length != 3)
            {
                await ReplyAsync("Incorrect format: Name, ");
            }
            
        }
    }
}
