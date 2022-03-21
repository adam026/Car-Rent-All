namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ugyfelek",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(nullable: false, maxLength: 60, unicode: false),
                        Cim = c.String(nullable: false, maxLength: 200, unicode: false),
                        SzuletesiDatum = c.DateTime(nullable: false),
                        Jogositvany = c.String(nullable: false),
                        Telefonszam = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ugyfelek");
        }
    }
}
