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

    public class DAssociation
    {

        private FileOContext _FileOContext;

        public DAssociation()
        {
            _FileOContext = new FileOContext();
        }

        public int Add(Association association)
        {
            try
            {
                _FileOContext.Associations.Add(association);
                return _FileOContext.SaveChanges();
            }
            catch (Exception) { return 0; }
        }

        public int Delete(Association association)
        {
            try
            {
               _FileOContext.Associations.Remove(association);
                return _FileOContext.SaveChanges(); 
            }
            catch (Exception) { return 0; }

        }

        public int Update(Association association)
        {
            try
            {

                var old = _FileOContext.Associations.Find(association.Id);
                old.Name = association.Name;
                old.Extension = association.Extension;
                old.Destination = association.Destination;
                old.Action = association.Action;

                return _FileOContext.SaveChanges();
            }
            catch (Exception) { return 0; }
        }

        public List<Association> getListOfAssociations()
        {
            try
            {
                return _FileOContext.Associations.ToList();
            }
            catch (Exception) 
            {
                return new List<Association>();
            }
        }
    }
}
