using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFApp
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("CodeFirstDatabase") 
        {
            //Database.SetInitializer<CompanyContext>(new DropCreateDatabaseIfModelChanges<CompanyContext>());
            Database.SetInitializer<CompanyContext>(new DropCreateDatabaseAlways<CompanyContext>());
        }

        public DbSet<Collaborator> Collaborators { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<Manager> Managers { get; set; }
    }
}
