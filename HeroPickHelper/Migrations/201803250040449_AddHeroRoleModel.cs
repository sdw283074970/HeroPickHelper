namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeroRoleModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HeroRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HeroRoles");
        }
    }
}
