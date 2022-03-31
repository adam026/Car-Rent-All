using Car_Rent_All.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rent_All.DTOS
{
    public class SzerzodesDTO
    {
        public int Id { get; set; }

        public Ugyfel Ugyfel { get; set; }
        public Jarmu Jarmu { get; set; }
        public DateTime BerlesKezdoIdopont { get; set; }
        public DateTime? BerlesZaroIdopont { get; set; }
    }
}