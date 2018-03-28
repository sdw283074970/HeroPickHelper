namespace HeroPickHelper.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HeroPickHelper.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HeroPickHelper.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Duties.AddOrUpdate(d => d.Name,
                new Duty() { Id = 1, Name = "Carry" },
                new Duty() { Id = 2, Name = "Mid" },
                new Duty() { Id = 3, Name = "Offlane" },
                new Duty() { Id = 4, Name = "RoamOrJungle" },
                new Duty() { Id = 5, Name = "Support" }
                );
        }
    }
}
