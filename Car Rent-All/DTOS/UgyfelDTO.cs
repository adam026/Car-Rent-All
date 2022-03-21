using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rent_All.DTOS
{
    public class UgyfelDTO
    {

        public int Id { get; set; }
        public string Nev { get; set; }
        public string Cim { get; set; }
        public DateTime? SzuletesiDatum { get; set; }
        public string Jogositvany { get; set; }
        public string Telefonszam { get; set; }
        public string Email { get; set; }
    }
}