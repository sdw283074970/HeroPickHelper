namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedConvention : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.HeroDuties", name: "Hero_Id", newName: "HeroId");
            RenameColumn(table: "dbo.HeroDuties", name: "Duty_Id", newName: "DutyId");
            RenameIndex(table: "dbo.HeroDuties", name: "IX_Hero_Id", newName: "IX_HeroId");
            RenameIndex(table: "dbo.HeroDuties", name: "IX_Duty_Id", newName: "IX_DutyId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.HeroDuties", name: "IX_DutyId", newName: "IX_Duty_Id");
            RenameIndex(table: "dbo.HeroDuties", name: "IX_HeroId", newName: "IX_Hero_Id");
            RenameColumn(table: "dbo.HeroDuties", name: "DutyId", newName: "Duty_Id");
            RenameColumn(table: "dbo.HeroDuties", name: "HeroId", newName: "Hero_Id");
        }
    }
}
