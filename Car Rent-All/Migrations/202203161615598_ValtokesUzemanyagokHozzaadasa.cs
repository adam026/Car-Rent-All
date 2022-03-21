namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValtokesUzemanyagokHozzaadasa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uzemanyagok",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Valtok",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Valtok");
            DropTable("dbo.Uzemanyagok");
        }
    }
}
