namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JarmuvekHozzaadasa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jarmuvek",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(nullable: false),
                        Rendszam = c.String(nullable: false),
                        Alvazszam = c.String(nullable: false),
                        valtoId = c.Int(nullable: false),
                        UzemanyagId = c.Int(nullable: false),
                        Ules = c.Int(nullable: false),
                        Ajtok = c.Int(nullable: false),
                        GyartasEve = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uzemanyagok", t => t.UzemanyagId, cascadeDelete: true)
                .ForeignKey("dbo.Valtok", t => t.valtoId, cascadeDelete: true)
                .Index(t => t.valtoId)
                .Index(t => t.UzemanyagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jarmuvek", "valtoId", "dbo.Valtok");
            DropForeignKey("dbo.Jarmuvek", "UzemanyagId", "dbo.Uzemanyagok");
            DropIndex("dbo.Jarmuvek", new[] { "UzemanyagId" });
            DropIndex("dbo.Jarmuvek", new[] { "valtoId" });
            DropTable("dbo.Jarmuvek");
        }
    }
}
