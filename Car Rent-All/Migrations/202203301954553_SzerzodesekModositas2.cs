namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SzerzodesekModositas2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Szerzodesek", name: "Jarmu_Id", newName: "JarmuId");
            RenameColumn(table: "dbo.Szerzodesek", name: "Ugyfel_Id", newName: "UgyfelId");
            RenameIndex(table: "dbo.Szerzodesek", name: "IX_Ugyfel_Id", newName: "IX_UgyfelId");
            RenameIndex(table: "dbo.Szerzodesek", name: "IX_Jarmu_Id", newName: "IX_JarmuId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Szerzodesek", name: "IX_JarmuId", newName: "IX_Jarmu_Id");
            RenameIndex(table: "dbo.Szerzodesek", name: "IX_UgyfelId", newName: "IX_Ugyfel_Id");
            RenameColumn(table: "dbo.Szerzodesek", name: "UgyfelId", newName: "Ugyfel_Id");
            RenameColumn(table: "dbo.Szerzodesek", name: "JarmuId", newName: "Jarmu_Id");
        }
    }
}
