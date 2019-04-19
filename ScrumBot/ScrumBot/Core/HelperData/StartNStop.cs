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

        public Node<Job> startup(string projectName)
        {
            

            //create root
            Node<Job> project = new Node<Job>();

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

        public void shutDown(Job project)
        {
            backupStories(project);
        }

        public void backupStories(Job project)
        {
            for(int i = 0; i < project.stories.Count; i++)
            {
                rw.writeStory(project.stories[i]);
                backupSTask(project.stories[i]);
            }
        }

        public void backupSTask(Story story)
        {
            for (int i = 0; i < story.taskList.Count; i++)
            {
                rw.writeTask(story.taskList[i]);
            }
        }
    }
}
