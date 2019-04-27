using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Model;

namespace DAL.Repository
{
    public class ApplicationContext : DbContext
    {
        public  ApplicationContext() : base("ApplicationContext")
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<HouseListing> HouseListing { get; set; }
        public DbSet<Population> Population { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
