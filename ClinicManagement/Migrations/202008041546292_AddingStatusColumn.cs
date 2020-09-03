namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingStatusColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "DStatus", c => c.Boolean(nullable: false,defaultValue:true));
            AddColumn("dbo.Specializations", "DStatus", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Patients", "DStatus", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Attendances", "DStatus", c => c.Boolean(nullable: false, defaultValue: true));
            AddColumn("dbo.Cities", "DStatus", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cities", "DStatus");
            DropColumn("dbo.Attendances", "DStatus");
            DropColumn("dbo.Patients", "DStatus");
            DropColumn("dbo.Specializations", "DStatus");
            DropColumn("dbo.Doctors", "DStatus");
        }
    }
}
