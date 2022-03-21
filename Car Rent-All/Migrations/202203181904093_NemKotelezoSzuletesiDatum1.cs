namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NemKotelezoSzuletesiDatum1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ugyfelek", "SzuletesiDatum", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ugyfelek", "SzuletesiDatum", c => c.DateTime(nullable: false));
        }
    }
}
