namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSomeModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Heroes", newName: "HeroToclients");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.HeroToclients", newName: "Heroes");
        }
    }
}
