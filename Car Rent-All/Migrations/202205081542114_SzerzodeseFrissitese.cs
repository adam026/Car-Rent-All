namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SzerzodeseFrissitese : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Szerzodesek", "Koltseg", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Szerzodesek", "Koltseg");
        }
    }
}
