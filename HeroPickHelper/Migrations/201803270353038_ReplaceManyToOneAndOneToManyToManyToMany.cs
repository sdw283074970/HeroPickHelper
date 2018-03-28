namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReplaceManyToOneAndOneToManyToManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HeroDuties", "HeroId", "dbo.Heroes");
            DropForeignKey("dbo.HeroDuties", "DutyId", "dbo.Duties");
            DropIndex("dbo.HeroDuties", new[] { "HeroId" });
            DropIndex("dbo.HeroDuties", new[] { "DutyId" });
            CreateTable(
                "dbo.DutyHeroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HeroId = c.Int(nullable: false),
                        DutyId = c.Int(nullable: false),
                        Duty_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Duties", t => t.Duty_Id)
                .ForeignKey("dbo.Heroes", t => t.HeroId, cascadeDelete: true)
                .Index(t => t.HeroId)
                .Index(t => t.Duty_Id);
            
            AddColumn("dbo.Duties", "DutyHeroId", c => c.Int(nullable: false));
            AddColumn("dbo.Heroes", "DutyHeroId", c => c.Int(nullable: false));
            DropTable("dbo.HeroDuties");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HeroDuties",
                c => new
                    {
                        HeroId = c.Int(nullable: false),
                        DutyId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.HeroId, t.DutyId });
            
            DropForeignKey("dbo.DutyHeroes", "HeroId", "dbo.Heroes");
            DropForeignKey("dbo.DutyHeroes", "Duty_Id", "dbo.Duties");
            DropIndex("dbo.DutyHeroes", new[] { "Duty_Id" });
            DropIndex("dbo.DutyHeroes", new[] { "HeroId" });
            DropColumn("dbo.Heroes", "DutyHeroId");
            DropColumn("dbo.Duties", "DutyHeroId");
            DropTable("dbo.DutyHeroes");
            CreateIndex("dbo.HeroDuties", "DutyId");
            CreateIndex("dbo.HeroDuties", "HeroId");
            AddForeignKey("dbo.HeroDuties", "DutyId", "dbo.Duties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HeroDuties", "HeroId", "dbo.Heroes", "Id", cascadeDelete: true);
        }
    }
}
