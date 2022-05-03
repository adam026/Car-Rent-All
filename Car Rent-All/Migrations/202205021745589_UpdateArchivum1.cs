namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateArchivum1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArchivaltSzerzodesek", "BefizetettOsszeg", c => c.Int(nullable: false));
            AddColumn("dbo.ArchivaltSzerzodesek", "Megjegyzes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArchivaltSzerzodesek", "Megjegyzes");
            DropColumn("dbo.ArchivaltSzerzodesek", "BefizetettOsszeg");
        }
    }
}
