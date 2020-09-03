namespace ClinicManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(
                @"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'79792644-c923-487e-a0e3-cde282ef1900', N'admin@clinic.com', 0, N'AGPY7TD8LSZ0b787pZCGQzYdklQjUZVrBD/izblYWH2G60ZPPeCeAxQrfZx2Gle6cA==', N'6474de72-88e2-43a2-8d10-a5f24c6c60b6', NULL, 0, 0, NULL, 1, 0, N'admin@clinic.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9b0c8b2d-4880-4ca3-b8b0-a80ad8e9f64b', N'doctor@clinic.com', 0, N'AOfwX8LnkINuUpJ1Q0u46GCf59Z4PUhP4lzopGanpZa3SpR2gGLZrvMtDugc5AQLKQ==', N'6c5ce883-3051-44c5-9b84-1f1a62a3e90c', NULL, 0, 0, NULL, 1, 0, N'doctor@clinic.com')


                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ff3292e8-c899-45fd-8b78-2bdd53d60b0e', N'Admin')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b1e14b2f-412b-4ca9-be6e-c21aaf4077d0', N'Doctor')


                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'79792644-c923-487e-a0e3-cde282ef1900', N'b1e14b2f-412b-4ca9-be6e-c21aaf4077d0')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'79792644-c923-487e-a0e3-cde282ef1900', N'ff3292e8-c899-45fd-8b78-2bdd53d60b0e')

");
        }
        
        public override void Down()
        {
        }
    }
}
