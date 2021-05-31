namespace Almara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'57d3f1f6-5b0d-42a4-a207-22273427335a', N'ramashi1093@gmail.com', 0, N'AI7j6QvI+YCY1aWdkyLZ/sb9f3FLEdlgzgXDH8TBW8Dw0Y4SQFotJ6MoMFDmsZpu+A==', N'451e7790-f70e-4ce9-bbf7-10d285140f3c', NULL, 0, 0, NULL, 1, 0, N'ramashi1093@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a430de9d-c1f2-45da-bf17-02dea35e99d3', N'admin@almara.com', 0, N'AFtctcVI6W5QEcihxu3dOtFFDHBOGRPyFHC57QuM1x0hrBlzXAhXgVSnWAKKRdbk/g==', N'65015cfc-15ba-4184-bd19-f5a837efce69', NULL, 0, 0, NULL, 1, 0, N'admin@almara.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b3fafc44-eb50-4f9a-ac2d-a80bbef53a0a', N'guest@almara.com', 0, N'AKgyD4w5ps5FQn6ePJGpRz0R28bvH/TJuAluKJfJre8/z3Cael1neP8hoCOeiMzxTw==', N'058677fa-1848-4898-8536-15eb21cf9a1d', NULL, 0, 0, NULL, 1, 0, N'guest@almara.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3cd0ab47-fa35-49b8-bf48-e5c5e4543d96', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a430de9d-c1f2-45da-bf17-02dea35e99d3', N'3cd0ab47-fa35-49b8-bf48-e5c5e4543d96')


");
        }
        
        public override void Down()
        {
        }
    }
}
