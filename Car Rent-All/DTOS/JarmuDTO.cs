using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rent_All.DTOS
{
    public class JarmuDTO
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Rendszam { get; set; }
        public string Alvazszam { get; set; }

        public int valtoId { get; set; }
        public ValtoDTO Valto { get; set; }

        public int UzemanyagId { get; set; }
        public UzemanyagDTO Uzemanyag { get; set; }

        public int Ules { get; set; }
        public int Ajtok { get; set; }
        public int GyartasEve { get; set; }
        public int Elerheto { get; set; }
    }
}