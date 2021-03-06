﻿using System;
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

        //Create and name the file putting
        public void CreateFileWithTitle(String fileName, String Title)
        {
            StreamWriter sw = new StreamWriter(path);
            sw.Write(Title);
            sw.Close();
        }

        //Create and name the file putting
        public void CreateEmptyFile(String path)
        {
            StreamWriter sw = new StreamWriter(path + ".txt");
            sw.Write("");
            sw.Close();
        }

        // Delete a file
        public void deleteFile(string fileName)
        {
            //Get the path of the file
            path = getPath(fileName);

            //Delete it
            File.Delete(path);
        }

        //edit a file based on the section you specify
        public async void EditSection(string fileName, string section, string newText)
        {
            //Create streamReader and a string to read to
            StreamReader sr = openTextToRead(fileName);
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

            //Write new text to file.
            await File.WriteAllTextAsync(path, text);

            closeText(sr);
        }


        //Read all text in a file
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

            sr.Close();
            return text;
        }

        //opens an already made file to read
        public StreamReader openTextToRead(string fileName)
        {
            //Get the path of the file
            path = getPath(fileName);

            StreamReader sr;

            if (File.Exists(path) == true)
            {
                //Create streamReader and a string to read to
                sr = File.OpenText(path);
            } else
            {
                Console.WriteLine("Unable to open file for read: file does not exist");
                sr = null;
            }
            

            return sr;

            
        }

        //opens a file to write or creates it and opens a blank file
        public StreamWriter openTextToWrite(string fileName)
        {
            //Get the path of the file
            path = getPath(fileName);

            StreamWriter sw;

            if (File.Exists(path) == true)
            {
                //Create streamWriter at end of current text
                sw = File.AppendText(path);
            }
            else
            {
                Console.WriteLine("Unable to open file: file does not exist... Creating new empty file");
                CreateEmptyFile(path);
                sw = openTextToWrite(path);
            }

            sw.WriteLine("");
            return sw;
        }

        public void addSection( StreamWriter sw, string sectionName, string contents)
        {
            sw.WriteLine(sectionName);
            sw.WriteLine("---");
            sw.WriteLine(contents);
            sw.WriteLine("---");
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

        public String getPathNoText(String fileName)
        {
            String workingDirectory = System.IO.Directory.GetCurrentDirectory();
            path = Directory.GetParent(workingDirectory).Parent.FullName;
            workingDirectory = path;
            path = Directory.GetParent(workingDirectory).Parent.FullName;
            path = path + @"\ScrumBot\Data\" + fileName;
            return path;
        }

        //Create Project
        public void writeJob(Job project, string path)
        {
            StreamWriter sw = openTextToWrite(path);
            addSection(sw, "Title", project.getTitle());
            sw.Close();
        }

        //Create Story file
        public void writeJob(Story story, string path)
        {
            StreamWriter sw = openTextToWrite(path);
            addSection(sw, "Title", story.getTitle());
            addSection(sw, "Developer", story.getDeveloper());
            addSection(sw, "Description", story.getDescription());
            addSection(sw, "Sprint", story.getSprint().ToString());
            sw.Close();
        }
        //Create Task
        public void writeJob(sTask task, string path)
        {
            StreamWriter sw = openTextToWrite(path);
            addSection(sw, "Title", task.getTitle());
            addSection(sw, "Developer", task.getDeveloper());
            addSection(sw, "Description", task.getDescription());
            sw.Close();
        }

        //write a list of children of a job
        public void writeChildrenList(Job job, string path)
        {
            StreamWriter sw = openTextToWrite(path);
            for(int i = 0; i < job.children.Count; i++)
            {
                sw.WriteLine(job.children[i].getTitle());
            }
            sw.Close();
        }

        //Create folder and return the path inside the folder
        public string createFolder(string rootFolder, string subFolderName)
        {
            string newPath = System.IO.Path.Combine(rootFolder, subFolderName + @"\");
            System.IO.Directory.CreateDirectory(newPath);
            return newPath;
        }


        public void deleteFolder(string path)
        {

        }
    }
}
