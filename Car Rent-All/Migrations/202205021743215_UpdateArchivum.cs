namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateArchivum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ArchivaltSzerzodesek", "JarmuId", "dbo.Jarmuvek");
            DropForeignKey("dbo.ArchivaltSzerzodesek", "SzerzodesId", "dbo.Szerzodesek");
            DropForeignKey("dbo.ArchivaltSzerzodesek", "UgyfelId", "dbo.Ugyfelek");
            DropIndex("dbo.ArchivaltSzerzodesek", new[] { "SzerzodesId" });
            DropIndex("dbo.ArchivaltSzerzodesek", new[] { "UgyfelId" });
            DropIndex("dbo.ArchivaltSzerzodesek", new[] { "JarmuId" });
            AddColumn("dbo.ArchivaltSzerzodesek", "UgyfelNeve", c => c.Int(nullable: false));
            AddColumn("dbo.ArchivaltSzerzodesek", "UgyfelCime", c => c.String());
            AddColumn("dbo.ArchivaltSzerzodesek", "UgyfelSzuletesiDatum", c => c.DateTime());
            AddColumn("dbo.ArchivaltSzerzodesek", "UgyfelJogositvany", c => c.String());
            AddColumn("dbo.ArchivaltSzerzodesek", "UgyfelTelefonszam", c => c.String());
            AddColumn("dbo.ArchivaltSzerzodesek", "UgyfelEmail", c => c.String());
            AddColumn("dbo.ArchivaltSzerzodesek", "JarmuNev", c => c.String());
            AddColumn("dbo.ArchivaltSzerzodesek", "JarmuRendszam", c => c.String());
            AddColumn("dbo.ArchivaltSzerzodesek", "JarmuAlvazszam", c => c.String());
            AddColumn("dbo.ArchivaltSzerzodesek", "GyartasEve", c => c.Int(nullable: false));
            AddColumn("dbo.ArchivaltSzerzodesek", "BerlesKezdoIdopont", c => c.DateTime(nullable: false));
            AddColumn("dbo.ArchivaltSzerzodesek", "BerlesZaroIdopont", c => c.DateTime(nullable: false));
            DropColumn("dbo.ArchivaltSzerzodesek", "UgyfelId");
            DropColumn("dbo.ArchivaltSzerzodesek", "JarmuId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArchivaltSzerzodesek", "JarmuId", c => c.Int(nullable: false));
            AddColumn("dbo.ArchivaltSzerzodesek", "UgyfelId", c => c.Int(nullable: false));
            DropColumn("dbo.ArchivaltSzerzodesek", "BerlesZaroIdopont");
            DropColumn("dbo.ArchivaltSzerzodesek", "BerlesKezdoIdopont");
            DropColumn("dbo.ArchivaltSzerzodesek", "GyartasEve");
            DropColumn("dbo.ArchivaltSzerzodesek", "JarmuAlvazszam");
            DropColumn("dbo.ArchivaltSzerzodesek", "JarmuRendszam");
            DropColumn("dbo.ArchivaltSzerzodesek", "JarmuNev");
            DropColumn("dbo.ArchivaltSzerzodesek", "UgyfelEmail");
            DropColumn("dbo.ArchivaltSzerzodesek", "UgyfelTelefonszam");
            DropColumn("dbo.ArchivaltSzerzodesek", "UgyfelJogositvany");
            DropColumn("dbo.ArchivaltSzerzodesek", "UgyfelSzuletesiDatum");
            DropColumn("dbo.ArchivaltSzerzodesek", "UgyfelCime");
            DropColumn("dbo.ArchivaltSzerzodesek", "UgyfelNeve");
            CreateIndex("dbo.ArchivaltSzerzodesek", "JarmuId");
            CreateIndex("dbo.ArchivaltSzerzodesek", "UgyfelId");
            CreateIndex("dbo.ArchivaltSzerzodesek", "SzerzodesId");
            AddForeignKey("dbo.ArchivaltSzerzodesek", "UgyfelId", "dbo.Ugyfelek", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ArchivaltSzerzodesek", "SzerzodesId", "dbo.Szerzodesek", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ArchivaltSzerzodesek", "JarmuId", "dbo.Jarmuvek", "Id", cascadeDelete: true);
        }
    }
}
