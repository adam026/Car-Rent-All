namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SzerzodesekModositas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Szerzodesek", "BerlesKezdoIdopont", c => c.DateTime());
            AlterColumn("dbo.Szerzodesek", "BerlesZaroIdopont", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Szerzodesek", "BerlesZaroIdopont", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Szerzodesek", "BerlesKezdoIdopont", c => c.DateTime(nullable: false));
        }
    }
}
