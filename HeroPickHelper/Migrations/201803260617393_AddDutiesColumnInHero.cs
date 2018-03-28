namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDutiesColumnInHero : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Duties", "Hero_Id", c => c.Int());
            CreateIndex("dbo.Duties", "Hero_Id");
            AddForeignKey("dbo.Duties", "Hero_Id", "dbo.Heroes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Duties", "Hero_Id", "dbo.Heroes");
            DropIndex("dbo.Duties", new[] { "Hero_Id" });
            DropColumn("dbo.Duties", "Hero_Id");
        }
    }
}
