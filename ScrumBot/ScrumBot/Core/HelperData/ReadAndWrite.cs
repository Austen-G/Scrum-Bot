using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

using Discord;
using Discord.Commands;
using System.IO;

namespace ScrumBot.Core.Commands
{
    public class ReadAndWrite
    {
        //Create and Write to a specific file
        public void Write(String fileName, String addedText)
        {
            String path = getPath(fileName);
            Console.WriteLine(path);
            StreamWriter File = new StreamWriter(path);
            File.Write(addedText);
            File.Close();
        }

        //public void edit a file based on the section you specify
        public async void Edit(String fileName, String section, String addedText)
        {


            String path = getPath(fileName);
            Console.WriteLine(path);
            StreamWriter writer = File.AppendText(path);
            if (File.Exists(path))
            {
                try
                {
                    using (writer)
                    {
                        await writer.WriteLineAsync(path);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }


        /// <summary>
        /// Finds the path to your local data folder when specified a filename
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public String getPath(String fileName)
        {
            String workingDirectory = System.IO.Directory.GetCurrentDirectory();
            String path = null;
            path = Directory.GetParent(workingDirectory).Parent.FullName;
            workingDirectory = path;
            path = Directory.GetParent(workingDirectory).Parent.FullName;
            path = path + @"\ScrumBot\Data\" + fileName + ".txt";
            return path;
        }
    }
}
