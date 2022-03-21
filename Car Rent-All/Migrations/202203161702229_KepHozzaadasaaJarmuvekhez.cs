namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KepHozzaadasaaJarmuvekhez : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jarmuvek", "Kep", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jarmuvek", "Kep");
        }
    }
}
