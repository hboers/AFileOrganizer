using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entities;

namespace Data
{
    /*
        Author: Jefri J. Martínez 
     *  Date: 8/31/2013
     *  Modified: 8/31/2013
     */

    public class FileOContextInitializer : DropCreateDatabaseIfModelChanges<FileOContext>
    {
        protected override void Seed(FileOContext context)
        {
            base.Seed(context);
        }
    }

    public class FileOContext : DbContext
    {
        public FileOContext() : base("FileOConnection")
        {
            Database.SetInitializer(new FileOContextInitializer());
            Database.Initialize(true);
        }

        public DbSet<Association> Associations { get; set; }
        public DbSet<Observer> Observers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AssociationConfiguration());
            modelBuilder.Configurations.Add(new ObserverConfiguration());

            base.OnModelCreating(modelBuilder);
        }



    }
}
