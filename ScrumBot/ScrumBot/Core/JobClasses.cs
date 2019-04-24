/**
    * Job class is an object containing basic data about a particular job
    */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

using ScrumBot.Core.HelperData;

namespace ScrumBot.Core
{
    public class Job
    {
        private string title;
        private string developer;
        private string description;
        private status jobStatus;
        private DateTime dateCreated;
        private DateTime dateLastModified;
        private DateTime dateFinished;
        public List<Job> children;


        public Job(string title, string developer, string description)
        {
            this.title = title;
            this.developer = developer;
            this.description = description;
            this.jobStatus = status.NOT_STARTED;
            dateCreated = DateTime.Now;
            children = new List<Job>();
            StartNStop.project.setValue(this);
        }

        public Job() { }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public string getTitle()
        {
            return title;
        }

        public void setDeveloper(string developer)
        {
            this.developer = developer;
        }

        public string getDeveloper()
        {
            return developer;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public string getDescription()
        {
            return description;
        }
        public DateTime getDateCreated()
        {
            return dateCreated;
        }
        public void setStatus(status jobStatus)
        {
            this.jobStatus = jobStatus;
        }
        public status getStatus()
        {
            return jobStatus;
        }
        public DateTime getDateLastModified()
        {
            return dateLastModified;
        }
        public DateTime getDateFinished()
        {
            return dateFinished;
        }
        public void addStory( Story story )
        {
            children.Add(story);
        }
        public void addTask( sTask task)
        {
            children.Add(task);
        }

        public Job getStory(Story story)
        {
            foreach(var item in children)
            {
                if (item == story) return item;
            }

            return null;
        }
        public void removeStory( Story story )
        {
            children.Remove(story);
        }

    }

    public class Story : Job
    {
        private int sprintNum;
        private DateTime sprintEndDate;

        public Story(string title, string developer, string description, int sprint) : base(title, developer, description)
        {
            sprintNum = sprint;
            StartNStop.project.Value.addStory(this);
        }

        public Story() { }

        // accessors and mutators for story specific fields
        public int getSprint()
        {
            return sprintNum;
        }

        public void setSprint(int sprint)
        {
            sprintNum = sprint;
        }

        public List<Job> getTaskList()
        {
            return children;
        }
        public void setTaskList(List<Job> tasks)
        {
            children = tasks;
        }
    }



    public class sTask : Job
    {
        private Story parStory;
        private DateTime dueDate;

        public sTask(string title, string developer, string description, Story story, DateTime date) : base(title, developer, description)
        {
            parStory = story;
            dueDate = date;
            StartNStop.project.Value.getStory(story).addTask(this);
        }

        // accessors and mutators for sTask specific fields
        public Story getStory()
        {
            return parStory;
        }
        public DateTime getDueDate()
        {
            return dueDate;
        }

        public void setStory(Story story)
        {
            parStory = story;
        }
        public void setDueDate(DateTime date)
        {
            dueDate = date; 
        }

        public sTask findTask(string name)
        {
            return null;
        }
    }

}