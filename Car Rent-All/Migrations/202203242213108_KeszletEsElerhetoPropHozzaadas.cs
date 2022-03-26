namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeszletEsElerhetoPropHozzaadas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jarmuvek", "Keszlet", c => c.Int(nullable: false));
            AddColumn("dbo.Jarmuvek", "Elerheto", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jarmuvek", "Elerheto");
            DropColumn("dbo.Jarmuvek", "Keszlet");
        }
    }
}
