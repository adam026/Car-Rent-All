using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Car_Rent_All.Models
{
    [Table("Szerzodesek")]
    public class Szerzodes
    {
        public int Id { get; set; }

        [Required]
        public Ugyfel Ugyfel { get; set; }

        [Required]
        public Jarmu Jarmu { get; set; }

        public DateTime BerlesKezdoIdopont { get; set; }
        public DateTime? BerlesZaroIdopont { get; set; }
    }
}