namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDstattoAppt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "DStatus", c => c.Boolean(nullable: false,defaultValue:true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "DStatus");
        }
    }
}
