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
        [Command("CreateFile")]
        public async Task CreateFile(params String[] stringArray)
        {
            Write(stringArray[0], stringArray[1]);
        }

        //Create and Write to a specific file
        async public void Write(String fileName, String addedText)
        {
            String workingDirectory = System.IO.Directory.GetCurrentDirectory();

            String path = Directory.GetParent(workingDirectory).Parent.FullName;
            workingDirectory = path;
            path = Directory.GetParent(workingDirectory).Parent.FullName;
            path = path + @"\ScrumBot\Data\" + fileName + ".txt";


            Console.WriteLine(path);
            StreamWriter File = new StreamWriter(path);
            File.Write(addedText);
            File.Close();
        }

        //public void Write to

    }
}
