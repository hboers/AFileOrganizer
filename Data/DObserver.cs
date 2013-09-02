using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data
{
   /*
      Author: Jefri J. Martínez 
   *  Date: 8/31/2013
   *  Modified: 8/31/2013
   */

    public class DObserver
    {
        private FileOContext _FileOContext;

        public DObserver()
        {
            _FileOContext = new FileOContext();
        }

        public int Add(Observer observer)
        {
            try
            {
                _FileOContext.Observers.Add(observer);
                return _FileOContext.SaveChanges();
            }
            catch (Exception) { return 0; }
        }

        public int Delete(Observer observer)
        {
            try
            {
                _FileOContext.Observers.Remove(observer);
                return _FileOContext.SaveChanges();

            }
            catch (Exception) { return 0; }
        }

        public int Update(Observer observer)
        {
            try
            {
                var old = _FileOContext.Observers.Find(observer.Id);
                old.Folder = observer.Folder;
                return _FileOContext.SaveChanges();
            }
            catch (Exception) { return 0; }
        }

        public List<Observer> getListOfObservers()
        {
            try
            {
                return _FileOContext.Observers.ToList(); 

            }catch(Exception)
            {
                return new List<Observer>();
            }
        }
    }
}
