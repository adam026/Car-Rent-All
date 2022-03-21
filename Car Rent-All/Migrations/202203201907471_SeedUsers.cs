namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'afa31908-dfa9-42af-bb8f-ae502986ccbf', N'admin@carrentall.com', 0, N'AKKvspT3JVOnd/ilVC8DKwOinGGs5YQaGppMpn8DG2l8too0RdjDQvBWs3QjbvZT0Q==', N'673c4c93-a6cd-44dd-a1bc-11c870f7f97e', NULL, 0, 0, NULL, 1, 0, N'admin@carrentall.com')
                INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'ff4db57f-590e-4b06-bdc1-9579c5ec70d9', N'guest@gmail.com', 0, N'AKt0sLnXlRvYtLirwf0MG1BYXg8ihVzzrJDZhw+yp1w8bYH1Gc6/cctvyn9lCuGyqw==', N'3e204513-5430-4d6f-85de-7a7e33a90c43', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9483a8a2-26d1-4a73-a7e7-b4407a4d71d5', N'CanManage')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'afa31908-dfa9-42af-bb8f-ae502986ccbf', N'9483a8a2-26d1-4a73-a7e7-b4407a4d71d5')");
        }

        public override void Down()
        {
        }
    }
}
