namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SzerzodesekHozzaadasaAzAdatbazishoz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Szerzodesek",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BerlesKezdoIdopont = c.DateTime(nullable: false),
                        BerlesZaroIdopont = c.DateTime(),
                        Jarmu_Id = c.Int(nullable: false),
                        Ugyfel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jarmuvek", t => t.Jarmu_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ugyfelek", t => t.Ugyfel_Id, cascadeDelete: true)
                .Index(t => t.Jarmu_Id)
                .Index(t => t.Ugyfel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Szerzodesek", "Ugyfel_Id", "dbo.Ugyfelek");
            DropForeignKey("dbo.Szerzodesek", "Jarmu_Id", "dbo.Jarmuvek");
            DropIndex("dbo.Szerzodesek", new[] { "Ugyfel_Id" });
            DropIndex("dbo.Szerzodesek", new[] { "Jarmu_Id" });
            DropTable("dbo.Szerzodesek");
        }
    }
}
