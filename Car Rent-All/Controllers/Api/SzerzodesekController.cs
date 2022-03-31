using Car_Rent_All.DTOS;
using Car_Rent_All.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Car_Rent_All.Controllers.Api
{
    public class SzerzodesekController : ApiController
    {
        private ApplicationDbContext _context;

        public SzerzodesekController()
        {
            _context = new ApplicationDbContext();
        }

        //[HttpPost]
        //public IHttpActionResult CreateNewSzerzodes(SzerzodesDTO szerzodesDTO) 
        //{
        //    var ugyfel = _context.Ugyfelek.Single(u => u.Id == szerzodesDTO.UgyfelId);

        //    if (ugyfel == null)
        //        return BadRequest("Az ügyfél nem található az adatbázisban!");

        //    var jarmu = _context.Jarmuvek.Single(j => j.Id == szerzodesDTO.JarmuId)

        //    foreach (var jarmu in jarmuvek)
        //    {
        //        if (jarmu.Elerheto == 0)
        //            return BadRequest("A jármű nem elérhető!");
        //        jarmu.Elerheto--;

        //        var szerzodes = new Szerzodes
        //        {
        //            Ugyfel = ugyfel,
        //            Jarmu = jarmu,
        //            BerlesKezdoIdopont = DateTime.Now
        //        };

        //        _context.Szerzodesek.Add(szerzodes);
        //    };

        //    return Ok();
        //}

    }
}
