using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Entities
{
    /*
      Author: Jefri J. Martínez 
   *  Date: 8/31/2013
   *  Modified: 8/31/2013
   */

    public class Observer
    {
        public int Id { get; set; }
        public string Folder { get; set; }
    }

    public class ObserverConfiguration : EntityTypeConfiguration<Observer>
    {
        public ObserverConfiguration()
        {
            Property(o => o.Folder).IsRequired();
        }

    }

    
}
