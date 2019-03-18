using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;



namespace ScrumBot.Core.HelperData
{

    // Enumeration to help better understand the status of a task/story 
    public enum status
    {
        NOT_STARTED = 0,    // not started-unassigned
        IN_PROGRESS = 1,    // in progress
        NEEDS_TESTING = 2,  // needs to be tested
        IN_TESTING = 3,     // currently being tested
        DONE = 4,           // all testing successful
        COMPLETE = 5        // no additinoal changes should be made
    }





}

