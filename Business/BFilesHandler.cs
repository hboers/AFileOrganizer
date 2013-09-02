using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;
using System.Threading;

namespace Business
{
    /*
       Author: Jefri J. Martínez 
    *  Date: 8/31/2013 11:36PM
    *  Modified: 8/31/2013 
    */

    public class BFilesHandler
    {
        private DAssociation _dassociation;
        private DObserver _dobserver;
        private FilesHandler _filesHandler;

        public BFilesHandler()
        {
            _filesHandler = new FilesHandler();
            _dassociation = new DAssociation();
            _dobserver = new DObserver();
        }


        public void Begin()
        {
            //We are going to do this every minute.
            while (true)
            {
               
                List<Observer> listObserver = _dobserver.getListOfObservers();
                //With this we are going to get all the folders that are going to be monitorized in order to organize the files
                //later.
                string[] directories = (listObserver.Select(x => x.Folder).ToList()).ToArray();

                List<Association> listAssociation = _dassociation.getListOfAssociations();

                string[] patterns = (listAssociation.Select(x => x.Extension).ToList()).ToArray();
                string[] actions = (listAssociation.Select(x => x.Action).ToList()).ToArray();
                string[] destinations = (listAssociation.Select(x => x.Destination).ToList()).ToArray();


                for (int i = 0; i < patterns.Length; i++)
                {
                    _filesHandler.getAllTheFiles(directories, patterns[i]);
                    _filesHandler.OrganizeFiles(actions[i], destinations[i]);
                    _filesHandler.Reset();
                }

                Thread.Sleep(60000);
            }
        }

    }
}
