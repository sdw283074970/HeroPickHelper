namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedWrongSpellsInDutyHero : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.HeroToclients", newName: "Heroes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Heroes", newName: "HeroToclients");
        }
    }
}
