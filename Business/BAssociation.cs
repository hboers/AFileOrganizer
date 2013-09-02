using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using System.Text.RegularExpressions;

namespace Business
{
    /*
      Author: Jefri J. Martínez 
   *  Date: 8/31/2013
   *  Modified: 8/31/2013
   */

    public class BAssociation
    {
        private DAssociation _dassociation;

        public BAssociation()
        {
            _dassociation = new DAssociation();
        }

        private bool isValidExtension(string extension)
        {
            Match match = Regex.Match(extension, @"\*\.([a-zA-Z0-9]+)");
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Add(Association association)
        {
            if (string.IsNullOrEmpty(association.Name))
            {
                throw new Exception("You must complete the field name to continue!");
            }
            else if(string.IsNullOrEmpty(association.Action))
            {
                throw new Exception("You must choose an action to continue!");
            }
            else if (string.IsNullOrEmpty(association.Destination))
            {
                throw new Exception("You must complete the field destination choosing a folder to continue!");
            }
            else if (string.IsNullOrEmpty(association.Extension))
            {
                throw new Exception("You must add a file extension to continue!");
            }
            else if (!isValidExtension(association.Extension))
            {
                throw new Exception("The extension is not correct, It must be in this format example: *.jpg or *.yourExtension");
            }
            else
            {
                if (!(_dassociation.Add(association) >= 1))
                {
                    throw new Exception("There was a problem adding this association, please try again.");
                }
            }

        }

        public void Delete(Association association)
        {
            if (association.Id == 0)
            {
                throw new Exception("You must choose an association from the list!");
            }
            else
            {
                if (!(_dassociation.Delete(association) >= 1))
                {
                    throw new Exception("There was a problem deleting the association, please try again!");
                }
            }
        }

        public void Update(Association association)
        {
            if (association.Id == 0)
            {
                throw new Exception("You must choose the item you want to update from the list!");
            }
            else if (string.IsNullOrEmpty(association.Name))
            {
                throw new Exception("You must complete the field name to continue!");
            }
            else if (string.IsNullOrEmpty(association.Action))
            {
                throw new Exception("You must choose an action to continue!");
            }
            else if (string.IsNullOrEmpty(association.Destination))
            {
                throw new Exception("You must complete the field destination choosing a folder to continue!");
            }
            else if (string.IsNullOrEmpty(association.Extension))
            {
                throw new Exception("You must add a file extension to continue!");
            }
            else if (!isValidExtension(association.Extension))
            {
                throw new Exception("The extension is not correct, It must be in this format example: *.jpg or *.yourExtension");
            }
            else
            {
                if (!(_dassociation.Update(association) >= 1))
                {
                    throw new Exception("There was a problem updating this association, please try again.");
                }
            }
        }

        public List<Association> getListOfAssociations()
        {
            return _dassociation.getListOfAssociations();
        }
    }

}
