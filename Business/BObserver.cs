using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace Business
{
    /*
      Author: Jefri J. Martínez 
   *  Date: 8/31/2013
   *  Modified: 8/31/2013
   */

    public class BObserver
    {

        private DObserver _dobserver;

        public BObserver()
        {
            _dobserver = new DObserver();
        }

        public void Add(Observer observer)
        {
            if (string.IsNullOrEmpty(observer.Folder))
            {
                throw new Exception("You must complete the field folder to continue!");
            }
            else
            {
                if (!(_dobserver.Add(observer) >= 1))
                {
                    throw new Exception("There was a problem adding the folder, please trying again!");
                }
            }
        }

        public void Update(Observer observer)
        {
            if (observer.Id == 0)
            {
                throw new Exception("You must choose the item you want to update from the list!");
            }
            else if (string.IsNullOrEmpty(observer.Folder))
            {
                throw new Exception("You must complete the field folder to continue!");
            }
            else
            {
                if (!(_dobserver.Update(observer) >= 1))
                {
                    throw new Exception("There was a problem adding the folder, please trying again!");
                }
            }
        }

        public void Delete(Observer observer)
        {
            if (observer.Id == 0)
            {
                throw new Exception("You must choose an item of the list to continue!");
            }
            else
            {
                if (!(_dobserver.Delete(observer) >= 1))
                {
                    throw new Exception("There was a problem deleting the item, please try again");
                }
            }
        }

        public List<Observer> getListOfObservers()
        {
            return _dobserver.getListOfObservers();
        }

    }
}
