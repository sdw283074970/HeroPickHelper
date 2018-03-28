namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyToManyRelationshipBetweenHeroAndDuty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Duties", "Hero_Id", "dbo.Heroes");
            DropIndex("dbo.Duties", new[] { "Hero_Id" });
            CreateTable(
                "dbo.HeroDuties",
                c => new
                    {
                        Hero_Id = c.Int(nullable: false),
                        Duty_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hero_Id, t.Duty_Id })
                .ForeignKey("dbo.Heroes", t => t.Hero_Id, cascadeDelete: true)
                .ForeignKey("dbo.Duties", t => t.Duty_Id, cascadeDelete: true)
                .Index(t => t.Hero_Id)
                .Index(t => t.Duty_Id);
            
            DropColumn("dbo.Duties", "Hero_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Duties", "Hero_Id", c => c.Int());
            DropForeignKey("dbo.HeroDuties", "Duty_Id", "dbo.Duties");
            DropForeignKey("dbo.HeroDuties", "Hero_Id", "dbo.Heroes");
            DropIndex("dbo.HeroDuties", new[] { "Duty_Id" });
            DropIndex("dbo.HeroDuties", new[] { "Hero_Id" });
            DropTable("dbo.HeroDuties");
            CreateIndex("dbo.Duties", "Hero_Id");
            AddForeignKey("dbo.Duties", "Hero_Id", "dbo.Heroes", "Id");
        }
    }
}
