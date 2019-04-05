using ScrumBot.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ScrumBot.Core.HelperData
{
    class StartNStop
    {
        public void startup()
        {
            ReadAndWrite rw = new ReadAndWrite();

            //create root
            Node<Job> project = new Node<Job>();

            StreamReader sr = rw.openTextToRead(rw.getPath(@"TestProject\StoryList"));
            string str;

            while ((str = sr.ReadLine()) != null)
            {

            }
            
        }

        public void shutDown()
        {


        }
    }
}
