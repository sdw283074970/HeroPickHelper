namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedManyToManyRelationShip : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HeroRoleHeroes", "HeroRole_Id", "dbo.HeroRoles");
            DropForeignKey("dbo.HeroRoleHeroes", "Hero_Id", "dbo.Heroes");
            DropIndex("dbo.HeroRoleHeroes", new[] { "HeroRole_Id" });
            DropIndex("dbo.HeroRoleHeroes", new[] { "Hero_Id" });
            AddColumn("dbo.HeroRoles", "Hero_Id", c => c.Int());
            CreateIndex("dbo.HeroRoles", "Hero_Id");
            AddForeignKey("dbo.HeroRoles", "Hero_Id", "dbo.Heroes", "Id");
            DropTable("dbo.HeroRoleHeroes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HeroRoleHeroes",
                c => new
                    {
                        HeroRole_Id = c.Int(nullable: false),
                        Hero_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HeroRole_Id, t.Hero_Id });
            
            DropForeignKey("dbo.HeroRoles", "Hero_Id", "dbo.Heroes");
            DropIndex("dbo.HeroRoles", new[] { "Hero_Id" });
            DropColumn("dbo.HeroRoles", "Hero_Id");
            CreateIndex("dbo.HeroRoleHeroes", "Hero_Id");
            CreateIndex("dbo.HeroRoleHeroes", "HeroRole_Id");
            AddForeignKey("dbo.HeroRoleHeroes", "Hero_Id", "dbo.Heroes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HeroRoleHeroes", "HeroRole_Id", "dbo.HeroRoles", "Id", cascadeDelete: true);
        }
    }
}
