namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class valtozas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Szerzodesek", "BerlesZaroIdopont", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Szerzodesek", "BerlesZaroIdopont", c => c.DateTime());
        }
    }
}
