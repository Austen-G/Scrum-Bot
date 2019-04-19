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
    public class Project
    {
        private string title;
        private List<Job> jobs;

        public Project(string title)
        {
            this.title = title;
            jobs = new List<Job>();
        }

        public void addJob(Job job)
        {
            jobs.Add(job);
        }

        public void removeJob(Job job)
        {
            jobs.Remove(job);
        }
    }

    public class Job
    {
        private string title;
        private string developer;
        private string description;
        private status jobStatus;
        private DateTime dateCreated;
        private DateTime dateLastModified;
        private DateTime dateFinished;
        public List<Story> stories;


        public Job(string title, string developer, string description)
        {
            this.title = title;
            this.developer = developer;
            this.description = description;
            this.jobStatus = status.NOT_STARTED;
            dateCreated = DateTime.Now;
            stories = new List<Story>();

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
            stories.Add(story);
        }
        public void removeStory( Story story )
        {
            stories.Remove(story);
        }

    }

    public class Story : Job
    {
        private int sprintNum;
        private DateTime sprintEndDate;

        public List<sTask> taskList = new List<sTask>();

        public Story(string title, string developer, string description, int sprint) : base(title, developer, description)
        {
            sprintNum = sprint;
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

        public List<sTask> getTaskList()
        {
            return taskList;
        }
        public void setTaskList(List<sTask> tasks)
        {
            taskList = tasks;
        }

        public Story findStory(string name)
        {
            return null;
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