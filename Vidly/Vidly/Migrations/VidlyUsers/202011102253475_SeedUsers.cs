namespace Vidly.Migrations.VidlyUsers
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8114b9a2-13e2-40b2-8481-55ef4366f207', N'user@email.com', 0, N'AEHCzp1FCjY2RxEzBfj29YKUVnzTKp9B2JPOi/Hfp+0glof6ZMz3m6zKFdMub1qCoA==', N'362c9d23-6d8d-4c25-a4e0-aba5e77a0847', NULL, 0, 0, NULL, 1, 0, N'user@email.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fba9b825-6527-4df4-a193-842cd7522ffd', N'admin@email.com', 0, N'AAIYQmaWJa9OaRbSn9aFAHvKlfbSQpHPsNytXkDQfRpjc5Fwghl/GsLSGM1LOsO+YQ==', N'37e78a4c-b688-42a1-b6cf-f3c0aa3d2d95', NULL, 0, 0, NULL, 1, 0, N'admin@email.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd2687fe3-42ab-43f9-a07e-9cd9c93133e3', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fba9b825-6527-4df4-a193-842cd7522ffd', N'd2687fe3-42ab-43f9-a07e-9cd9c93133e3')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
