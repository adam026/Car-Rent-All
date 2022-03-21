using Car_Rent_All.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rent_All.ViewModels
{
    public class JarmuValtoUzemanyag
    {
        public Jarmu Jarmu { get; set; }
        public IEnumerable<Uzemanyag> Uzemanyag { get; set; }
        public IEnumerable<Valto> Valto { get; set; }
    }
}