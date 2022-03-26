using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car_Rent_All.DTOS
{
    public class SzerzodesDTO
    {
        public int UgyfelId { get; set; }
        public List<int> JarmuIds { get; set; }
    }
}