namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedUselessColumns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Duties", "DutyHeroId");
            DropColumn("dbo.Heroes", "DutyHeroId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Heroes", "DutyHeroId", c => c.Int(nullable: false));
            AddColumn("dbo.Duties", "DutyHeroId", c => c.Int(nullable: false));
        }
    }
}
