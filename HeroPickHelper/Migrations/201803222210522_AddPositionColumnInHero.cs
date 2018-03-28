namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPositionColumnInHero : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "Position", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heroes", "Position");
        }
    }
}
