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

            //EF无法正确编码 尝试插入Character Set=UTF8在connectionStrings中失败
            //context.Duties.AddOrUpdate(d => d.Id,
            //    new Duty() { Id = 1, Name = "大哥" },
            //    new Duty() { Id = 2, Name = "中单" },
            //    new Duty() { Id = 3, Name = "劣单" },
            //    new Duty() { Id = 4, Name = "游走或打野" },
            //    new Duty() { Id = 5, Name = "辅助" }
            //    );
        }
    }
}
