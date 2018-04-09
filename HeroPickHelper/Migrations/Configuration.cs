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
            //    new Duty() { Id = 1, Name = "Carry" },
            //    new Duty() { Id = 2, Name = "Mid" },
            //    new Duty() { Id = 3, Name = "Offlane" },
            //    new Duty() { Id = 4, Name = "Roam Or Junggle" },
            //    new Duty() { Id = 5, Name = "Support" }
            //    );

            //for(int i = 1; i < 116; i++)
            //{
            //    for(int j = 1; j < 116; j++)
            //    {
            //        context.HeroCounters.AddOrUpdate(d => d.Id,
            //            new HeroCounter()
            //            {
            //                Ida = i,
            //                Idb = j,
            //                Value = 1
            //            });
            //    }
            //}

            //为权重表添加数据
            //context.Weights.AddOrUpdate(w => w.Id,
            //    new Weight()
            //    {
            //        PositionClass = "12",
            //        Class12 = 4,
            //        Class23 = 3,
            //        Class34 = 2,
            //        Class45 = 1
            //    },
            //    new Weight()
            //    {
            //        PositionClass = "23",
            //        Class12 = 4,
            //        Class23 = 2,
            //        Class34 = 2,
            //        Class45 = 2
            //    },
            //    new Weight()
            //    {
            //        PositionClass = "34",
            //        Class12 = 3,
            //        Class23 = 3,
            //        Class34 = 2,
            //        Class45 = 2
            //    },
            //    new Weight()
            //    {
            //        PositionClass = "45",
            //        Class12 = 3,
            //        Class23 = 4,
            //        Class34 = 2,
            //        Class45 = 1
            //    }
            //);

            //context.Weights.AddOrUpdate(c => c.Id,
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "12",
            //        CounteredHeroPosition = "12",
            //        WeightIndex = 4
            //    },
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "12",
            //        CounteredHeroPosition = "23",
            //        WeightIndex = 3
            //    },
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "12",
            //        CounteredHeroPosition = "34",
            //        WeightIndex = 2
            //    },
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "12",
            //        CounteredHeroPosition = "45",
            //        WeightIndex = 1
            //    },
            //    //第二行
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "23",
            //        CounteredHeroPosition = "12",
            //        WeightIndex = 4
            //    },
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "23",
            //        CounteredHeroPosition = "23",
            //        WeightIndex = 2
            //    },
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "23",
            //        CounteredHeroPosition = "34",
            //        WeightIndex = 1
            //    },
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "23",
            //        CounteredHeroPosition = "45",
            //        WeightIndex = 3
            //    },
            //    //第三行
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "34",
            //        CounteredHeroPosition = "12",
            //        WeightIndex = 3
            //    },
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "34",
            //        CounteredHeroPosition = "23",
            //        WeightIndex = 3
            //    },
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "34",
            //        CounteredHeroPosition = "34",
            //        WeightIndex = 2
            //    },
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "34",
            //        CounteredHeroPosition = "45",
            //        WeightIndex = 2
            //    },
            //    //第四行
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "45",
            //        CounteredHeroPosition = "12",
            //        WeightIndex = 3
            //    },
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "45",
            //        CounteredHeroPosition = "23",
            //        WeightIndex = 4
            //    },
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "45",
            //        CounteredHeroPosition = "34",
            //        WeightIndex = 2
            //    },
            //    new Weight()
            //    {
            //        EnemyHeroPosition = "45",
            //        CounteredHeroPosition = "45",
            //        WeightIndex = 1
            //    }
            //);

            context.Colors.AddOrUpdate(c => c.ColorName,
                new Color { Id = 1, ColorName = "PPP" }
                );
        }
    }
}
