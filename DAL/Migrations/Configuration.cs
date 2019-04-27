namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using DAL.Model;
    using System.Collections.Generic;
   

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Repository.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.Repository.ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var user = new List<User>
            {
                new User{FirstName="Himanshu", LastName="Gupta", Password="himanshu@123", Email="himanshu.gupta@nagarro.com", IsApprover=true, VolunteerStatus="Accepted", AdhaarNumber="484013750892", ImageName="abc"}
            };
            user.ForEach(s => context.User.Add(s));
            context.SaveChanges();
            
        }
    }
}
