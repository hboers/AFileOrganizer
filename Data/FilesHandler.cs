using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Data
{
    /*
      Author: Jefri J. Martínez 
    *  Date: 8/31/2013 11:32PM
    *  Modified: 8/31/2013 3:12AM
    */

    public class FilesHandler
    {
        private string[] directoryFilesInfo;
        private List<string> listOfFiles;

        public FilesHandler()
        {
            listOfFiles = new List<string>();
        }

        public void getAllTheFiles(string[]directory,string pattern)
        {
            if(directory.Length > 0)
            {
                for (int i = 0; i < directory.Length; i++)
                {
                    this.directoryFilesInfo = Directory.GetFiles(directory[i],pattern);
                    this.listOfFiles.AddRange(this.directoryFilesInfo);
                    this.directoryFilesInfo = null;
                  
                }

                //Finally
                this.directoryFilesInfo = this.listOfFiles.ToArray();
            }
           
        }


        public void OrganizeFiles(string action,string destination)
        {
            //This condition will prevent an exception if there are no monitored folders.
            if (this.directoryFilesInfo != null)
            {
                switch (action)
                {
                    case "Move":
                        for (int i = 0; i < this.directoryFilesInfo.Length; i++)
                        {
                            Match match = Regex.Match(directoryFilesInfo[i], @"([a-zA-Z0-9-_])+\.[a-zA.Z0-9]+");
                            if (match.Success)
                            {
                                string FileName = "\\" + match.Value;
                                try
                                {
                                    File.Move(directoryFilesInfo[i], destination + FileName);
                                }
                                catch (Exception) { }
                            }
                        }
                        break;

                    case "Delete":
                        for (int i = 0; i < this.directoryFilesInfo.Length; i++)
                        {
                            try
                            {
                                File.Delete(directoryFilesInfo[i]);
                            }
                            catch (Exception) { }
                        }
                        break;
                }
            }
        }


        public void Reset()
        {
            this.directoryFilesInfo = null;
            this.listOfFiles.Clear();
        }
        
    }
}
