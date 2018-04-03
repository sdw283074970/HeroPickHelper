namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewWeightsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EnemyHeroPosition = c.String(),
                        CounteredHeroPosition = c.String(),
                        WeightIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weights");
        }
    }
}
