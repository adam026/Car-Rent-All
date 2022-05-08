namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JarmuvekTablaFrissitese : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jarmuvek", "Elerheto", c => c.Byte(nullable: false));
            DropColumn("dbo.Jarmuvek", "Keszlet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jarmuvek", "Keszlet", c => c.Int(nullable: false));
            AlterColumn("dbo.Jarmuvek", "Elerheto", c => c.Int(nullable: false));
        }
    }
}
