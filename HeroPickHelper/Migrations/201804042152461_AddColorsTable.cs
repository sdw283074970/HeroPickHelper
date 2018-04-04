namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColorsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Heroes", "Color_Id", c => c.Int());
            CreateIndex("dbo.Heroes", "Color_Id");
            AddForeignKey("dbo.Heroes", "Color_Id", "dbo.Colors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Heroes", "Color_Id", "dbo.Colors");
            DropIndex("dbo.Heroes", new[] { "Color_Id" });
            DropColumn("dbo.Heroes", "Color_Id");
            DropTable("dbo.Colors");
        }
    }
}
