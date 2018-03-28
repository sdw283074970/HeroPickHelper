namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedManyToManyRelationshipBetweenHeroesAndHeroRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HeroRoleHeroes",
                c => new
                    {
                        HeroRole_Id = c.Int(nullable: false),
                        Hero_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HeroRole_Id, t.Hero_Id })
                .ForeignKey("dbo.HeroRoles", t => t.HeroRole_Id, cascadeDelete: true)
                .ForeignKey("dbo.Heroes", t => t.Hero_Id, cascadeDelete: true)
                .Index(t => t.HeroRole_Id)
                .Index(t => t.Hero_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HeroRoleHeroes", "Hero_Id", "dbo.Heroes");
            DropForeignKey("dbo.HeroRoleHeroes", "HeroRole_Id", "dbo.HeroRoles");
            DropIndex("dbo.HeroRoleHeroes", new[] { "Hero_Id" });
            DropIndex("dbo.HeroRoleHeroes", new[] { "HeroRole_Id" });
            DropTable("dbo.HeroRoleHeroes");
        }
    }
}
