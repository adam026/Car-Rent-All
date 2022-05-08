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

        [HttpDelete]
        public IHttpActionResult DeleteSzerzodes(int id)
        {
            var szerzodesInDb = _context.Szerzodesek.SingleOrDefault(sz => sz.Id == id);

            if (szerzodesInDb == null)
                return NotFound();
            var jarmu = _context.Jarmuvek.Single(j => j.Id == szerzodesInDb.JarmuId);

            jarmu.Elerheto = 1;
            _context.Szerzodesek.Remove(szerzodesInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
