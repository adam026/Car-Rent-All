namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SzerzodesekModositas3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Szerzodesek", "Jovahagy", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Szerzodesek", "Jovahagy");
        }
    }
}
