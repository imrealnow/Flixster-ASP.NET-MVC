namespace Flixster.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminAccount : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'08d5e4e2-fbe2-41c9-8d27-5eeca681d0b8', N'admin@flixster.com', 0, N'ACbe9ZpNbIvBHBDAZlg8pS13jhMBUs7bdVcdBEV+Q+ubr8FC6+HqiPFEsf3pRtLqgA==', N'92096c76-ec33-4155-8b62-856b25e5ad5f', NULL, 0, 0, NULL, 1, 0, N'admin@flixster.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'71b8211e-3dfb-4180-a9bb-8fb1c3a5a3f7', N'test@test.com', 0, N'ADRhf4JUCXighp0Aag2sAyx4oLa4fpp7Toekf8McLZ34a9X/K1uw8F/Yn0Mr38S2nQ==', N'fe7a5ac6-0bbb-4a1c-8065-18eca821a72c', NULL, 0, 0, NULL, 1, 0, N'test@test.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6a7f2b5b-7163-4207-8667-de85debd7b4b', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'08d5e4e2-fbe2-41c9-8d27-5eeca681d0b8', N'6a7f2b5b-7163-4207-8667-de85debd7b4b')

");
        }
        
        public override void Down()
        {
        }
    }
}
