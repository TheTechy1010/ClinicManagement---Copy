namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInSpecialization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Specializations", "Description", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Specializations", "Description");
        }
    }
}
