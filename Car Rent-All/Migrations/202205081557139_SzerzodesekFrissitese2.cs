namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SzerzodesekFrissitese2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Szerzodesek", "ArPerNap", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Szerzodesek", "ArPerNap");
        }
    }
}
