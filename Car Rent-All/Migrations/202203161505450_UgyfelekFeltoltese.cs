namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UgyfelekFeltoltese : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Ugyfelek (Nev, Cim, SzuletesiDatum, Jogositvany, Telefonszam, Email) VALUES ('Am Erika','1121, Budapest, Petőfi Sándor utca 12.','1974-05-05','MB1986745','06305987465','ugyfel1@carrentall.com')");
            Sql("INSERT INTO Ugyfelek (Nev, Cim, SzuletesiDatum, Jogositvany, Telefonszam, Email) VALUES ('Patta Nóra','1125, Budapest, Bartók sétány 4.','1995-05-11','HG6976432','06708567421','ugyfel2@carrentall.com')");
            Sql("INSERT INTO Ugyfelek (Nev, Cim, SzuletesiDatum, Jogositvany, Telefonszam, Email) VALUES ('Para Zita','3000, Hatvan, Fő út 6.','1971-11-29','KN6598732','06209683245','ugyfel3@carrentall.com')");
            Sql("INSERT INTO Ugyfelek (Nev, Cim, SzuletesiDatum, Jogositvany, Telefonszam, Email) VALUES ('Remek Elek','8600 Siófok, Balatoni út 46.','1998-09-29','KK6935461','06708962156','ugyfel4@carrentall.com')");
        }

        public override void Down()
        {
        }
    }
}
