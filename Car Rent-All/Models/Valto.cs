using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Car_Rent_All.Models
{
    [Table("Valtok")]
    public class Valto
    {
        public int Id { get; set; }
        public string Nev { get; set; }
    }
}