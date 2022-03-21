namespace Car_Rent_All.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JarmuvekFeltöltese : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Jarmuvek (Nev, Rendszam, Alvazszam, valtoId, UzemanyagId, Ules, Ajtok, GyartasEve, Kep) VALUES('Ford Fiesta','AAA111','FiktivAlvazszam','1','1','5','5','2001','ford_fiesta.png')");
            Sql("INSERT INTO Jarmuvek (Nev, Rendszam, Alvazszam, valtoId, UzemanyagId, Ules, Ajtok, GyartasEve, Kep) VALUES('Opel Astra','BBB222','FiktivAlvazszam','2','2','4','5','2005','opel_astra.png')");
            Sql("INSERT INTO Jarmuvek (Nev, Rendszam, Alvazszam, valtoId, UzemanyagId, Ules, Ajtok, GyartasEve, Kep) VALUES('Renault Captur','CCC333','FiktívAlvazszam','1','2','5','5','2007','renault_captur.png')");
            Sql("INSERT INTO Jarmuvek (Nev, Rendszam, Alvazszam, valtoId, UzemanyagId, Ules, Ajtok, GyartasEve, Kep) VALUES('Renault Clio','DDD444','FiktívAlvazszam','2','1','4','4','2000','renault_clio')");
        }

        public override void Down()
        {
        }
    }
}
