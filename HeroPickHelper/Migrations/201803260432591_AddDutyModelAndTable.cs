namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDutyModelAndTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Duties",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Duties");
        }
    }
}
