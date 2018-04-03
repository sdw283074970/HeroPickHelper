namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeightsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PositionClass = c.String(),
                        Class12 = c.Int(nullable: false),
                        Class23 = c.Int(nullable: false),
                        Class34 = c.Int(nullable: false),
                        Class45 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weights");
        }
    }
}
