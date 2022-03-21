namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValtokesUzemanyagokFeltoltese : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Valtok (Nev) VALUES ('Automata')");
            Sql("INSERT INTO Valtok (Nev) VALUES ('Manuális')");
            Sql("INSERT INTO Uzemanyagok (Nev) VALUES ('Benzin')");
            Sql("INSERT INTO Uzemanyagok (Nev) VALUES ('Diesel')");
        }

        public override void Down()
        {
        }
    }
}
