namespace DogOnline.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DogOnline.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DogOnline.Models.DogOnlineDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DogOnline.Models.DogOnlineDbContext context)
        {
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

            context.Details.AddOrUpdate(p=>p.Name, 
                new Details
                {
                    Name="Shandee",
                    Breed="Golden Retriever",
                    Gender="Female",
                    Age="7.5",
                    Location="Macau",
                    Contact="hanxiaosonic@gmail.com",
                    //Image=0,
                    //ImageFileName="",
                },
                new Details
                {
                    Name="Bailey",
                    Breed="Golden Retriever",
                    Gender="Female",
                    Age="3.5",
                    Location="Macau",
                    Contact="63439300",
                    //Image = 0,
                    //ImageFileName = "",
                }                
                );
        }
    }
}
