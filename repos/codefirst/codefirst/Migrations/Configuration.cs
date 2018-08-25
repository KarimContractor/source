namespace codefirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using codefirst.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<codefirst.Models.StudentContext>
    {
        Student a;
        public Configuration()
        {
            
            AutomaticMigrationsEnabled = true;
            ContextKey = "codefirst.Models.StudentContext";
        }

        protected override void Seed(codefirst.Models.StudentContext context)
        {
            
             a = new Student
            {
                id = 3,
                Name = "Karim",
                Email = "Contractorkarim@outlook.com",
                Class = 14,
                Address = "abc",
                Mobile = "03471257845",

                
            };
            context.Students.Add(a);
            context.SaveChanges();
          
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

       
    }
}
