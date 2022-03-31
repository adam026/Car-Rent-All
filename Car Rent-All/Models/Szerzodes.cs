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
        public int UgyfelId { get; set; }
        public Ugyfel Ugyfel { get; set; }

        [Required]
        public int JarmuId { get; set; }
        public Jarmu Jarmu { get; set; }

        [Required(ErrorMessage = "Kérlek add meg a bérlés kezdő időpontját!")]
        public DateTime BerlesKezdoIdopont { get; set; }

        [Required(ErrorMessage = "Kérlek add meg a bérlés záró időpontját!")]
        public DateTime BerlesZaroIdopont { get; set; }

        public byte Jovahagy { get; set; }

    }
}