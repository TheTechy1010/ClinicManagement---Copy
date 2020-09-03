namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInPhysicianId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Physician_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Doctors", new[] { "Physician_Id" });
            DropColumn("dbo.Doctors", "PhysicianId");
            RenameColumn(table: "dbo.Doctors", name: "Physician_Id", newName: "PhysicianId");
            AlterColumn("dbo.Doctors", "PhysicianId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Doctors", "PhysicianId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Doctors", "PhysicianId");
            AddForeignKey("dbo.Doctors", "PhysicianId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "PhysicianId", "dbo.AspNetUsers");
            DropIndex("dbo.Doctors", new[] { "PhysicianId" });
            AlterColumn("dbo.Doctors", "PhysicianId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Doctors", "PhysicianId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Doctors", name: "PhysicianId", newName: "Physician_Id");
            AddColumn("dbo.Doctors", "PhysicianId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "Physician_Id");
            AddForeignKey("dbo.Doctors", "Physician_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
