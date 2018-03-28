namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedHeroRolesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HeroRoles", "Hero_Id", "dbo.Heroes");
            DropIndex("dbo.HeroRoles", new[] { "Hero_Id" });
            DropTable("dbo.HeroRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HeroRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Hero_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.HeroRoles", "Hero_Id");
            AddForeignKey("dbo.HeroRoles", "Hero_Id", "dbo.Heroes", "Id");
        }
    }
}
