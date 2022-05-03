namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateArchivum2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArchivaltSzerzodesek", "JarmuGyartasEve", c => c.Int(nullable: false));
            AlterColumn("dbo.ArchivaltSzerzodesek", "UgyfelNeve", c => c.String());
            DropColumn("dbo.ArchivaltSzerzodesek", "GyartasEve");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArchivaltSzerzodesek", "GyartasEve", c => c.Int(nullable: false));
            AlterColumn("dbo.ArchivaltSzerzodesek", "UgyfelNeve", c => c.Int(nullable: false));
            DropColumn("dbo.ArchivaltSzerzodesek", "JarmuGyartasEve");
        }
    }
}
