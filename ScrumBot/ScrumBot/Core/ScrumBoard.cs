using System;
using System.Collections.Generic;
using System.Text;

using ScrumBot.Core.HelperData;

namespace ScrumBot.Core
{
    
    public struct lists
    {
        public List<Story> notStarted;
        public List<Story> inProgress;
        public List<Story> inTesting;
        public List<Story> done;
        public List<Story> complete;

        public lists(List<Story> ns, List<Story> ip, List<Story> it, List<Story> d, List<Story> c)
        {
            notStarted = ns;
            inProgress = ip;
            inTesting = it;
            done = d;
            complete = c;
        }
    }

    public class ScrumBoard
    {
        // different lists for story progress
        public List<Story> notStarted = new List<Story>();
        public List<Story> inProgress = new List<Story>();
        public List<Story> inTesting = new List<Story>();
        public List<Story> done = new List<Story>();
        public List<Story> complete = new List<Story>(); 
        
        public ScrumBoard(){}


        // methods expressions to add a given story to a status list
        public void addToNotStarted(Story s) => notStarted.Add(s);
        public void addToInProgress(Story s) => inProgress.Add(s);
        public void addToInTesting(Story s) => inTesting.Add(s);
        public void addToDone(Story s) => done.Add(s);
        public void addToComplete(Story s) => complete.Add(s);

        public lists getAllLists()
        {
            lists lStruct = new lists(this.notStarted, this.inProgress, this.inTesting, this.done, this.complete);
            return lStruct;
        }


        // method to return a list of all stories with a given status
        public List<Story> getList(status s)
        {
            List<Story> temp = null;

            switch (s)
            {
                case status.NOT_STARTED:
                    temp = this.notStarted;
                    break;
                case status.IN_PROGRESS:
                    temp = this.inProgress;
                    break;
                case status.IN_TESTING:
                    temp = this.inTesting;
                    break;
                case status.DONE:
                    temp = this.done;
                    break;
                case status.COMPLETE:
                    temp = this.complete;
                    break;
            }

            return temp;
        }

        public bool changeStatus(Story s, status newStatus)
        {


            // set our return to false as default and grab the current status of our story
            bool successful = false;
            status currStatus = s.getStatus();


            string sName = s.getTitle();
            Console.WriteLine("Request to change story " + sName + "with status " + currStatus + " to " + newStatus);

            // if we are trying to change the status of the story to its current status, we did nothing
            if (currStatus == newStatus)
            {
                return successful;
            }

            // get the title of the story
            String title = s.getTitle();

            // define the holder for our search list (makes searching easier later) 
            List<Story> searchList = null;


            // set our searchlist to the corresponding list for our stories status
            switch (currStatus)
            {
                case status.NOT_STARTED:
                    searchList = this.notStarted;
                    break;
                case status.IN_PROGRESS:
                    searchList = this.inProgress;
                    break;
                case status.IN_TESTING:
                    searchList = this.inTesting;
                    break;
                case status.DONE:
                    searchList = this.done;
                    break;
                case status.COMPLETE:
                    searchList = this.complete;
                    break;
            }
           
            // loop through all stories in our search list
            foreach(Story thisStory in searchList)
            {
                // temp variable for our story if we find it
                Story temp = null;

                // if we find our story in the list, remove it from the old, and 
                if(thisStory.getTitle().Equals(title))
                {

                    temp = thisStory; // temp variable to avoid messiness in adding/removing iterator variable

                    status removeStatus = thisStory.getStatus(); // status to determine which list to remove from

                    // removes the desired story from the old 
                    switch (removeStatus)
                    {
                        case status.NOT_STARTED:
                            this.notStarted.Remove(temp);
                            break;
                        case status.IN_PROGRESS:
                            this.inProgress.Remove(temp);
                            break;
                        case status.IN_TESTING:
                            this.inTesting.Remove(temp);
                            break;
                        case status.DONE:
                            this.done.Remove(temp);
                            break;
                        case status.COMPLETE:
                            this.complete.Remove(temp);
                            break;
                    }

                    // set the status of temp to the given status
                    temp.setStatus(newStatus);

                    // adds to the new list defined by newStatus
                    switch (newStatus)
                    {
                        case status.NOT_STARTED:
                            this.notStarted.Add(temp);
                            successful = true;
                            break;
                        case status.IN_PROGRESS:
                            this.inProgress.Add(temp);
                            successful = true;
                            break;
                        case status.IN_TESTING:
                            this.inTesting.Add(temp);
                            successful = true;
                            break;
                        case status.DONE:
                            this.done.Add(temp);
                            successful = true;
                            break;
                        case status.COMPLETE:
                            this.complete.Add(temp);
                            successful = true;
                            break;
                    }
                }
            }

            return successful;

        }
    }


}
