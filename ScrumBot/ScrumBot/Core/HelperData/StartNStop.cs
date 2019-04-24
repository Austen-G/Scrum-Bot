using ScrumBot.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ScrumBot.Core.HelperData
{
    class StartNStop
    {

        ReadAndWrite rw = new ReadAndWrite();

        //create root
        public static Node<Job> project = new Node<Job>();

        public Node<Job> Startup(string projectName)
        {
            StreamReader srStory = rw.openTextToRead(rw.getPath(projectName + @"\StoryList"));
            
            string str;
            string str2;

            //make all stories children of the project
            while ((str = srStory.ReadLine()) != null)
            {
                Story tempStory = new Story(
                    rw.ReadSection(str, "Title"),
                    rw.ReadSection(str, "Developer"),
                    rw.ReadSection(str, "Description"),
                    Convert.ToUInt16(rw.ReadSection(str, "Sprint")));

                Node<Job>tempChild = project.addChild(tempStory);
                StreamReader srTask = rw.openTextToRead(rw.getPath(projectName + @"\" + rw.ReadSection(str, "Title") + @"\TaskList"));
                //make all Tasks children of the corresponding story
                while ((str2 = srTask.ReadLine()) != null)
                {

                    sTask temp2 = new sTask(
                        rw.ReadSection(str, "Title"),
                        rw.ReadSection(str, "Developer"),
                        rw.ReadSection(str, "Description"),
                        tempStory,
                        DateTime.Parse(rw.ReadSection(str, "DateTime")));

                    tempChild.addChild(temp2);
                }
            }

            return project;

        }

        public void Shutdown(Job project)
        {
            BackupProject(project);
            project = null;
        }

        public void BackupProject(Job project)
        {
            //get data folder path
            string currentPath = rw.getPathNoText("");
            //create directory
            currentPath = rw.createFolder(currentPath, project.getTitle());
            //write project file
            rw.writeJob(project, currentPath + project.getTitle());
            //write file with all story names
            rw.writeChildrenList(project, currentPath + "StoryList");

            //Iterate through all stories
            for (int i = 0; i < project.children.Count; i++)
            {
                string pathSection = project.getTitle() + @"\" + project.children[i].getTitle();
                BackupStories(project.children[i], pathSection);
            }
        }


        public void BackupStories(Job story, string pathSection)
        {
            //Set path
            string currentPath = rw.getPathNoText(pathSection);
            //Create directory for story and navigate inside
            currentPath = rw.createFolder(currentPath, story.getTitle());
            //write story file
            rw.writeJob(story, currentPath);
            //Write file with all task names
            rw.writeChildrenList(story, currentPath + "StoryList");

            
            //iterate through all tasks
            for (int i = 0; i < story.children.Count; i++)
            {
                string pathSection2 = currentPath + story.children[i].getTitle();
                BackupTasks(story.children[i], pathSection);
            }
            

        }

        public void BackupTasks(Job task, string pathSection)
        {
            //Set path
            string currentPath = rw.getPathNoText(pathSection);
            //Create directory for story and navigate inside
            currentPath = rw.createFolder(currentPath, task.getTitle());
            //write story file
            rw.writeJob(task, currentPath);
        }

        public Node<Job> GetProject()
        {
            return project;
        }


        public Job GetProjectValue()
        {
            return project.Value;
        }
    }
}
