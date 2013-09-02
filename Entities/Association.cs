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

    public class Association
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Action { get; set; }
        public string Destination { get; set; }
    }

    public class AssociationConfiguration : EntityTypeConfiguration<Association>
    {
        public AssociationConfiguration()
        {
            Property(a => a.Name).HasMaxLength(100).IsRequired();
            Property(a => a.Extension).HasMaxLength(10).IsRequired();
            Property(a => a.Action).HasMaxLength(10).IsRequired();
            Property(a => a.Destination).IsRequired();
        }
    }
}
