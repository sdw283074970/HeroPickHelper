namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeroCountersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HeroCounters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ida = c.Int(nullable: false),
                        Idb = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HeroCounters");
        }
    }
}
