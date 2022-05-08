namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SzerzodesekFrissitese1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Szerzodesek", "Koltseg");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Szerzodesek", "Koltseg", c => c.Int(nullable: false));
        }
    }
}
