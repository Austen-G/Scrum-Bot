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
        String path;

        //Create and Write to a specific file
        public void Write(String fileName, String addedText)
        {
            path = getPath(fileName);
            Console.WriteLine(path);

            StreamWriter File = new StreamWriter(path);
            File.Write(addedText);
            File.Close();
        }

        //edit a file based on the section you specify
        public async void EditSection(string fileName, string section, string newText)
        {
            //Get the path of the file
            path = getPath(fileName);
            Console.WriteLine(path);

            //Create streamReader and a string to read to
            StreamReader sr = File.OpenText(path);
            string str;
            

            //Retrives text file
            string text = File.ReadAllText(path);
            string oldText = null;
            bool foundText = false;

            //replace section with new text
            while ((str = sr.ReadLine()) != null && foundText == false)
            {
                if ((str = sr.ReadLine()) == section)
                {
                    //begin text with ---
                    oldText = sr.ReadLine();
                    //read and copy lines of text
                    while ((str = sr.ReadLine()) != "---")
                    {
                        oldText = oldText + "\r\n" + str;
                    }
                    foundText = true;
                }
            }
            sr.Close();

            //end text with ---
            oldText = oldText + "\r\n" + "---";
            //add markers to new text
            newText = "---\r\n" + newText + "\r\n---";

            //replace old text with specified text
            text = text.Replace(oldText, newText);
            Console.WriteLine(text);

            //Write new text to file.
            await File.WriteAllTextAsync(path, text);
        }


        //edit a file based on the section you specify
        public string ReadFile(string fileName)
        {
            path = getPath(fileName);
            string text = File.ReadAllText(path);
            return text;
        }

        public string ReadSection(string fileName, string sectionName)
        {
            //Create streamReader and a string to read to
            StreamReader sr = openTextToRead(fileName);
            string str;


            //Retrives text file
            string text = "";
            bool foundText = false;

            //replace section with new text
            while ((str = sr.ReadLine()) != null && foundText == false)
            {
                if ((str = sr.ReadLine()) == sectionName)
                {
                    sr.ReadLine();
                    foundText = true;
                    while ((str = sr.ReadLine()) != "---")
                    {
                        text = text + "\r\n" + str;
                    }
                }
            }
            
            return text;
        }

        //add a line to a text file
        public void writeLine(string fileName, string newText)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(getPath(fileName)))
                {
                    sw.WriteLine(newText);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        


        //opens an already made file to read
        public StreamReader openTextToRead(string fileName)
        {
            //Get the path of the file
            path = getPath(fileName);
            Console.WriteLine(path);

            //Create streamReader and a string to read to
            StreamReader sr = File.OpenText(path);
            return sr;
        }

        //opens an already made file to Write
        public StreamWriter openTextToWrite(string fileName)
        {
            //Get the path of the file
            path = getPath(fileName);

            //Create streamReader and a string to read to
            StreamWriter sw = new StreamWriter(path);
            return sw;
        }

        public void addSection( StreamWriter sw, string sectionName, string contents)
        {
            sw.WriteLine(sectionName);
            sw.WriteLine("---");
            sw.WriteLine(contents);
            sw.WriteLine("---");
            sw.WriteLine("");
        }

        public void closeText(StreamWriter sw)
        {
            sw.Close();
        }

        public void closeText(StreamReader sr)
        {
            sr.Close();
        }


        /// <summary>
        /// Finds the path to your local data folder when specified a filename
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public String getPath(String fileName)
        {
            String workingDirectory = System.IO.Directory.GetCurrentDirectory();
            path = Directory.GetParent(workingDirectory).Parent.FullName;
            workingDirectory = path;
            path = Directory.GetParent(workingDirectory).Parent.FullName;
            path = path + @"\ScrumBot\Data\" + fileName + ".txt";
            return path;
        }

    }
}
