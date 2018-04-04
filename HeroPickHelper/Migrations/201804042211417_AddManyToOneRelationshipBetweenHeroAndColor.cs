namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyToOneRelationshipBetweenHeroAndColor : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Heroes", name: "Color_Id", newName: "ColorId");
            RenameIndex(table: "dbo.Heroes", name: "IX_Color_Id", newName: "IX_ColorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Heroes", name: "IX_ColorId", newName: "IX_Color_Id");
            RenameColumn(table: "dbo.Heroes", name: "ColorId", newName: "Color_Id");
        }
    }
}
