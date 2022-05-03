using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Car_Rent_All.Models
{
    [Table("ArchivaltSzerzodesek")]
    public class Archivum
    {
        public int Id { get; set; }

        public int SzerzodesId { get; set; }

        public string UgyfelNeve { get; set; }
        public string UgyfelCime { get; set; }
        public DateTime? UgyfelSzuletesiDatum { get; set; }
        public string UgyfelJogositvany { get; set; }
        public string UgyfelTelefonszam { get; set; }
        public string UgyfelEmail { get; set; }

        public string JarmuNev { get; set; }
        public string JarmuRendszam { get; set; }
        public string JarmuAlvazszam { get; set; }
        public int JarmuGyartasEve { get; set; }

        public DateTime BerlesKezdoIdopont { get; set; }
        public DateTime BerlesZaroIdopont { get; set; }

        public int BefizetettOsszeg { get; set; }
        public string Megjegyzes { get; set; }

    }
}