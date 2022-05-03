namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArchivaltSzerzodesekTablaHozzaadasa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArchivaltSzerzodesek",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SzerzodesId = c.Int(nullable: false),
                        UgyfelId = c.Int(nullable: false),
                        JarmuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jarmuvek", t => t.JarmuId, cascadeDelete: true)
                .ForeignKey("dbo.Szerzodesek", t => t.SzerzodesId, cascadeDelete: false)
                .ForeignKey("dbo.Ugyfelek", t => t.UgyfelId, cascadeDelete: true)
                .Index(t => t.SzerzodesId)
                .Index(t => t.UgyfelId)
                .Index(t => t.JarmuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArchivaltSzerzodesek", "UgyfelId", "dbo.Ugyfelek");
            DropForeignKey("dbo.ArchivaltSzerzodesek", "SzerzodesId", "dbo.Szerzodesek");
            DropForeignKey("dbo.ArchivaltSzerzodesek", "JarmuId", "dbo.Jarmuvek");
            DropIndex("dbo.ArchivaltSzerzodesek", new[] { "JarmuId" });
            DropIndex("dbo.ArchivaltSzerzodesek", new[] { "UgyfelId" });
            DropIndex("dbo.ArchivaltSzerzodesek", new[] { "SzerzodesId" });
            DropTable("dbo.ArchivaltSzerzodesek");
        }
    }
}
