namespace HeroPickHelper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedDutyIdFromByteToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DutyHeroes", "Duty_Id", "dbo.Duties");
            DropIndex("dbo.DutyHeroes", new[] { "Duty_Id" });
            DropColumn("dbo.DutyHeroes", "DutyId");
            RenameColumn(table: "dbo.DutyHeroes", name: "Duty_Id", newName: "DutyId");
            DropPrimaryKey("dbo.Duties");
            AlterColumn("dbo.Duties", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DutyHeroes", "DutyId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Duties", "Id");
            CreateIndex("dbo.DutyHeroes", "DutyId");
            AddForeignKey("dbo.DutyHeroes", "DutyId", "dbo.Duties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DutyHeroes", "DutyId", "dbo.Duties");
            DropIndex("dbo.DutyHeroes", new[] { "DutyId" });
            DropPrimaryKey("dbo.Duties");
            AlterColumn("dbo.DutyHeroes", "DutyId", c => c.Byte());
            AlterColumn("dbo.Duties", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Duties", "Id");
            RenameColumn(table: "dbo.DutyHeroes", name: "DutyId", newName: "Duty_Id");
            AddColumn("dbo.DutyHeroes", "DutyId", c => c.Int(nullable: false));
            CreateIndex("dbo.DutyHeroes", "Duty_Id");
            AddForeignKey("dbo.DutyHeroes", "Duty_Id", "dbo.Duties", "Id");
        }
    }
}
