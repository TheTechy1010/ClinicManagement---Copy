namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInCity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "Cities_Id", "dbo.Cities");
            DropIndex("dbo.Patients", new[] { "Cities_Id" });
            DropColumn("dbo.Patients", "CityId");
            RenameColumn(table: "dbo.Patients", name: "Cities_Id", newName: "CityId");
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.Patients", "CityId", c => c.Int(nullable: true));
            AlterColumn("dbo.Cities", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cities", "Id");
            CreateIndex("dbo.Patients", "CityId");
            AddForeignKey("dbo.Patients", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "CityId", "dbo.Cities");
            DropIndex("dbo.Patients", new[] { "CityId" });
            DropPrimaryKey("dbo.Cities");
            AlterColumn("dbo.Cities", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Patients", "CityId", c => c.Byte());
            AddPrimaryKey("dbo.Cities", "Id");
            RenameColumn(table: "dbo.Patients", name: "CityId", newName: "Cities_Id");
            AddColumn("dbo.Patients", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "Cities_Id");
            AddForeignKey("dbo.Patients", "Cities_Id", "dbo.Cities", "Id");
        }
    }
}
