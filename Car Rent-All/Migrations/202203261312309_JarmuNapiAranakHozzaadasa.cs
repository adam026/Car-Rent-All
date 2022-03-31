namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JarmuNapiAranakHozzaadasa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jarmuvek", "Ar", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jarmuvek", "Ar");
        }
    }
}
