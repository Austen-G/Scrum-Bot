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


        public Job(string title, string developer, string description)
        {
            this.description = description;
            this.developer = developer;
            this.description = description;
            this.jobStatus = status.NOT_STARTED;
            dateCreated = DateTime.Now;
        }

        public Job() { }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetDeveloper(string developer)
        {
            this.developer = developer;
        }

        public string GetDeveloper()
        {
            return developer;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }
        public DateTime getDateCreated()
        {
            return dateCreated;
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

    }

    public class Story : Job
    {
        private int sprintNum;
        private DateTime sprintEndDate;

        public Story(string title, string developer, string description, int sprint) : base(title, developer, description)
        {
            sprintNum = sprint;
        }

        public Story() { }
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

    }

}